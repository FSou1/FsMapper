using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using FsMapper.Benchmarks.Dto;

namespace FsMapper.Benchmarks.Storage
{
    public class DelegateStorageRetrieve
    {
        private Dictionary<(Type, Type), Delegate> dictTupleStorage = new Dictionary<(Type, Type), Delegate>();
        private Dictionary<TypeTuple, Delegate> dictTypeTupleStorage = new Dictionary<TypeTuple, Delegate>();
        private Hashtable hashtableTupleStorage = new Hashtable();
        private Hashtable hashtableTypeTupleStorage = new Hashtable();

        [GlobalSetup]
        public void Init()
        {
            Func<CustomerDto, Customer> activator = (x) => new Customer();
            dictTupleStorage.Add((typeof(CustomerDto), typeof(Customer)), activator);
            dictTypeTupleStorage.Add(new TypeTuple(typeof(CustomerDto), typeof(Customer)), activator);
            hashtableTupleStorage.Add((typeof(CustomerDto), typeof(Customer)), activator);
            hashtableTypeTupleStorage.Add(new TypeTuple(typeof(CustomerDto), typeof(Customer)), activator);
        }

        [Benchmark]
        public Delegate DictionaryTuple()
        {
            var key = (typeof(CustomerDto), typeof(Customer));
            return dictTupleStorage[key];
        }

        [Benchmark]
        public Delegate DictionaryTypeTuple()
        {
            var key = new TypeTuple(typeof(CustomerDto), typeof(Customer));
            return dictTypeTupleStorage[key];
        }

        [Benchmark]
        public Delegate HashtableTuple()
        {
            var key = (typeof(CustomerDto), typeof(Customer));
            return (Delegate)hashtableTupleStorage[key];
        }

        [Benchmark]
        public Delegate HashtableTypeTuple()
        {
            var key = new TypeTuple(typeof(CustomerDto), typeof(Customer));
            return (Delegate)hashtableTypeTupleStorage[key];
        }
    }
}
