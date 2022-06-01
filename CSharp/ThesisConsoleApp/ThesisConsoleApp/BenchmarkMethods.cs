using System.Diagnostics;

namespace ThesisConsoleApp
{
    internal class BenchmarkMethods
    {
        private string SampleFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files//Sample.txt");

        public void ReadFileSyncFlowBenchmark()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("Dosya okuma işlemi için Senkron akış başladı");
            var times = new List<long>();
            var fileReadSyncFlow = new Stopwatch();
            for (int i = 1; i <= 10; i++)
            {
                fileReadSyncFlow.Reset();
                fileReadSyncFlow.Start();
                for (int t = 0; t < 1000; t++)
                {
                    ReadFile();
                }
                fileReadSyncFlow.Stop();
                var elapsedTime = fileReadSyncFlow.ElapsedMilliseconds;
                times.Add(elapsedTime);
                Console.WriteLine($"Dosya okuma işlemi için Senkron akış tamamlandı - (Deneme:{i}) - MiliSaniye: {elapsedTime}");
            }
            Console.WriteLine($"Dosya okuma işlemi için Senkron akış tamamlandı > Ortalama: {Queryable.Average(times.AsQueryable())} MiliSaniye");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
        }

        public void CalculateSyncFlowBenchmark()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("Hesaplama işlemi için Senkron akış başladı");
            var times = new List<long>();
            var fileReadSyncFlow = new Stopwatch();
            for (int i = 1; i <= 10; i++)
            {
                fileReadSyncFlow.Reset();
                fileReadSyncFlow.Start();
                for (int t = 0; t < 1000; t++)
                {
                    Calculate();
                }
                fileReadSyncFlow.Stop();
                var elapsedTime = fileReadSyncFlow.ElapsedMilliseconds;
                times.Add(elapsedTime);
                Console.WriteLine($"Hesaplama işlemi için Senkron akış tamamlandı - (Deneme:{i}) - MiliSaniye: {elapsedTime}");
            }
            Console.WriteLine($"Hesaplama işlemi için Senkron akış tamamlandı > Ortalama: {Queryable.Average(times.AsQueryable())} MiliSaniye");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
        }

        public void ReadFileAsyncFlowBenchmark()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("Dosya okuma işlemi için Asenkron akış başladı");

            var times = new List<long>();
            var fileReadSyncFlow = new Stopwatch();
            for (int i = 1; i <= 10; i++)
            {
                var tasks = new List<Task>();
                fileReadSyncFlow.Reset();
                fileReadSyncFlow.Start();
                for (int t = 0; t < 1000; t++)
                {
                    tasks.Add(Task.Run(ReadFile));
                }
                Task.WaitAll(tasks.ToArray());
                fileReadSyncFlow.Stop();
                var elapsedTime = fileReadSyncFlow.ElapsedMilliseconds;
                times.Add(elapsedTime);
                Console.WriteLine($"Dosya okuma işlemi için Asenkron akış tamamlandı - (Deneme:{i}) - MiliSaniye: {elapsedTime}");
            }
            Console.WriteLine($"Dosya okuma işlemi için Asenkron akış tamamlandı > Ortalama: {Queryable.Average(times.AsQueryable())} MiliSaniye");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
        }

        public void CalculateAsyncFlowBenchmark()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("Hesaplama işlemi için Asenkron akış başladı");

            var times = new List<long>();
            var fileReadSyncFlow = new Stopwatch();
            for (int i = 1; i <= 10; i++)
            {
                var tasks = new List<Task>();
                fileReadSyncFlow.Reset();
                fileReadSyncFlow.Start();
                for (int t = 0; t < 1000; t++)
                {
                    tasks.Add(Task.Run(Calculate));
                }
                Task.WaitAll(tasks.ToArray());
                fileReadSyncFlow.Stop();
                var elapsedTime = fileReadSyncFlow.ElapsedMilliseconds;
                times.Add(elapsedTime);
                Console.WriteLine($"Hesaplama işlemi için Asenkron akış tamamlandı - (Deneme:{i}) - MiliSaniye: {elapsedTime}");
            }
            Console.WriteLine($"Hesaplama işlemi için Asenkron akış tamamlandı > Ortalama: {Queryable.Average(times.AsQueryable())} MiliSaniye");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
        }


        private void ReadFile()
        {
            var content = File.ReadAllText(SampleFilePath);
        }

        private void Calculate()
        {
            for (int i = 1; i <= 10000; i++)
            {
                var result = Math.Pow(i, 2);
            }
        }
    }
}
