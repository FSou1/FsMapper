``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 8.1 (6.3.9600)
Processor=Intel Core i5-5200U CPU 2.20GHz (Broadwell), ProcessorCount=4
Frequency=2143477 Hz, Resolution=466.5317 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |              Method |      Mean |     Error |    StdDev |
 |-------------------- |----------:|----------:|----------:|
 |   FsMapperBenchmark | 92.648 ns | 1.8724 ns | 1.6599 ns |
 | CtorMapperBenchmark |  8.177 ns | 0.1351 ns | 0.1198 ns |
