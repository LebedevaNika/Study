using Study.LabWork2.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Лабораторная 2");
        Console.WriteLine();

        Console.WriteLine("1.1");
        Console.WriteLine();
        int start = 1;
        int end = 10000;
        int threadCount = 4;
        // Monitor
        Console.WriteLine(" Monitor");
        var monitorService = new MonitorService();
        var monitorResult = monitorService.CountPrimes(start, end, threadCount);
        Console.WriteLine($"Result: {monitorResult.PrimeCount} prime numbers");
        Console.WriteLine($"Time: {monitorResult.ExecutionTime.TotalMilliseconds} ms");
        Console.WriteLine();

        // Mutex
        Console.WriteLine(" Mutex" );
        var mutexService = new MutexService();
        var mutexResult = mutexService.CountPrimes(start, end, threadCount);
        Console.WriteLine($"Result: {mutexResult.PrimeCount} prime numbers");
        Console.WriteLine($"Time: {mutexResult.ExecutionTime.TotalMilliseconds} ms");
        Console.WriteLine();

        // Semaphore
        Console.WriteLine("Semaphore");
        var semaphoreService = new SemaphoreService();
        var semaphoreResult = semaphoreService.CountPrimes(start, end, threadCount);
        Console.WriteLine($"Result: {semaphoreResult.PrimeCount} prime numbers");
        Console.WriteLine($"Time: {semaphoreResult.ExecutionTime.TotalMilliseconds} ms");
        Console.WriteLine();

        Console.WriteLine("1.2");
        Console.WriteLine();
        var random = new Random();
        var numberSets = new List<int[]>();
        for (int i = 0; i < 15; i++)
        {
            int[] numbers = new int[100];
            for (int j = 0; j < 100; j++)
            {
                numbers[j] = random.Next(1, 101);
            }
            numberSets.Add(numbers);
        }

        var processor = new NumberSetProcessor(numberSets, 3);
        processor.Process();

    }
}

