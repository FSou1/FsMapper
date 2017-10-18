using System;
using BenchmarkDotNet.Attributes;
using Mapster;

namespace FsMapper.Benchmarks.Mapping
{
    using ExpressMapper = ExpressMapper.Mapper;
    using AutoMapper = AutoMapper.Mapper;
    using ValueInjecterMapper = Omu.ValueInjecter.Mapper;
    using AgileMapper = AgileObjects.AgileMapper.Mapper;

    public class MappingFunc
    {
        private IMapper _mapper;
        private CustomerDto dto;

        [GlobalSetup]
        public void GlobalSetup()
        {
            dto = GetCustomerDto();
            
            //fsMapper = ConfigureFsMapper();
            ConfigureExpressMapper();
            ConfigureAutoMapper();
        }

        //[Benchmark]
        //public Customer FsMapperBenchmark() => fsMapper.Map<CustomerDto, Customer>(dto);

        [Benchmark]
        public Customer ExpressMapperBenchmark() => ExpressMapper.Map<CustomerDto, Customer>(dto);

        [Benchmark]
        public Customer AutoMapperBenchmark()=> AutoMapper.Map<CustomerDto, Customer>(dto);

        [Benchmark]
        public Customer MapsterBenchmark() => dto.Adapt<Customer>();
        
        [Benchmark]
        public Customer AgileMapperBenchmark() => AgileMapper.Map(dto).ToANew<Customer>();

        #region Configure
        internal IMapper ConfigureFsMapper()
        {
            var mapper = new Mapper();

            mapper.Register<CustomerDto, Customer>();

            return mapper;
        }

        internal void ConfigureExpressMapper()
        {
            ExpressMapper.Register<CustomerDto, Customer>();
        }

        internal void ConfigureAutoMapper()
        {
            AutoMapper.Initialize(cfg => cfg.CreateMap<CustomerDto, Customer>());
        }
        #endregion

        internal CustomerDto GetCustomerDto() => new CustomerDto
        {
            Id = 42,
            Title = "Test",
            CreatedAtUtc = new DateTime(2017, 9, 3),
            IsDeleted = true
        };
    }

    public class CustomerDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsDeleted { get; set; }
    }
}