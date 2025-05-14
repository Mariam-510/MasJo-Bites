using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderFoodDbContext dbContext;
        public CustomerRepository(OrderFoodDbContext dbontext)
        {
            this.dbContext = dbontext;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await dbContext.Customers
                .Include(c=>c.Account)
                .Where(c=>!c.IsDeleted)
                //.OrderBy(c=>c.FirstName)
                //.ThenBy(c=>c.LastName)
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await dbContext.Customers
                .Include(c => c.Account)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> GetByAccountIdAsync(string accountId)
        {
            return await dbContext.Customers
                .Include(c => c.Account)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Account.Id == accountId);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await dbContext.Customers
                .Include(c => c.Account)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingCustomer == null)
            {
                return null;
            }
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            //existingCustomer.Gender = customer.Gender;

            await dbContext.SaveChangesAsync();
            return existingCustomer;
        }

        public async Task<Customer?> DeleteAsync(int id)
        {
            var existingCustomer = await dbContext.Customers
                .Include(c => c.Account)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingCustomer == null)
            {
                return null;
            }
            existingCustomer.IsDeleted = true;
            existingCustomer.AccountId = null;

            await dbContext.SaveChangesAsync();
            return existingCustomer;
        }
    
    }
}
