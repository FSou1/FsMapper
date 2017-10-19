using System;
using System.Linq.Expressions;

namespace FsMapper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var dto = GetCustomerDto();
            var mapper = new Mapper();
            mapper.Register<CustomerDto, Customer>();

            /*
            var mapper = new Mapper();

            var dto = GetCustomerDto();

            mapper.Register<CustomerDto, Customer>();

            var customer = mapper.Map<CustomerDto, Customer>(dto);
            */
        }

        internal static CustomerDto GetCustomerDto() => new CustomerDto
        {
            Id = 42,
            Title = "Test",
            CreatedAtUtc = new DateTime(2017, 9, 3),
            IsDeleted = true
        };

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
}
