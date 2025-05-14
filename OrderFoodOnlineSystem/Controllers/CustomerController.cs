using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.ViewModels.AdminViewModels;
using OrderFoodOnlineSystem.ViewModels.CustomerViewModels;
using System.Security.Claims;
using System.Transactions;

namespace OrderFoodOnlineSystem.Controllers
{
    public class CustomerController : Controller
    {
        public IMapper Mapper { get; }
        public ICustomerRepository CustomerRepository { get; }
        public UserManager<Account> UserManager { get; }
        public SignInManager<Account> SignInManager { get; }

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository,
            UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            Mapper = mapper;
            CustomerRepository = customerRepository;
            UserManager = userManager;
            SignInManager = signInManager;
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var customersModel = await CustomerRepository.GetAllAsync();
            var customersVM = customersModel.CustomersInfo();

            return View(customersVM);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var customerModel = await CustomerRepository.GetByIdAsync(id);
            if (customerModel == null)
            {
                return NotFound();
            }
            var customerVM = customerModel.CustomerInfo();

            return View(customerVM);
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit()
        {
            int cusId = 0;
            int.TryParse(User?.FindFirst("UserId")?.Value, out cusId);

            var customerModel = await CustomerRepository.GetByIdAsync(cusId);
            if (customerModel == null)
            {
                return NotFound();
            }
            var updateCustomerVM = customerModel.UpdateCustomer();
            return View(updateCustomerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int id, UpdateCustomerViewModel updateCustomerViewModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var customerModel = updateCustomerViewModel.UpdateCustomer();

                        customerModel = await CustomerRepository.UpdateAsync(id, customerModel);
                        if (customerModel == null)
                        {
                            transactionScope.Dispose();
                            return NotFound();
                        }

                        var existingAccount = await UserManager.FindByIdAsync(customerModel.AccountId);
                        if (existingAccount == null)
                        {
                            transactionScope.Dispose();
                            return NotFound();
                        }

                        existingAccount.Email = updateCustomerViewModel.Email;

                        if (string.IsNullOrWhiteSpace(updateCustomerViewModel.CurrentPassword) &&
                            !string.IsNullOrWhiteSpace(updateCustomerViewModel.NewPassword))
                        {
                            transactionScope.Dispose();
                            ModelState.AddModelError("", "You must enter your current password to set a new one.");
                            return View(updateCustomerViewModel);
                        }

                        if (!string.IsNullOrWhiteSpace(updateCustomerViewModel.CurrentPassword) &&
                        !string.IsNullOrWhiteSpace(updateCustomerViewModel.NewPassword))
                        {
                            bool isCurrentPasswordValid = await UserManager.CheckPasswordAsync(existingAccount, updateCustomerViewModel.CurrentPassword);

                            if (!isCurrentPasswordValid)
                            {
                                transactionScope.Dispose();
                                ModelState.AddModelError("", "Current password is incorrect.");
                                return View(updateCustomerViewModel);
                            }

                            var token = await UserManager.GeneratePasswordResetTokenAsync(existingAccount);
                            var passwordResult = await UserManager.ResetPasswordAsync(existingAccount, token, updateCustomerViewModel.NewPassword);

                            if (!passwordResult.Succeeded)
                            {
                                transactionScope.Dispose();
                                foreach (var errorItem in passwordResult.Errors)
                                {
                                    ModelState.AddModelError("", errorItem.Description);
                                }
                                return View(updateCustomerViewModel);
                            }
                        }

                        var updateResult = await UserManager.UpdateAsync(existingAccount);

                        if (updateResult.Succeeded)
                        {
                            await SignInManager.SignOutAsync();
                            List<Claim> Claims = new List<Claim>();

                            Claims.Add(new Claim("Role", "Customer"));
                            Claims.Add(new Claim("AccountId", existingAccount.Id));
                            Claims.Add(new Claim("UserId", customerModel.Id.ToString()));
                            Claims.Add(new Claim("FName", customerModel.FirstName));

                            await SignInManager.SignInWithClaimsAsync(existingAccount, true, Claims);

                            transactionScope.Complete();
                            return RedirectToAction("Index", "Home");
                        }
                        foreach (var errorItem in updateResult.Errors)
                        {
                            ModelState.AddModelError("", errorItem.Description);
                        }
                    }

                    transactionScope.Dispose();
                    return View(updateCustomerViewModel);
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    ModelState.AddModelError("", "An error occurred. Please try again.");
                    return View(updateCustomerViewModel);
                }
            }
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Delete()
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    int cusId = 0;
                    int.TryParse(User?.FindFirst("UserId")?.Value, out cusId);

                    var customerModel = await CustomerRepository.GetByIdAsync(cusId);
                    if (customerModel == null)
                    {
                        transactionScope.Dispose();
                        return NotFound();
                    }
                    else
                    {
                        var deleteResult = await UserManager.DeleteAsync(customerModel.Account);
                        if (!deleteResult.Succeeded)
                        {
                            transactionScope.Dispose();
                            return View("Error");
                        }
                        else
                        {
                            customerModel = await CustomerRepository.DeleteAsync(cusId);
                            if (customerModel == null)
                            {
                                transactionScope.Dispose();
                                return NotFound();
                            }
                        }
                    }
                    await SignInManager.SignOutAsync();
                    transactionScope.Complete();
                    return RedirectToAction("Login", "Account");
                }
                catch
                {
                    transactionScope.Dispose();
                    return View("Error");
                }
            }

        }

    }
}

