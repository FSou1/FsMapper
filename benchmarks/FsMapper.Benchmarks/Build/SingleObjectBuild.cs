using System;
using BenchmarkDotNet.Attributes;
using FsMapper.Benchmarks.Dto;
using FsMapper.Build;

namespace FsMapper.Benchmarks.Build
{
    public class SingleObjectBuild
    {
        private Func<CustomerDto, Customer> expressionNewActivator;
        private CustomerDto dto;

        [GlobalSetup]
        public void GlobalSetup()
        {
            dto = GetCustomerDto();
            expressionNewActivator = new ExpressionNewObjectBuilder().GetActivator<CustomerDto, Customer>();
        }

        [Benchmark]
        public Customer ExpressionCtorObjectBuilder()
        {
            return expressionNewActivator(dto);
        }

        #region Dto
        internal CustomerDto GetCustomerDto() => new CustomerDto
        {
            Id = 42,
            Title = "Test",
            CreatedAtUtc = new DateTime(2017, 9, 3),
            IsDeleted = true
        };
        #endregion
    }
}