using CustomerApi.Controllers;
using CustomerApi.Models;
using CustomerApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CustomerApi.Test
{
    public class UnitTestCustomersController
    {
        [Fact]
        public void GetAllCustomers()
        {
            var customers = new Customer[]
            {
                new Customer(),
                new Customer()
            };
            var repository = new Mock<ICustomerRepository>();
            repository.Setup(r => r.GetAllCustomers()).
                Returns(customers);
            var customersController = new CustomersController(repository.Object);
            var actionResult = customersController.Get();
            var result = ((ObjectResult)actionResult.Result).Value as IEnumerable<Customer>;
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
