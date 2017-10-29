# FsMapper

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
 |      FsMapperBenchmark |  84.492 ns | 1.6972 ns | 1.6669 ns |
 | ExpressMapperBenchmark | 251.161 ns | 4.6736 ns | 4.3717 ns |
 |    AutoMapperBenchmark | 204.142 ns | 4.2002 ns | 9.1309 ns |
 |       MapsterBenchmark |  90.949 ns | 1.6393 ns | 1.4532 ns |
 |   AgileMapperBenchmark | 218.021 ns | 3.0921 ns | 2.7410 ns |
 |    CtorMapperBenchmark |   7.806 ns | 0.2472 ns | 0.2312 ns |
