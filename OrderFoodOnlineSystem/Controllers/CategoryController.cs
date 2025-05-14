using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.Services;
using OrderFoodOnlineSystem.ViewModels.CategoryViewModel;
using OrderFoodOnlineSystem.ViewModels.MenuItemViewModel;

namespace OrderFoodOnlineSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        public ICategoryRepository _categoryRepository { get; }
        public FileService _fileService { get; }

        public CategoryController(ICategoryRepository categoryRepository, FileService fileService)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            string AdminIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(AdminIdStr, out int adminId))
            {
                return Unauthorized("Admin not found.");
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCategoryViewModel createCategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = createCategoryViewModel.AddCategoryVM();
                    category.ImageUrl = _fileService.UploadFile("CategoryImages", createCategoryViewModel.ImageFile);
                    if (category.ImageUrl != null)
                    {
                        await _categoryRepository.CreateAsync(category);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                        return View(createCategoryViewModel);
                }
                else
                    return View(createCategoryViewModel);
            }
            catch
            {
                return View(createCategoryViewModel);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            var editCategoryVM = category.EditCategoryVM();

            return View(editCategoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<ActionResult> Edit(int id, EditCategoryViewModel editCategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoryModel = await _categoryRepository.GetByIdAsync(id);
                    var categoryVM = editCategoryViewModel.EditCategoryVM();
                    categoryVM.ImageUrl = _fileService.UpdateFile("CategoryImages", editCategoryViewModel.ImageFile, categoryModel.ImageUrl);
                    if (categoryVM.ImageUrl != null)
                    {
                        await _categoryRepository.UpdateAsync(id, categoryVM);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                        return View(editCategoryViewModel);
                }
                else
                    return View(editCategoryViewModel);
            }
            catch
            {
                return View(editCategoryViewModel);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            string AdminIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(AdminIdStr, out int adminId))
            {
                return Unauthorized("Admin not found.");
            }
            var category = await _categoryRepository.DeleteAsync(id);
            
            if (category == null)
                return NotFound();
            _fileService.DeleteFile(category.ImageUrl);

            return RedirectToAction(nameof(Index));
        }
    }
}
