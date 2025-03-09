using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Services;
using OrderFoodOnlineSystem.ViewModels.AccountViewModels;
using OrderFoodOnlineSystem.ViewModels.EmailViewModels;
using System.Transactions;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.ViewModels.AdminViewModels;

namespace OrderFoodOnlineSystem.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<Account> UserManager { get; }
        public SignInManager<Account> SignInManager { get; }
        public EmailService EmailService { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IAdminRepository AdminRepository { get; }
        public IRestaurantManagerRepository RestaurantManagerRepository { get; }
        public ICartRepository CartRepository { get; }

        public AccountController(UserManager<Account> userManager, SignInManager<Account> signInManager, EmailService emailService,
            ICustomerRepository customerRepository, IAdminRepository adminRepository, IRestaurantManagerRepository restaurantManagerRepository,
            ICartRepository cartRepository)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            EmailService = emailService;
            CustomerRepository = customerRepository;
            AdminRepository = adminRepository;
            RestaurantManagerRepository = restaurantManagerRepository;
            CartRepository = cartRepository;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //Register
        public async Task<IActionResult> Register()
        {
            var registerCustomerViewModel = new RegisterCustomerViewModel()
            {
                Schemes = await SignInManager.GetExternalAuthenticationSchemesAsync()
            };
            return View(registerCustomerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCustomerViewModel registerCustomerViewModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                registerCustomerViewModel.Schemes = await SignInManager.GetExternalAuthenticationSchemesAsync();

                try
                {
                    if (ModelState.IsValid)
                    {
                        var existingUser = await UserManager.FindByEmailAsync(registerCustomerViewModel.Email);
                        if (existingUser != null)
                        {
                            ModelState.AddModelError("", "Email already exists.");
                            return View(registerCustomerViewModel);
                        }

                        var account = registerCustomerViewModel.RegisterCustomer();
                        account.EmailConfirmed = false;
                        var identityResult = await UserManager.CreateAsync(account, registerCustomerViewModel.Password);

                        if (identityResult.Succeeded)
                        {
                            identityResult = await UserManager.AddToRoleAsync(account, "Customer");
                            if (identityResult.Succeeded)
                            {
                                var customer = registerCustomerViewModel.CreateCustomer();
                                customer.AccountId = account.Id;
                                customer = await CustomerRepository.CreateAsync(customer);

                                Cart cart = new Cart()
                                {
                                    TotalPrice = 0,
                                    IsDeleted = false,
                                    CustomerId = customer.Id
                                };

                                await CartRepository.CreateAsync(cart);

                                string confirmationLink = Url.Action("ConfirmEmail", "Account", new { Token = account.Id, Email = account.Email }, Request.Scheme);

                                string emailBody = $@"
                                    Dear {account.Email},<br/>
                                    Thank you for your registration.<br/>
                                    Please click on the below link to complete your registration:<br/>
                                    <a href='{confirmationLink}'>Confirm Email</a>";

                                EmailViewModel emailViewModel = new EmailViewModel
                                {
                                    To = account.Email,
                                    Subject = "Email Confirmation",
                                    Body = emailBody
                                };

                                bool isEmailSent = EmailService.SendEmail(emailViewModel);

                                if (!isEmailSent)
                                {
                                    transactionScope.Dispose();
                                    ModelState.AddModelError("", "Failed to send confirmation email. Please try again.");
                                    return View(registerCustomerViewModel);
                                }

                                transactionScope.Complete();
                                return RedirectToAction("Confirm", "Account");
                            }
                        }
                        foreach (var errorItem in identityResult.Errors)
                        {
                            ModelState.AddModelError("", errorItem.Description);
                        }
                    }
                    transactionScope.Dispose();
                    return View(registerCustomerViewModel);
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    ModelState.AddModelError("", "An error occurred. Please try again.");
                    return View(registerCustomerViewModel);
                }
            }

        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //Login
        public async Task<IActionResult> Login()
        {
            //return View();
            var loginUserViewModel = new LoginUserViewModel()
            {
                Schemes = await SignInManager.GetExternalAuthenticationSchemesAsync()
            };

            return View(loginUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
            try
            {
                loginUserViewModel.Schemes = await SignInManager.GetExternalAuthenticationSchemesAsync();

                if (ModelState.IsValid)
                {
                    var account = await UserManager.FindByEmailAsync(loginUserViewModel.Email);

                    if (account != null)
                    {
                        bool checkPasswordResult = await UserManager.CheckPasswordAsync(account, loginUserViewModel.Password);

                        if (checkPasswordResult)
                        {
                            if (account.EmailConfirmed)
                            {
                                List<Claim> Claims = new List<Claim>();
                                var roles = await UserManager.GetRolesAsync(account);

                                string action = "Index", controller = "Home", role = "", fName = "", userId = "0";

                                if (roles.Contains("Admin"))
                                {
                                    var admin = await AdminRepository.GetByAccountIdAsync(account.Id);
                                    if (admin != null)
                                    {
                                        controller = "Restaurant";
                                        action = "Index";
                                        role = "Admin";
                                        userId = admin.Id.ToString();
                                        fName = admin.Name;
                                    }
                                }
                                else if (roles.Contains("RestaurantManager"))
                                {
                                    var restaurantManager = await RestaurantManagerRepository.GetByAccountIdAsync(account.Id);
                                    if (restaurantManager != null)
                                    {
                                        controller = "Order";
                                        action = "GetAllRestaurantOrders";
                                        role = "RestaurantManager";
                                        userId = restaurantManager.Id.ToString();
                                        fName = restaurantManager.Name;
                                    }
                                }
                                else if (roles.Contains("Customer"))
                                {
                                    var customer = await CustomerRepository.GetByAccountIdAsync(account.Id);
                                    if (customer != null)
                                    {
                                        role = "Customer";
                                        userId = customer.Id.ToString();
                                        fName = customer.FirstName;
                                    }
                                }

                                Claims.Add(new Claim("Role", role));
                                Claims.Add(new Claim("AccountId", account.Id));
                                Claims.Add(new Claim("UserId", userId));
                                Claims.Add(new Claim("FName", fName));

                                await SignInManager.SignInWithClaimsAsync(account, loginUserViewModel.RememberMe, Claims);

                                return RedirectToAction(action, controller);
                            }
                            else
                            {
                                return View("Confirm");
                            }
                        }

                    }

                    ModelState.AddModelError("", "Invalid username or password.");
                }
                return View(loginUserViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred. Please try again.");
                return View(loginUserViewModel);
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------
        //Logout
        [Authorize]
        public IActionResult Logout()
        {
            SignInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        //-------------------------------------------------------------------------------------------------------------------------------------
        //ConfirmEmail
        public IActionResult Confirm()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(string Token, string Email)
        {
            var account = await UserManager.FindByIdAsync(Token);
            if (account != null)
            {
                if (account.Email == Email)
                {
                    account.EmailConfirmed = true;
                    await UserManager.UpdateAsync(account);


                    List<Claim> Claims = new List<Claim>();

                    var existingCustomer = await CustomerRepository.GetByAccountIdAsync(account.Id);
                    if (existingCustomer != null)
                    {
                        Claims.Add(new Claim("Role", "Customer"));
                        Claims.Add(new Claim("AccountId", account.Id));
                        Claims.Add(new Claim("UserId", existingCustomer.Id.ToString()));
                        Claims.Add(new Claim("FName", existingCustomer.FirstName));
                    }

                    await SignInManager.SignInWithClaimsAsync(account, isPersistent: false, Claims);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Error");

        }

        public IActionResult ResendConfirmationEmail()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResendConfirmationEmail(EmailFormViewModel emailFormViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var account = await UserManager.FindByEmailAsync(emailFormViewModel.Email);
                    if (account == null)
                    {
                        ModelState.AddModelError("", "Email doesn't Exist.");
                    }
                    else if (account.EmailConfirmed)
                    {
                        ModelState.AddModelError("", "Email is already confirmed.");
                    }
                    else
                    {
                        string confirmationLink = Url.Action("ConfirmEmail", "Account", new { Token = account.Id, Email = account.Email }, Request.Scheme);

                        string emailBody = $@"
                                    Dear {account.Email},<br/>
                                    Thank you for your registration.<br/>
                                    Please click on the below link to complete your registration:<br/>
                                    <a href='{confirmationLink}'>Confirm Email</a>";

                        EmailViewModel emailViewModel = new EmailViewModel
                        {
                            To = account.Email,
                            Subject = "Email Confirmation",
                            Body = emailBody
                        };

                        bool isEmailSent = EmailService.SendEmail(emailViewModel);

                        if (!isEmailSent)
                        {
                            ModelState.AddModelError("", "Failed to send confirmation email. Please try again.");
                            return View(emailFormViewModel);
                        }

                        return RedirectToAction("Confirm", "Account");
                    }
                }
                return View(emailFormViewModel);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred. Please try again.");
                return View(emailFormViewModel);
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------
        //ResetPassword
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(EmailFormViewModel emailFormViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var account = await UserManager.FindByEmailAsync(emailFormViewModel.Email);
                    if (account == null)
                    {
                        ModelState.AddModelError("", "Email doesn't Exist.");
                    }
                    else if (!account.EmailConfirmed)
                    {
                        ModelState.AddModelError("", "Confirm Email Address.");
                    }
                    else
                    {
                        string code = await UserManager.GeneratePasswordResetTokenAsync(account);

                        string callbackUrl = Url.Action("ResetPassword", "Account", new { userId = account.Id, code = code }, Request.Scheme);

                        string emailBody = $@"
                        <p>Please reset your password by clicking the link below:</p>
                        <p><a href='{callbackUrl}'>Reset Password</a></p>";

                        EmailViewModel emailViewModel = new EmailViewModel
                        {
                            To = emailFormViewModel.Email,
                            Subject = "Reset Your Password",
                            Body = emailBody
                        };

                        bool isEmailSent = EmailService.SendEmail(emailViewModel);

                        if (!isEmailSent)
                        {
                            ModelState.AddModelError("", "Failed to send reset password confirmation email. Please try again.");
                            return View(emailFormViewModel);
                        }

                        return RedirectToAction("ForgotPasswordConfirmation", "Account");
                    }
                }
                return View(emailFormViewModel);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred. Please try again.");
                return View(emailFormViewModel);
            }
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        public async Task<IActionResult> ResetPassword(string userId, string code)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
            {
                return View("Error");
            }
            var account = await UserManager.FindByIdAsync(userId);
            if (account != null)
            {
                var resetPasswordViewModel = account.ResetPasswordVM();
                resetPasswordViewModel.Code = code;
                return View(resetPasswordViewModel);
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var account = await UserManager.FindByEmailAsync(resetPasswordViewModel.Email);
                if (account == null)
                {
                    return View("Error");
                }
                var result = await UserManager.ResetPasswordAsync(account, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("", errorItem.Description);
                    }
                }
            }

            return View(resetPasswordViewModel);
        }


        //-------------------------------------------------------------------------------------------------------------------------------------
        //Google
        public IActionResult ExternalLogin(string provider, string returnUrl = "")
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });

            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "", string remoteError = "")
        {
            try
            {

                var loginUserViewModel = new LoginUserViewModel()
                {
                    Schemes = await SignInManager.GetExternalAuthenticationSchemesAsync()
                };

                if (!string.IsNullOrEmpty(remoteError))
                {
                    ModelState.AddModelError("", $"Error from extranal login provide: {remoteError}");
                    return View("Login", loginUserViewModel);
                }

                //Get login info
                var info = await SignInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    ModelState.AddModelError("", $"Error from extranal login provide: {remoteError}");
                    return View("Login", loginUserViewModel);
                }

                var signInResult = await SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
                    var name = info.Principal.FindFirstValue(ClaimTypes.Name);

                    if (!string.IsNullOrEmpty(userEmail))
                    {
                        var account = await UserManager.FindByEmailAsync(userEmail);

                        if (account == null)
                        {
                            account = new Account()
                            {
                                UserName = userEmail,
                                Email = userEmail,
                                EmailConfirmed = true
                            };

                            var identityResult = await UserManager.CreateAsync(account);

                            if (identityResult.Succeeded)
                            {
                                identityResult = await UserManager.AddToRoleAsync(account, "Customer");
                                if (!identityResult.Succeeded)
                                {
                                    foreach (var errorItem in identityResult.Errors)
                                    {
                                        ModelState.AddModelError("", errorItem.Description);
                                    }
                                    return View("Login", loginUserViewModel);
                                }
                                else
                                {
                                    var customer = new Customer()
                                    {
                                        FirstName = name
                                    };
                                    customer.AccountId = account.Id;
                                    customer = await CustomerRepository.CreateAsync(customer);

                                    Cart cart = new Cart()
                                    {
                                        TotalPrice = 0,
                                        IsDeleted = false,
                                        CustomerId = customer.Id
                                    };

                                    await CartRepository.CreateAsync(cart);
                                }
                            }
                            else
                            {
                                foreach (var errorItem in identityResult.Errors)
                                {
                                    ModelState.AddModelError("", errorItem.Description);
                                }
                                return View("Login", loginUserViewModel);
                            }

                        }

                        List<Claim> Claims = new List<Claim>();

                        var existingCustomer = await CustomerRepository.GetByAccountIdAsync(account.Id);
                        if (existingCustomer != null)
                        {
                            Claims.Add(new Claim("Role", "Customer"));
                            Claims.Add(new Claim("AccountId", account.Id));
                            Claims.Add(new Claim("UserId", existingCustomer.Id.ToString()));
                            Claims.Add(new Claim("FName", existingCustomer.FirstName));
                        }

                        await SignInManager.SignInWithClaimsAsync(account, isPersistent: false, Claims);

                        return RedirectToAction("Index", "Home");
                    }

                }

                ModelState.AddModelError("", $"Something went wrong");
                return View("Login", loginUserViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login");
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------
        //AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
