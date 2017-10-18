``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i7-6700 CPU 3.40GHz (Skylake), ProcessorCount=8
Frequency=3328128 Hz, Resolution=300.4692 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                 Method |      Mean |    Error |    StdDev |
 |----------------------- |----------:|---------:|----------:|
 | ExpressMapperBenchmark | 175.43 ns | 3.550 ns | 5.2029 ns |
 |    AutoMapperBenchmark | 133.10 ns | 2.731 ns | 6.6466 ns |
 |       MapsterBenchmark |  65.24 ns | 1.035 ns | 0.9685 ns |
 |   AgileMapperBenchmark | 154.37 ns | 2.769 ns | 2.4547 ns |
