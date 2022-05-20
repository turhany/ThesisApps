public class Main {
    public static void main(String[] args) throws InterruptedException {
        System.out.println("Sync Code Execution (FileRead and Calculate will run 100 times)");
        System.out.println("---------------------------------------------------------------");
        System.out.println("");

        BenchmarkMethods methods = new BenchmarkMethods();

        methods.ReadFileSyncFlowBenchmark();
        methods.CalculateSyncFlowBenchmark();

        methods.CalculateAsyncFlowBenchmark();
        methods.ReadFileAsyncFlowBenchmark();
    }
}