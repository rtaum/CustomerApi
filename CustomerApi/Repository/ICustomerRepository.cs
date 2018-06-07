using CustomerApi.Models;
using System;
using System.Collections.Generic;

namespace CustomerApi.Repository
{
    public interface ICustomerRepository
    {
        Customer AddCustomer(Customer customer);

        IEnumerable<Customer> GetAllCustomers();

        Customer GetCustomer(Guid id);

        void UpdateCustomer(Customer customer);

        void RemoveCustomer(Guid id);
    }
}
