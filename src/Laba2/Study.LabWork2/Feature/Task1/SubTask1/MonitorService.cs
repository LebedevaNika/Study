using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 1. Использует Monitor (lock) для синхронизации
/// </summary>
public sealed class MonitorService : IPrimeCounter
{
    private static readonly object lockObject = new object();
    private int totalPrimeCount = 0;
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        totalPrimeCount = 0;
        var stopwatch = Stopwatch.StartNew();
        var threads = new List<Thread>();

        int rangeSize = (end - start + 1) / threadCount;
        int currentStart = start;
        for (int i = 0; i < threadCount; i++)
        {
            int threadStart = currentStart;
            int threadEnd = (i == threadCount - 1) ? end : currentStart + rangeSize - 1;

            Thread thread = new Thread(() => ProcessRange(threadStart, threadEnd, i + 1));
            threads.Add(thread);
            thread.Start();
            currentStart = threadEnd + 1;
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }
        stopwatch.Stop();
        return new PrimeCountResultDto
        {
            PrimeCount = totalPrimeCount,           
            ExecutionTime = stopwatch.Elapsed,       
            SynchronizationType = GetVersionName(),  
            ThreadCount = threadCount,
            FoundPrimes = new List<int>()
        };
    }
    private void ProcessRange(int start, int end, int threadId)
    {
        int localCount = 0;

        for (int number = start; number <= end; number++)
        {
            bool isPrime = IsPrime(number);

            Monitor.Enter(lockObject);
            try
            {
                Console.WriteLine($"[Поток {threadId}] Проверяю число: {number}, простое: {isPrime}");
            }
            finally
            {
                Monitor.Exit(lockObject);
            }

            if (isPrime)
            {
                localCount++;
            }
        }

        Monitor.Enter(lockObject);
        try
        {
            totalPrimeCount += localCount;
            Console.WriteLine($"[Поток {threadId}] Завершил. Найдено простых: {localCount}");
        }
        finally
        {
            Monitor.Exit(lockObject);
        }
    }

    private bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        int limit = (int)Math.Sqrt(number);
        for (int i = 3; i <= limit; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    public string GetVersionName() => "Monitor";
}
