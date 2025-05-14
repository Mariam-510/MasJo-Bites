using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.Services;
using OrderFoodOnlineSystem.ViewModels.MenuItemViewModel;

namespace OrderFoodOnlineSystem.Controllers
{
    [Authorize(Roles = "RestaurantManager")]
    public class MenuItemController : Controller
    {
        public IMenuItemRepository _menuItemRepository { get; }
        public IRestaurantRepository RestaurantRepository { get; }
        public IRestaurantCategoryRepository RestaurantCategoryRepository { get; }
        public FileService _fileService { get; }

        public MenuItemController(IMenuItemRepository menuItemRepository, IRestaurantRepository restaurantRepository,
            IRestaurantCategoryRepository restaurantCategoryRepository, FileService fileService)
        {
            _menuItemRepository = menuItemRepository;
            RestaurantRepository = restaurantRepository;
            RestaurantCategoryRepository = restaurantCategoryRepository;
            _fileService = fileService;
        }

        public async Task<ActionResult> Index()
        {
            string ManagerIdStr = User.FindFirst("UserId")?.Value;

            if (!int.TryParse(ManagerIdStr, out int managerId))
            {
                return Unauthorized("Manager not found.");
            }
            var restaurant = await RestaurantRepository.GetByManagerIdAsync(managerId);
            if (restaurant != null)
            {
                var categories = await RestaurantCategoryRepository.GetAllCategoriesByRestaurantAsync(restaurant.Id);
                ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            }
            else
            {
                return NotFound();
            }

            var menuItems = await _menuItemRepository.GetAllByRestaurantAsync(restaurant.Id);
            return View(menuItems);
        }

        public async Task<ActionResult> Create()
        {
            string ManagerIdStr = User.FindFirst("UserId")?.Value;

            if (!int.TryParse(ManagerIdStr, out int managerId))
            {
                return Unauthorized("Manager not found.");
            }
            var restaurant = await RestaurantRepository.GetByManagerIdAsync(managerId);
            if (restaurant != null)
            {
                var categories = await RestaurantCategoryRepository.GetAllCategoriesByRestaurantAsync(restaurant.Id);
                ViewBag.CategoryId = new SelectList(categories, "Id", "Name");   
            }
            else
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMenuItemViewModel createMenuItemViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string ManagerIdStr = User.FindFirst("UserId")?.Value;

                    if (!int.TryParse(ManagerIdStr, out int managerId))
                    {
                        return Unauthorized("Manager not found.");
                    }
                    var restaurant = await RestaurantRepository.GetByManagerIdAsync(managerId);
                    if (restaurant != null)
                    {
                        var categories = await RestaurantCategoryRepository.GetAllCategoriesByRestaurantAsync(restaurant.Id);
                        ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
                    }
                    else
                    {
                        return NotFound();
                    }

                    var menuItem = createMenuItemViewModel.AddMenuItemVM();

                    menuItem.RestaurantId = restaurant.Id;

                    menuItem.ImageUrl = _fileService.UploadFile("MenuItemImages", createMenuItemViewModel.ImageFile);

                    await _menuItemRepository.CreateAsync(menuItem);
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(createMenuItemViewModel);
            }
            catch
            {
                return View(createMenuItemViewModel);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);

            if (menuItem == null)
                return NotFound();

            var categories = await RestaurantCategoryRepository.GetAllCategoriesByRestaurantAsync(menuItem.RestaurantId ?? 0);

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", menuItem.CategoryId);

            var editMenuItemVM = menuItem.EditMenuItemVM();

            return View(editMenuItemVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditMenuItemViewModel editMenuItemViewModel)
        {
            try
            {
                var menuItem = await _menuItemRepository.GetByIdAsync(id);

                if (menuItem == null)
                    return NotFound();

                var categories = await RestaurantCategoryRepository.GetAllCategoriesByRestaurantAsync(menuItem.RestaurantId ?? 0);

                ViewBag.CategoryId = new SelectList(categories, "Id", "Name", menuItem.CategoryId);

                if (ModelState.IsValid)
                {
                    var menuItemModel = editMenuItemViewModel.EditMenuItemVM();

                    if (editMenuItemViewModel.ImageFile != null)
                        menuItemModel.ImageUrl = _fileService.UpdateFile("MenuItemImages", editMenuItemViewModel.ImageFile, menuItem.ImageUrl);
                    else
                        menuItemModel.ImageUrl = menuItem.ImageUrl;
                    
                    var editedMenuItem = await _menuItemRepository.UpdateAsync(id, menuItemModel);
                    
                    if (editedMenuItem != null)
                        return RedirectToAction(nameof(Index));
                    else
                        return NotFound("Menu Item not found!");
                }
                else
                    return View(editMenuItemViewModel);
            }
            catch
            {
                return View(editMenuItemViewModel);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var menuItem = await _menuItemRepository.GetByIdAsync(id);

                if (menuItem == null)
                    return NotFound();
                else
                {
                    menuItem = await _menuItemRepository.DeleteAsync(menuItem.Id);

                    _fileService.DeleteFile(menuItem.ImageUrl);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
