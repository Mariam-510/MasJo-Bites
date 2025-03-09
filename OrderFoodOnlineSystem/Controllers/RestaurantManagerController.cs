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
using OrderFoodOnlineSystem.ViewModels.CustomerViewModels;
using OrderFoodOnlineSystem.ViewModels.RestaurantManagerViewModels;
using System.Security.Claims;
using System.Transactions;

namespace OrderFoodOnlineSystem.Controllers
{
    public class RestaurantManagerController : Controller
    {
        public IMapper Mapper { get; }
        public IRestaurantManagerRepository RestaurantManagerRepository { get; }
        public UserManager<Account> UserManager { get; }
        public SignInManager<Account> SignInManager { get; }
        public IOrderRepository OrderRepository { get; }

        public RestaurantManagerController(IMapper mapper, IRestaurantManagerRepository restaurantManagerRepository,
            UserManager<Account> userManager, SignInManager<Account> signInManager,
            IOrderRepository orderRepository)
        {
            Mapper = mapper;
            RestaurantManagerRepository = restaurantManagerRepository;
            UserManager = userManager;
            SignInManager = signInManager;
            OrderRepository = orderRepository;
        }


        // GET: RestaurantManagerController
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var restaurantManagersModel = await RestaurantManagerRepository.GetAllAsync();
            var restaurantManagersVM = restaurantManagersModel.RestaurantManagersInfo();

            return View(restaurantManagersVM);
        }

        // GET: RestaurantManagerController/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var restaurantManagerModel = await RestaurantManagerRepository.GetByIdAsync(id);
            if (restaurantManagerModel == null)
            {
                return NotFound();
            }
            var restaurantManagerVM = restaurantManagerModel.RestaurantManagerInfo();

