using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class SemaphoreServiceTests
{
    private SemaphoreService service;  // ← это поле, а не класс!

    [SetUp]
    public void Setup()
    {
        service = new SemaphoreService();
    }

    [Test]
    public void Test1()
    {
        int start = 1;
        int end = 100;
        int threadCount = 2;

        var result = service.CountPrimes(start, end, threadCount);

        Assert.That(result.PrimeCount, Is.EqualTo(25));
        Assert.That(result.ThreadCount, Is.EqualTo(threadCount));
        Assert.That(result.SynchronizationType, Is.EqualTo("Semaphore"));
    }

    [Test]
    public void Test2()
    {
        var result = service.CountPrimes(1, 10000, 4);
        Assert.That(result.PrimeCount, Is.EqualTo(1229));
    }

    [Test]
    public void Test3()
    {
        Assert.That(service.GetVersionName(), Is.EqualTo("Semaphore"));
    }
}
