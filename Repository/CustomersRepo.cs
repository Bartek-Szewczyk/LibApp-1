﻿using System.Collections.Generic;
using System.Linq;
using LibApp.Data;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibApp.Profiles
{
    public class CustomersRepo : ICustomersRepo
    {
        private readonly ApplicationDbContext _context;

        public CustomersRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList();
        }

        public Customer GetCustomerById(int id)
        {
           return _context.Customers.Include(c => c.MembershipType)
               .SingleOrDefault(c => c.Id == id);
        }

        public EntityEntry<Customer> AddCustomer(Customer customer)
        {
            return _context.Customers.Add(customer);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}