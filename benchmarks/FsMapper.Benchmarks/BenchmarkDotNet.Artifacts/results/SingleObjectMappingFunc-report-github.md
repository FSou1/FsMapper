``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 8.1 (6.3.9600)
Processor=Intel Core i5-5200U CPU 2.20GHz (Broadwell), ProcessorCount=4
Frequency=2143477 Hz, Resolution=466.5317 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |              Method |      Mean |     Error |    StdDev |
 |-------------------- |----------:|----------:|----------:|
 |   FsMapperBenchmark | 78.077 ns | 0.2724 ns | 0.2548 ns |
 | CtorMapperBenchmark |  8.182 ns | 0.3035 ns | 0.3727 ns |
