using Benchmark;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<SVGToPNGBenchmark>();


Console.WriteLine("Benchmark completed!");
