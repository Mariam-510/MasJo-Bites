using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.ViewModels.AdminViewModels;
using OrderFoodOnlineSystem.ViewModels.CustomerViewModels;
using System.Security.Claims;
using System.Transactions;

namespace OrderFoodOnlineSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IMapper Mapper { get; }
        public IAdminRepository AdminRepository { get; }
        public UserManager<Account> UserManager { get; }
        public SignInManager<Account> SignInManager { get; }

        public AdminController(IMapper mapper, IAdminRepository adminRepository,
            UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            Mapper = mapper;
            AdminRepository = adminRepository;
            UserManager = userManager;
            SignInManager = signInManager;
        }
        

        public async Task<IActionResult> Index()
        {
            var adminsModel = await AdminRepository.GetAllAsync();
            var adminsVM = adminsModel.AdminsInfo();

            return View(adminsVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var adminModel = await AdminRepository.GetByIdAsync(id);
            if (adminModel == null)
            {
                return NotFound();
            }
            var adminVM = adminModel.AdminInfo();

            return View(adminVM);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAdminViewModel createAdminViewModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var existingUser = await UserManager.FindByEmailAsync(createAdminViewModel.Email);
                        if (existingUser != null)
                        {
                            ModelState.AddModelError("", "Email already exists.");
                            return View(createAdminViewModel);
                        }

                        var account = createAdminViewModel.RegisterAdmin();
                        
                        account.EmailConfirmed = true;

                        var identityResult = await UserManager.CreateAsync(account, createAdminViewModel.Password);

                        if (identityResult.Succeeded)
                        {
                            identityResult = await UserManager.AddToRoleAsync(account, "Admin");
                            if (identityResult.Succeeded)
                            {
                                var admin = createAdminViewModel.CreateAdmin();
                                admin.AccountId = account.Id;
                                admin = await AdminRepository.CreateAsync(admin);

                                transactionScope.Complete();
                                return RedirectToAction(nameof(Index));
                            }
                        }
                        foreach (var errorItem in identityResult.Errors)
                        {
                            ModelState.AddModelError("", errorItem.Description);
                        }
                    }
                    transactionScope.Dispose();
                    return View(createAdminViewModel);
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    ModelState.AddModelError("", "An error occurred. Please try again.");
                    return View(createAdminViewModel);
                }
            }
            
        }

        public async Task<IActionResult> Edit()
        {
            string AdminIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(AdminIdStr, out int adminId))
            {
                return Unauthorized("Admin not found.");
            }

            var adminModel = await AdminRepository.GetByIdAsync(adminId);
            if (adminModel == null)
            {
                return NotFound();
            }
            var updateAdminVM = adminModel.UpdateAdmin();
            return View(updateAdminVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateAdminViewModel updateAdminViewModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var adminModel = updateAdminViewModel.UpdateAdmin();

                        adminModel = await AdminRepository.UpdateAsync(id, adminModel);
                        if (adminModel == null)
                        {
                            transactionScope.Dispose();
                            return NotFound();
                        }

                        var existingAccount = await UserManager.FindByIdAsync(adminModel.AccountId);
                        if (existingAccount == null)
                        {
                            transactionScope.Dispose();
                            return NotFound();
                        }
                        existingAccount.Email = updateAdminViewModel.Email;

                        if (string.IsNullOrWhiteSpace(updateAdminViewModel.CurrentPassword) &&
                            !string.IsNullOrWhiteSpace(updateAdminViewModel.NewPassword))
                        {
                            transactionScope.Dispose();
                            ModelState.AddModelError("", "You must enter your current password to set a new one.");
                            return View(updateAdminViewModel);
                        }

                        if (!string.IsNullOrWhiteSpace(updateAdminViewModel.CurrentPassword) &&
                        !string.IsNullOrWhiteSpace(updateAdminViewModel.NewPassword))
                        {
                            bool isCurrentPasswordValid = await UserManager.CheckPasswordAsync(existingAccount, updateAdminViewModel.CurrentPassword);

                            if (!isCurrentPasswordValid)
                            {
                                transactionScope.Dispose();
                                ModelState.AddModelError("", "Current password is incorrect.");
                                return View(updateAdminViewModel);
                            }

                            var token = await UserManager.GeneratePasswordResetTokenAsync(existingAccount);
                            var passwordResult = await UserManager.ResetPasswordAsync(existingAccount, token, updateAdminViewModel.NewPassword);

                            if (!passwordResult.Succeeded)
                            {
                                transactionScope.Dispose();
                                foreach (var errorItem in passwordResult.Errors)
                                {
                                    ModelState.AddModelError("", errorItem.Description);
                                }
                                return View(updateAdminViewModel);
                            }
                        }

                        var updateResult = await UserManager.UpdateAsync(existingAccount);

                        if (updateResult.Succeeded)
                        {
                            await SignInManager.SignOutAsync();
                            List<Claim> Claims = new List<Claim>();

                            Claims.Add(new Claim("Role", "Admin"));
                            Claims.Add(new Claim("AccountId", existingAccount.Id));
                            Claims.Add(new Claim("UserId", adminModel.Id.ToString()));
                            Claims.Add(new Claim("FName", adminModel.Name));

                            await SignInManager.SignInWithClaimsAsync(existingAccount, true, Claims);

                            transactionScope.Complete();
                            return RedirectToAction("Index", "Restaurant");
                        }
                        foreach (var errorItem in updateResult.Errors)
                        {
                            ModelState.AddModelError("", errorItem.Description);
                        }
                    }

                    transactionScope.Dispose();
                    return View(updateAdminViewModel);
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    ModelState.AddModelError("", "An error occurred. Please try again.");
                    return View(updateAdminViewModel);
                }
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var adminModel = await AdminRepository.GetByIdAsync(id);
            if (adminModel == null)
            {
                return NotFound();
            }
            var adminVM = adminModel.AdminInfo();

            return View(adminVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AdminViewModel adminViewModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var adminModel = await AdminRepository.GetByIdAsync(id);
                    if (adminModel == null)
                    {
                        transactionScope.Dispose();
                        return NotFound();
                    }
                    else
                    {
                        var deleteResult = await UserManager.DeleteAsync(adminModel.Account);
                        if (!deleteResult.Succeeded)
                        {
                            transactionScope.Dispose();
                            foreach (var errorItem in deleteResult.Errors)
                            {
                                ModelState.AddModelError("", errorItem.Description);
                            }
                            return View(adminViewModel);
                        }
                        else
                        {
                            adminModel = await AdminRepository.DeleteAsync(id);
                            if (adminModel == null)
                            {
                                transactionScope.Dispose();
                                return NotFound();
                            }
                        }
                    }
                    transactionScope.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    transactionScope.Dispose();
                    ModelState.AddModelError("", "An error occurred. Please try again.");
                    return View(adminViewModel);
                }
            }
                
        }
    
    }
}
