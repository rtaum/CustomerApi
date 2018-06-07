using CustomerApi.Models;
using CustomerApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CustomerApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository _customersRepository;

        public CustomersController (ICustomerRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var customers = _customersRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(Guid id)
        {
            var customer = _customersRepository.GetCustomer(id);
            return Ok(customer);
        }

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _customersRepository.AddCustomer(customer);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Customer customer)
        {
            customer.Id = id;
            _customersRepository.UpdateCustomer(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _customersRepository.RemoveCustomer(id);
        }
    }
}
