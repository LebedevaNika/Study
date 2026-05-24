using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

public sealed class NumberSetProcessor : INumberSetProcessor
{
    private readonly List<int[]> _numberSets;
    private readonly List<ResultEntryDto> results = new List<ResultEntryDto>();
    private int totalSum = 0;
    private readonly Semaphore semaphore;
    private readonly Mutex mutex = new Mutex();
    private readonly object lockObject = new object();
    private TimeSpan executionTime;

    public NumberSetProcessor(List<int[]> numberSets, int maxConcurrentThreads = 3)
    {
        _numberSets = numberSets;
        semaphore = new Semaphore(maxConcurrentThreads, maxConcurrentThreads);
    }

    public void Process()
    {
        var stopwatch = Stopwatch.StartNew();
        var threads = new List<Thread>();

        for (int i = 0; i < _numberSets.Count; i++)
        {
            int setNumber = i;
            Thread thread = new Thread(() => ProcessSingleSet(setNumber));
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();
        executionTime = stopwatch.Elapsed;

        foreach (var result in results)
        {
            Console.WriteLine($"Set {result.SetNumber}: sum = {result.Sum}, thread {result.ThreadId}");
        }

        Console.WriteLine($"Total sum: {totalSum}");
        Console.WriteLine($"Time: {executionTime.TotalMilliseconds} ms");
    }

    private void ProcessSingleSet(int setNumber)
    {
        semaphore.WaitOne();

        try
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            int[] numbers = _numberSets[setNumber];
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            lock (lockObject)
            {
                results.Add(new ResultEntryDto
                {
                    SetNumber = setNumber + 1,
                    Sum = sum,
                    ThreadId = threadId
                });
            }

            mutex.WaitOne();
            try
            {
                totalSum += sum;
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        finally
        {
            semaphore.Release();
        }
    }

    public ProcessingResultDto GetResult()
    {
        return new ProcessingResultDto
        {
            Results = results.ToList(),
            TotalSum = totalSum,
            ExecutionTime = executionTime,
            ProcessedSetsCount = results.Count
        };
    }
}
