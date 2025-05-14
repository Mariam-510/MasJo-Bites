using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;
using System.Net;

namespace OrderFoodOnlineSystem.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public OrderFoodDbContext _context { get; }

        public AddressRepository(OrderFoodDbContext context) 
        {
            _context = context;
        }

        public Task<List<Address>> GetAllAsync()
        {
            return _context.Addresses
                .Include(a => a.Customer)
                .Where(a => a.IsDeleted == false)
                .ToListAsync();
        }

        public Task<List<Address>> GetAllByCustomerAsync(int customerId)
        {
            return _context.Addresses
                .Include(a => a.Customer)
                .Where(a => a.IsDeleted == false && a.CustomerId==customerId)
                .OrderByDescending(a=>a.Id)
                .ToListAsync();
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await _context.Addresses
                .Include(a => a.Customer)
                .Where(a => a.IsDeleted == false)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Address?> CreateAsync(Address Address)
        {
            if (Address != null)
            {
                _context.Addresses.Add(Address);
                await _context.SaveChangesAsync();
                return Address;
            }
            return null;
        }

        public async Task<Address?> UpdateAsync(int id, Address Address)
        {
            var updatedAddress = await GetByIdAsync(id);

            if (updatedAddress != null)
            {
                updatedAddress.City = Address.City;
                updatedAddress.Street = Address.Street;
                updatedAddress.BuildingNum = Address.BuildingNum;
                updatedAddress.Apartment = Address.Apartment;
                updatedAddress.Floor = Address.Floor;
                updatedAddress.PhoneNum = Address.PhoneNum;

                await _context.SaveChangesAsync();
                return updatedAddress;
            }
            else
                return null;
        }

        public async Task<Address?> DeleteAsync(int id)
        {
            var deletedAdd = await GetByIdAsync(id);

            if (deletedAdd != null)
            {
                deletedAdd.IsDeleted = true;
                await _context.SaveChangesAsync();
                return deletedAdd;
            }
            return null;
        }
    }
}
