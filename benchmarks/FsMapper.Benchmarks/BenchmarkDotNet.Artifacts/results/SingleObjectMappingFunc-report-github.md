``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328123 Hz, Resolution=300.4697 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |              Method |      Mean |     Error |    StdDev |    Median |
 |-------------------- |----------:|----------:|----------:|----------:|
 |   FsMapperBenchmark | 55.516 ns | 1.1643 ns | 1.8801 ns | 54.582 ns |
 |    MapsterBenchmark | 64.435 ns | 1.1314 ns | 1.0583 ns | 64.183 ns |
 | CtorMapperBenchmark |  4.421 ns | 0.2070 ns | 0.6007 ns |  4.249 ns |
