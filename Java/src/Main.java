public class Main {
    public static void main(String[] args) throws InterruptedException {
        System.out.println("Senkron ve Asenkron İşlem Denemeleri(Dosya okuma ve hesaplama)");
        System.out.println("---------------------------------------------------------------");
        System.out.println("");

        BenchmarkMethods methods = new BenchmarkMethods();

        methods.ReadFileSyncFlowBenchmark();
        methods.CalculateSyncFlowBenchmark();

        methods.CalculateAsyncFlowBenchmark();
        methods.ReadFileAsyncFlowBenchmark();
    }
}