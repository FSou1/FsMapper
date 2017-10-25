``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 8.1 (6.3.9600)
Processor=Intel Core i5-5200U CPU 2.20GHz (Broadwell), ProcessorCount=4
Frequency=2143477 Hz, Resolution=466.5317 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                               Method |      Mean |     Error |    StdDev |    Median |
 |------------------------------------- |----------:|----------:|----------:|----------:|
 |           DynamicMethodObjectBuilder |  6.489 ns | 0.2375 ns | 0.5408 ns |  6.177 ns |
 | ActivatorCreateInstanceObjectBuilder | 74.205 ns | 1.0243 ns | 0.8553 ns | 74.463 ns |
 |          ExpressionCtorObjectBuilder |  4.889 ns | 0.0231 ns | 0.0181 ns |  4.890 ns |
