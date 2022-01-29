using System.Collections.Generic;
using LibApp.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibApp.Data
{
    public interface ICustomersRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        EntityEntry<Customer> AddCustomer(Customer customer);
        int Save();
    }
}