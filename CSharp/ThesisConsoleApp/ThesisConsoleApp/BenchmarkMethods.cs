using System.Diagnostics;

namespace ThesisConsoleApp
{
    internal class BenchmarkMethods
    {
        private string SampleFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files//Sample.txt");

        public void ReadFileSyncFlowBenchmark()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("File Read Sync Flow Started");
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
                Console.WriteLine($"File Read Sync Flow Complete Miliseconds({i}): {elapsedTime}");
            }
            Console.WriteLine($"File Read Sync Flow Completed > Average: {Queryable.Average(times.AsQueryable())}");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
        }

        public void CalculateSyncFlowBenchmark()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("Calculate Sync Flow Started");
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
                Console.WriteLine($"Calculate Sync Flow Complete Miliseconds({i}): {elapsedTime}");
            }
            Console.WriteLine($"Calculate Sync Flow Completed > Average: {Queryable.Average(times.AsQueryable())}");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
        }

        public void ReadFileAsyncFlowBenchmark()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("File Read Async Flow Started");

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
                Console.WriteLine($"File Read Async Flow Complete Miliseconds({i}): {elapsedTime}");
            }
            Console.WriteLine($"File Read Async Flow Completed > Average: {Queryable.Average(times.AsQueryable())}");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
        }

        public void CalculateAsyncFlowBenchmark()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("Calculate Async Flow Started");

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
                Console.WriteLine($"Calculate Async Flow Complete Miliseconds({i}): {elapsedTime}");
            }
            Console.WriteLine($"Calculate Async Flow Completed > Average: {Queryable.Average(times.AsQueryable())}");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
        }


        private void ReadFile()
        {
            var content = File.ReadAllText(SampleFilePath);
        }

        private void Calculate()
        {
            for (int i = 1; i <= 100; i++)
            {
                var result = Math.Pow(i, 2);
                Console.WriteLine($"{i} = {result}");
            }
        }
    }
}
