import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.FutureTask;
import java.util.concurrent.TimeUnit;

public class BenchmarkMethods {

    private final Path SampleFilePath = Paths.get("D:\\Projects\\ThesisApps\\Java\\src\\Sample.txt");

    public void ReadFileSyncFlowBenchmark() {
        System.out.println();
        System.out.println("File Read Sync Flow Started");
        List<Long> times = new ArrayList<>();
        Long fileReadSyncFlowStart, fileReadSyncFlowStop;
        for (int i = 1; i <= 10; i++)
        {
            fileReadSyncFlowStart = System.nanoTime();
            for (int t = 0; t < 1000; t++)
            {
                ReadFile();
            }
            fileReadSyncFlowStop = System.nanoTime();
            Long elapsedTime = fileReadSyncFlowStop - fileReadSyncFlowStart;
            times.add(elapsedTime);
            System.out.println("File Read Sync Flow Complete Miliseconds("+ i + "): " + TimeUnit.MILLISECONDS.convert(elapsedTime, TimeUnit.NANOSECONDS));
        }
        System.out.println("File Read Sync Flow Completed > Average:  "+ TimeAverage(times));
        System.out.println();
        System.out.println();
    }

    public void CalculateSyncFlowBenchmark() {
        System.out.println();
        System.out.println("Calculate Sync Flow Started");
        List<Long> times = new ArrayList<>();
        Long calculateSyncFlowStart, calculateSyncFlowStop;
        for (int i = 1; i <= 10; i++)
        {
            calculateSyncFlowStart = System.nanoTime();
            for (int t = 0; t < 1000; t++)
            {
                Calculate();
            }
            calculateSyncFlowStop = System.nanoTime();
            Long elapsedTime = calculateSyncFlowStop - calculateSyncFlowStart;
            times.add(elapsedTime);
            System.out.println("Calculate Sync Flow Complete Miliseconds("+ i + "): " + TimeUnit.MILLISECONDS.convert(elapsedTime, TimeUnit.NANOSECONDS) + " - NanoSecond: " + elapsedTime);
        }
        System.out.println("Calculate Sync Flow Completed > Average: "+ TimeAverage(times));
        System.out.println();
        System.out.println();
    }

    public void ReadFileAsyncFlowBenchmark() throws InterruptedException {
        System.out.println();
        System.out.println("File Read Async Flow Started");
        List<Long> times = new ArrayList<>();
        Long fileReadSyncFlowStart, fileReadSyncFlowStop;
        for (int i = 1; i <= 10; i++)
        {
            List<FutureTask<Void>> tasks = new ArrayList<>();

            ExecutorService es = Executors.newCachedThreadPool();
            fileReadSyncFlowStart = System.nanoTime();

            for (int t = 0; t < 1000; t++)
            {
                Runnable task = () -> ReadFile();
                tasks.add((FutureTask<Void>) es.submit(task));
            }

            while (tasks.stream().anyMatch(p -> !p.isDone())) {
                //System.out.println("Tasks is not finished yet...");
            }
            es.shutdown();
            boolean finished = es.awaitTermination(1, TimeUnit.MINUTES);

            fileReadSyncFlowStop = System.nanoTime();
            Long elapsedTime = fileReadSyncFlowStop - fileReadSyncFlowStart;
            times.add(elapsedTime);
            System.out.println("File Read Async Flow Complete Miliseconds("+ i + "): " + TimeUnit.MILLISECONDS.convert(elapsedTime, TimeUnit.NANOSECONDS));
        }
        System.out.println("File Read Async Flow Completed > Average: "+ TimeAverage(times));
        System.out.println();
        System.out.println();
    }

    public void CalculateAsyncFlowBenchmark() throws InterruptedException {
        System.out.println();
        System.out.println("Calculate Async Flow Started");
        List<Long> times = new ArrayList<>();
        Long calculateAsyncFlowStart, calculateAsyncFlowStop;
        for (int i = 1; i <= 10; i++)
        {
            List<FutureTask<Void>> tasks = new ArrayList<>();

            ExecutorService es = Executors.newCachedThreadPool();
            calculateAsyncFlowStart = System.nanoTime();

            for (int t = 0; t < 1000; t++)
            {
                Runnable task = () -> Calculate();
                tasks.add((FutureTask<Void>) es.submit(task));
            }

            while (tasks.stream().anyMatch(p -> !p.isDone())) {
               // System.out.println("Tasks are not finished yet...");
            }

            es.shutdown();
            boolean finished = es.awaitTermination(1, TimeUnit.MINUTES);

            calculateAsyncFlowStop = System.nanoTime();
            Long elapsedTime = calculateAsyncFlowStop - calculateAsyncFlowStart;
            times.add(elapsedTime);
            System.out.println("Calculate Async Flow Complete Miliseconds("+ i + "): " + TimeUnit.MILLISECONDS.convert(elapsedTime, TimeUnit.NANOSECONDS));
        }
        System.out.println("Calculate Sync FlowCompleted > Average:  "+ TimeAverage(times));
        System.out.println();
        System.out.println();
    }

    private void ReadFile(){
        try {
            String fileContent = new String(Files.readAllBytes(SampleFilePath));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void Calculate() {
        for (int i = 0; i < 10000; i++) {
            double result = Math.pow(i, 2);
        }
    }

    private Long TimeAverage(List<Long> times) {
        Long sum = 0L;
        for (Long time : times) {
            sum += time;
        }
        Long avarage = sum / times.size();
        Long miliSecond = TimeUnit.MILLISECONDS.convert(avarage, TimeUnit.NANOSECONDS);
        return miliSecond;
    }
}
