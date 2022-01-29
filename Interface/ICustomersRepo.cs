using System.Collections.Generic;
using System.Threading.Tasks;
using LibApp.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibApp.Data
{
    public interface ICustomersRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Task<Customer> GetAsyncCustomerById(int id);
        EntityEntry<Customer> AddCustomer(Customer customer);
        EntityEntry<Customer> RemoveCustomer(Customer customer);
        int Save();
    }
}