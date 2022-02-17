using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersRepo _customers;
        private readonly IMembershipTypesRepo _membershipTypes;

        public CustomersController(ICustomersRepo customers, IMembershipTypesRepo membersipTypes)
        {
            _customers = customers;
            _membershipTypes = membersipTypes;
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Owner, StoreManager")]
        public ViewResult Index()
        {
            var customers = _customers.GetAllCustomers();
            return View(customers);
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Owner, StoreManager")]
        public IActionResult Details(int id)
        {
            var customer = _customers.GetCustomerById(id);

            if (customer == null)
            {
                return Content("User not found");
            }

            return View(customer);
        }

        public IActionResult New()
        {
            var membershipTypes = _membershipTypes.GetAllMembershipTypes();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Owner")]
        public IActionResult Edit(int id)
        {
            var customer = _customers.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _membershipTypes.GetAllMembershipTypes()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _membershipTypes.GetAllMembershipTypes()
                };

                return View("CustomerForm", viewModel);

            }
            if (customer.Id == 0)
            {
                _customers.AddCustomer(customer);
            }
            else
            {
                var customerInDb = _customers.GetCustomerById(customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.HasNewsletterSubscribed = customer.HasNewsletterSubscribed;
            }

            try
            {
                _customers.Save();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Customers");
        }
    }
}