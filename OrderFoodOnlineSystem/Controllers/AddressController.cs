using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.Services;
using OrderFoodOnlineSystem.ViewModels.AddressViewModel;
using OrderFoodOnlineSystem.ViewModels.MenuItemViewModel;

namespace OrderFoodOnlineSystem.Controllers
{
    [Authorize(Roles = "Customer")]
    public class AddressController : Controller
    {
        public IAddressRepository _addressRepository { get; }
        public OrderFoodDbContext _context { get; }

        public AddressController(IAddressRepository addressRepository, OrderFoodDbContext context)
        {
            _addressRepository = addressRepository;
            _context = context;
        }

        public async Task<ActionResult> Index(string? viewName)
        {
            int cusId = 0;
            int.TryParse(User?.FindFirst("UserId")?.Value, out cusId);

            var addresses = await _addressRepository.GetAllByCustomerAsync(cusId);

            if(viewName!=null && viewName.Equals("IndexAddress"))
                return View("IndexAddress", addresses);

            return View(addresses);
        }

        public async Task<ActionResult> Details(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address != null)
            {
                return View(address);
            }
            return NotFound("Address not found!");
        }

        public async Task<ActionResult> Create(string? viewName)
        {
            if (viewName != null && viewName.Equals("IndexAddress"))
                return View("CreateAddress");
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAddressViewModel createAddressViewModel, string? viewName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var address = createAddressViewModel.AddAddressVM();

                    int cusId = 0;
                    int.TryParse(User?.FindFirst("UserId")?.Value, out cusId);

                    address.CustomerId = cusId;

                    await _addressRepository.CreateAsync(address);

                    if (viewName != null && viewName.Equals("IndexAddress"))
                        return RedirectToAction(nameof(Index),new { viewName = "IndexAddress" });

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(createAddressViewModel);
            }
            catch
            {
                return View(createAddressViewModel);
            }
        }

        public async Task<ActionResult> Edit(int id, string? viewName)
        {
            var address = await _addressRepository.GetByIdAsync(id);

            if (address == null)
                return NotFound();

            var editAddressVM = address.EditAddressVM();

            if (viewName != null && viewName.Equals("IndexAddress"))
                return View("EditAddress", editAddressVM);

            return View(editAddressVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditAddressViewModel editAddressViewModel, string? viewName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var addressModel = await _addressRepository.GetByIdAsync(id);
                    if (addressModel == null)
                        return NotFound();

                    var addressVM = editAddressViewModel.EditAddressVM();
                    var editedAddress = await _addressRepository.UpdateAsync(id, addressVM);

                    if (editedAddress != null)
                    {
                        if (viewName != null && viewName.Equals("IndexAddress"))
                            return RedirectToAction(nameof(Index), new { viewName = "IndexAddress" });

                        return RedirectToAction(nameof(Index));
                    }
                    else
                        return NotFound("Address not found!");
                }
                else
                {
                    if (viewName.Equals("IndexAddress"))
                        return View("EditAddress", editAddressViewModel);

                    return View(editAddressViewModel);
                }
            }
            catch
            {
                if (viewName.Equals("IndexAddress"))
                    return View("EditAddress", editAddressViewModel);

                return View(editAddressViewModel);
            }
        }

        
        public async Task<ActionResult> Delete(int id, string? viewName)
        {
            try
            {
                var address = await _addressRepository.GetByIdAsync(id);
                if (address == null)
                    return NotFound();
                else
                {
                    address = await _addressRepository.DeleteAsync(address.Id);

                    if (viewName != null && viewName.Equals("IndexAddress"))
                        return RedirectToAction(nameof(Index), new { viewName = "IndexAddress" });

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
