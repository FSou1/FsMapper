``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 8.1 (6.3.9600)
Processor=Intel Core i5-5200U CPU 2.20GHz (Broadwell), ProcessorCount=4
Frequency=2143473 Hz, Resolution=466.5326 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |              Method |      Mean |     Error |    StdDev |
 |-------------------- |----------:|----------:|----------:|
 |     DictionaryTuple |  80.37 ns | 1.6473 ns | 1.6179 ns |
 | DictionaryTypeTuple |  49.35 ns | 0.6235 ns | 0.5832 ns |
 |      HashtableTuple | 103.07 ns | 2.6081 ns | 2.4397 ns |
 |  HashtableTypeTuple |  71.51 ns | 0.8679 ns | 0.7694 ns |