            return View(restaurantManagerVM);
        }

        // GET: RestaurantManagerController/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            string AdminIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(AdminIdStr, out int adminId))
            {
                return Unauthorized("Admin not found.");
            }

            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateRestaurantManagerViewModel createRestaurantManagerViewModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var existingUser = await UserManager.FindByEmailAsync(createRestaurantManagerViewModel.Email);
                        if (existingUser != null)
                        {
                            ModelState.AddModelError("", "Email already exists.");
                            return View(createRestaurantManagerViewModel);
                        }

                        var account = createRestaurantManagerViewModel.RegisterRestaurantManager();

                        account.EmailConfirmed = true;

                        var identityResult = await UserManager.CreateAsync(account, createRestaurantManagerViewModel.Password);

                        if (identityResult.Succeeded)
                        {
                            identityResult = await UserManager.AddToRoleAsync(account, "RestaurantManager");
                            if (identityResult.Succeeded)
                            {
                                var restaurantManager = createRestaurantManagerViewModel.CreateRestaurantManager();
                                restaurantManager.AccountId = account.Id;
                                restaurantManager = await RestaurantManagerRepository.CreateAsync(restaurantManager);

                                transactionScope.Complete();
                                return RedirectToAction("Index", "Restaurant");
                            }
                        }
                        foreach (var errorItem in identityResult.Errors)
                        {
                            ModelState.AddModelError("", errorItem.Description);
                        }
                    }
                    transactionScope.Dispose();
                    return View(createRestaurantManagerViewModel);
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    ModelState.AddModelError("", "An error occurred. Please try again.");
                    return View(createRestaurantManagerViewModel);
                }
            }

        }

        //GET: RestaurantManagerController/Edit/5
        [Authorize(Roles = "RestaurantManager")]
        public async Task<IActionResult> Edit()
        {
            string ManagerIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(ManagerIdStr, out int managerId))
            {
                return Unauthorized("Manager not found.");
            }

            var restaurantManagerModel = await RestaurantManagerRepository.GetByIdAsync(managerId);
            if (restaurantManagerModel == null)
            {
                return NotFound();
            }
            var updateRestaurantManagerVM = restaurantManagerModel.UpdateRestaurantManager();
            return View(updateRestaurantManagerVM);
        }

        // POST: RestaurantManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "RestaurantManager")]
        public async Task<IActionResult> Edit(int id, UpdateRestaurantManagerViewModel updateRestaurantManagerViewModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var restaurantManagerModel = updateRestaurantManagerViewModel.UpdateRestaurantManager();

                        restaurantManagerModel = await RestaurantManagerRepository.UpdateAsync(id, restaurantManagerModel);
                        if (restaurantManagerModel == null)
                        {
                            transactionScope.Dispose();
                            return NotFound();
                        }

                        var existingAccount = await UserManager.FindByIdAsync(restaurantManagerModel.AccountId);
                        if (existingAccount == null)
                        {
                            transactionScope.Dispose();
                            return NotFound();
                        }

                        existingAccount.Email = updateRestaurantManagerViewModel.Email;

                        if (string.IsNullOrWhiteSpace(updateRestaurantManagerViewModel.CurrentPassword) &&
                            !string.IsNullOrWhiteSpace(updateRestaurantManagerViewModel.NewPassword))
                        {
                            transactionScope.Dispose();
                            ModelState.AddModelError("", "You must enter your current password to set a new one.");
                            return View(updateRestaurantManagerViewModel);
                        }

                        if (!string.IsNullOrWhiteSpace(updateRestaurantManagerViewModel.CurrentPassword) &&
                        !string.IsNullOrWhiteSpace(updateRestaurantManagerViewModel.NewPassword))
                        {
                            bool isCurrentPasswordValid = await UserManager.CheckPasswordAsync(existingAccount, updateRestaurantManagerViewModel.CurrentPassword);

                            if (!isCurrentPasswordValid)
                            {
                                transactionScope.Dispose();
                                ModelState.AddModelError("", "Current password is incorrect.");
                                return View(updateRestaurantManagerViewModel);
                            }

                            var token = await UserManager.GeneratePasswordResetTokenAsync(existingAccount);
                            var passwordResult = await UserManager.ResetPasswordAsync(existingAccount, token, updateRestaurantManagerViewModel.NewPassword);

                            if (!passwordResult.Succeeded)
                            {
                                transactionScope.Dispose();
                                foreach (var errorItem in passwordResult.Errors)
                                {
                                    ModelState.AddModelError("", errorItem.Description);
                                }
                                return View(updateRestaurantManagerViewModel);
                            }
                        }

                        var updateResult = await UserManager.UpdateAsync(existingAccount);

                        if (updateResult.Succeeded)
                        {
                            await SignInManager.SignOutAsync();
                            List<Claim> Claims = new List<Claim>();

                            Claims.Add(new Claim("Role", "RestaurantManager"));
                            Claims.Add(new Claim("AccountId", existingAccount.Id));
                            Claims.Add(new Claim("UserId", restaurantManagerModel.Id.ToString()));
                            Claims.Add(new Claim("FName", restaurantManagerModel.Name));

                            await SignInManager.SignInWithClaimsAsync(existingAccount, true, Claims);

                            transactionScope.Complete();
                            return RedirectToAction("GetAllRestaurantOrders", "Order");
                        }
                        foreach (var errorItem in updateResult.Errors)
                        {
                            ModelState.AddModelError("", errorItem.Description);
                        }
                    }

                    transactionScope.Dispose();
                    return View(updateRestaurantManagerViewModel);
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    ModelState.AddModelError("", "An error occurred. Please try again.");
                    return View(updateRestaurantManagerViewModel);
                }
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete()
        {
            string AdminIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(AdminIdStr, out int adminId))
            {
                return Unauthorized("Admin not found.");
            }

            var restaurantManagers = await RestaurantManagerRepository.GetAllAsync();
            var viewModel = new DeleteRestaurantManagerViewModel
            {
                RestaurantManagers = restaurantManagers
                    .Select(m => new RestaurantManagerViewModel
                    {
                        Id = m.Id,
                        Name = m.Name,
                    }).ToList()
            };
            return View(viewModel);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(DeleteRestaurantManagerViewModel deleteRestaurantManagerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteRestaurantManagerViewModel);
            }

            if (deleteRestaurantManagerViewModel.RestaurantManagerId == 0)
            {
                ModelState.AddModelError("", "Invalid restaurant manager selected.");
                return View(deleteRestaurantManagerViewModel);
            }

            var restaurantManager = await RestaurantManagerRepository.GetByIdAsync(deleteRestaurantManagerViewModel.RestaurantManagerId);
            if (restaurantManager == null)
            {
                ModelState.AddModelError("", "Restaurant manager not found.");
                return View(deleteRestaurantManagerViewModel);
            }

            var deleteResult = await UserManager.DeleteAsync(restaurantManager.Account);
            if (!deleteResult.Succeeded)
            {
                foreach (var errorItem in deleteResult.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
                return View(deleteRestaurantManagerViewModel);
            }

            var deletedRestaurantManager = await RestaurantManagerRepository.DeleteAsync(deleteRestaurantManagerViewModel.RestaurantManagerId);
            if (deletedRestaurantManager == null)
            {
                ModelState.AddModelError("", "Failed to delete restaurant manager.");
                return View(deleteRestaurantManagerViewModel);
            }

            return RedirectToAction("Index", "Restaurant");
        }
    }
}
