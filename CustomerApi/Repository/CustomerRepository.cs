using CustomerApi.Database;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerApi.Repository
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private CustomerContext _context;

        public CustomerRepository()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
                .UseInMemoryDatabase(databaseName: "CustomersDatabase")
                .Options;

            _context = new CustomerContext(options);
        }

        public Customer AddCustomer(Customer customer)
        {
            var newCustomer = _context.Customers.Add(customer);
            _context.SaveChanges();

            return newCustomer.Entity;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers;
        }

        public Customer GetCustomer(Guid id)
        {
            return FindCustomer(id);
        }

        public void RemoveCustomer(Guid id)
        {
            var customer = FindCustomer(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        private Customer FindCustomer(Guid id)
        {
            return _context.
                Customers.
                Where(c => c.Id == id).
                FirstOrDefault();
        }
    }
}
