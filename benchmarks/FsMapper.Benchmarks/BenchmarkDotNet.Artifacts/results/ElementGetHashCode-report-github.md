``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 8.1 (6.3.9600)
Processor=Intel Core i5-5200U CPU 2.20GHz (Broadwell), ProcessorCount=4
Frequency=2143473 Hz, Resolution=466.5326 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |        Method |     Mean |     Error |    StdDev |
 |-------------- |---------:|----------:|----------:|
 | TypeTupleHash | 29.72 ns | 0.3540 ns | 0.3311 ns |
 |     TupleHash | 25.79 ns | 0.2385 ns | 0.2115 ns |
