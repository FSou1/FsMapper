``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 8.1 (6.3.9600)
Processor=Intel Core i5-5200U CPU 2.20GHz (Broadwell), ProcessorCount=4
Frequency=2143477 Hz, Resolution=466.5317 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                 Method |       Mean |     Error |    StdDev |
 |----------------------- |-----------:|----------:|----------:|
 |      FsMapperBenchmark |  62.528 ns | 2.1917 ns | 3.4763 ns |
 | ExpressMapperBenchmark | 244.000 ns | 1.5366 ns | 1.3621 ns |
 |    AutoMapperBenchmark | 197.394 ns | 5.6587 ns | 8.1155 ns |
 |       MapsterBenchmark |  89.305 ns | 1.8278 ns | 2.5019 ns |
 |   AgileMapperBenchmark | 202.488 ns | 4.0546 ns | 3.3858 ns |
 |    CtorMapperBenchmark |   7.638 ns | 0.2148 ns | 0.1793 ns |
