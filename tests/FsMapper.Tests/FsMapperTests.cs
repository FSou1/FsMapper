using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FsMapper.Tests
{
    [TestClass]
    public class FsMapperTests
    {
        private IMapper mapper;

        [TestInitialize]
        public void Init()
        {
            mapper = new Mapper();
        }

        [TestMethod]
        public void WhenMappingExist_Then_Map()
        {
            var dto = GetCustomerDto();

            mapper.Register<CustomerDto, Customer>();

            var customer = mapper.Map<CustomerDto, Customer>(dto);

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

    internal class CustomerDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsDeleted { get; set; }
    }

    internal class Customer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsDeleted { get; set; }
    }
}
