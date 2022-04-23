// See https://aka.ms/new-console-template for more information
using ThesisConsoleApp;

Console.WriteLine("Sync Code Execution (FileRead and Calculate will run 100 times)");
Console.WriteLine("---------------------------------------------------------------");
Console.WriteLine(string.Empty);

var methods = new BenchmarkMethods();

methods.ReadFileSyncFlowBenchmark();
methods.CalculateSyncFlowBenchmark();

methods.CalculateAsyncFlowBenchmark();
methods.ReadFileAsyncFlowBenchmark();