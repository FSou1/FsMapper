``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 8.1 (6.3.9600)
Processor=Intel Core i5-5200U CPU 2.20GHz (Broadwell), ProcessorCount=4
Frequency=2143473 Hz, Resolution=466.5326 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                      Method |       Mean |     Error |    StdDev |     Median |
 |---------------------------- |-----------:|----------:|----------:|-----------:|
 | ExpressionCtorObjectBuilder |   8.548 ns | 0.2764 ns | 0.4541 ns |   8.608 ns |
 |     ActivatorCreateInstance |  79.379 ns | 1.6812 ns | 3.1987 ns |  78.890 ns |
 |       ConstructorInfoInvoke | 164.445 ns | 3.3355 ns | 4.3371 ns | 164.016 ns |
 |    DynamicMethodILGenerator |   5.859 ns | 0.2455 ns | 0.3015 ns |   5.819 ns |
 |                     NewCtor |   6.989 ns | 0.2615 ns | 0.5741 ns |   6.756 ns |
