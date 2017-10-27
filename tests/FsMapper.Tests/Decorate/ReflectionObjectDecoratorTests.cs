using System;
using FsMapper.Decorate;
using FsMapper.Tests.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FsMapper.Tests.Decorate
{
    [TestClass]
    public class ReflectionObjectDecoratorTests
    {
        private IObjectDecorator _objectDecorator;

        [TestInitialize]
        public void Init()
        {
            _objectDecorator = new ReflectionObjectDecorator();
        }

        [TestMethod]
        public void WhenDecoratorExist_Then_Map()
        {
            var dto = GetCustomerDto();
            var decorator = _objectDecorator.GetDecorator<CustomerDto, Customer>();
            var customer = new Customer();

            decorator(dto, customer);

            Assert.AreEqual(42, customer.Id);
            Assert.AreEqual("Test", customer.Title);
            Assert.AreEqual(new DateTime(2017, 9, 3), customer.CreatedAtUtc);
            Assert.AreEqual(true, customer.IsDeleted);
        }

        internal CustomerDto GetCustomerDto() => new CustomerDto
        {
            Id = 42,
            Title = "Test",
            CreatedAtUtc = new DateTime(2017, 9, 3),
            IsDeleted = true
        };
    }
}