``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 8.1 (6.3.9600)
Processor=Intel Core i5-5200U CPU 2.20GHz (Broadwell), ProcessorCount=4
Frequency=2143473 Hz, Resolution=466.5326 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                 Method |       Mean |     Error |    StdDev |
 |----------------------- |-----------:|----------:|----------:|
 |      FsMapperBenchmark |  95.929 ns | 1.3622 ns | 1.1375 ns |
 | ExpressMapperBenchmark | 237.110 ns | 1.4847 ns | 1.3888 ns |
 |    AutoMapperBenchmark | 196.640 ns | 4.6218 ns | 5.5019 ns |
 |       MapsterBenchmark |  85.906 ns | 0.3268 ns | 0.2897 ns |
 |   AgileMapperBenchmark | 212.976 ns | 1.0561 ns | 0.8246 ns |
 |    CtorMapperBenchmark |   7.202 ns | 0.0832 ns | 0.0737 ns |
