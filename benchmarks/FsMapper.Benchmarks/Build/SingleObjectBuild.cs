using System;
using System.Reflection;
using System.Reflection.Emit;
using BenchmarkDotNet.Attributes;
using FsMapper.Benchmarks.Dto;
using FsMapper.Build;

namespace FsMapper.Benchmarks.Build
{
    public class SingleObjectBuild
    {
        private Func<CustomerDto, Customer> expressionNewActivator;
        private Func<Customer> delegateActivator;
        private ConstructorInfo constructorInfo;
        private CustomerDto dto;

        [GlobalSetup]
        public void GlobalSetup()
        {
            dto = GetCustomerDto();
            constructorInfo = typeof(Customer).GetConstructor(Type.EmptyTypes);
            expressionNewActivator = new ExpressionNewObjectBuilder().GetActivator<CustomerDto, Customer>();
            delegateActivator = (Func<Customer>)BuildConstructor<Customer>(constructorInfo);
        }

        [Benchmark]
        public Customer ExpressionCtorObjectBuilder()
        {
            return expressionNewActivator(dto);
        }

        [Benchmark]
        public Customer ActivatorCreateInstance()
        {
            return Activator.CreateInstance<Customer>();
        }

        [Benchmark]
        public Customer ConstructorInfoInvoke()
        {
            return (Customer)constructorInfo.Invoke(null);
        }

        [Benchmark]
        public Customer DynamicMethodILGenerator()
        {
            return delegateActivator();
        }

        [Benchmark]
        public Customer NewCtor()
        {
            return new Customer
            {
                Id = 42,
                Title = "Test",
                IsDeleted = true
            };
        }

        public Delegate BuildConstructor<TDest>(ConstructorInfo ctorInfo)
        {		
            var dynamicMethod = new DynamicMethod("Create_" + ctorInfo.Name, ctorInfo.DeclaringType, new[] { typeof(object[]) });		
            var ilgen = dynamicMethod.GetILGenerator();		
            ilgen.Emit(OpCodes.Newobj, ctorInfo);		
            ilgen.Emit(OpCodes.Ret);		
            return dynamicMethod.CreateDelegate(typeof(Func<TDest>));		
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