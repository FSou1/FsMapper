using System;
using BenchmarkDotNet.Attributes;
using FsMapper.Benchmarks.Dto;
using Mapster;

namespace FsMapper.Benchmarks.Mapping
{
    using ExpressMapper = ExpressMapper.Mapper;
    using AutoMapper = AutoMapper.Mapper;
    using ValueInjecterMapper = Omu.ValueInjecter.Mapper;
    using AgileMapper = AgileObjects.AgileMapper.Mapper;

    public class SingleObjectMappingFunc
    {
        private IMapper mapper;
        private CustomerDto dto;

        [GlobalSetup]
        public void GlobalSetup()
        {
            dto = GetCustomerDto();
            
            mapper = ConfigureFsMapper();
            ConfigureExpressMapper();
            ConfigureAutoMapper();
        }

        [Benchmark]
        public Customer FsMapperBenchmark() => mapper.Map<CustomerDto, Customer>(dto);
        
        [Benchmark]
        public Customer ExpressMapperBenchmark() => ExpressMapper.Map<CustomerDto, Customer>(dto);

        [Benchmark]
        public Customer AutoMapperBenchmark()=> AutoMapper.Map<CustomerDto, Customer>(dto);
        
        [Benchmark]
        public Customer MapsterBenchmark() => dto.Adapt<Customer>();
        
        [Benchmark]
        public Customer AgileMapperBenchmark() => AgileMapper.Map(dto).ToANew<Customer>();
        
        [Benchmark]
        public Customer CtorMapperBenchmark() => new Customer
        {
            Id = dto.Id,
            CreatedAtUtc = dto.CreatedAtUtc,
            IsDeleted = dto.IsDeleted,
            Title = dto.Title
        };

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