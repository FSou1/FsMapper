``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328123 Hz, Resolution=300.4697 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                 Method |       Mean |     Error |    StdDev |     Median |
 |----------------------- |-----------:|----------:|----------:|-----------:|
 |      FsMapperBenchmark | 163.595 ns | 3.3286 ns | 4.4436 ns | 161.971 ns |
 | ExpressMapperBenchmark | 151.014 ns | 3.0238 ns | 4.4322 ns | 148.675 ns |
 |    AutoMapperBenchmark | 107.625 ns | 0.6510 ns | 0.5436 ns | 107.709 ns |
 |       MapsterBenchmark |  55.603 ns | 0.2196 ns | 0.1947 ns |  55.566 ns |
 |   AgileMapperBenchmark | 126.513 ns | 0.7332 ns | 0.6859 ns | 126.465 ns |
 |    CtorMapperBenchmark |   2.955 ns | 0.0235 ns | 0.0209 ns |   2.955 ns |
