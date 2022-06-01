using System.Globalization;
using ThesisConsoleApp;

Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("tr-TR");
Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("tr-TR");

Console.WriteLine("Senkron ve Asenkron İşlem Denemeleri(Dosya okuma ve hesaplama)");
Console.WriteLine("---------------------------------------------------------------");
Console.WriteLine(string.Empty);

var methods = new BenchmarkMethods();

methods.ReadFileSyncFlowBenchmark();
methods.CalculateSyncFlowBenchmark();

methods.CalculateAsyncFlowBenchmark();
methods.ReadFileAsyncFlowBenchmark();