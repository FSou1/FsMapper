using System;
using BenchmarkDotNet.Attributes;
using FsMapper.Benchmarks.Dto;
using FsMapper.Build;

namespace FsMapper.Benchmarks.Build
{
    public class SingleObjectBuild
    {
        private Func<Customer> dynamicMethodActivator;
        private Func<Customer> createInstanceActivator;
        private Func<Customer> expressionNewActivator;

        [GlobalSetup]
        public void GlobalSetup()
        {
            dynamicMethodActivator = new DynamicMethodObjectBuilder().GetActivator<Customer>();
            createInstanceActivator = new ActivatorCreateInstanceObjectBuilder().GetActivator<Customer>();
            expressionNewActivator = new ExpressionNewObjectBuilder().GetActivator<Customer>();
        }

        [Benchmark]
        public Customer DynamicMethodObjectBuilder()
        {
            return dynamicMethodActivator();
        }

        [Benchmark]
        public Customer ActivatorCreateInstanceObjectBuilder()
        {
            return createInstanceActivator();
        }

        [Benchmark]
        public Customer ExpressionCtorObjectBuilder()
        {
            return expressionNewActivator();
        }
    }
}