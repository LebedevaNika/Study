using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MutexServiceTests
{
    private MutexService _service;

    [SetUp]
    public void Setup()
    {
        _service = new MutexService();
    }

    [Test]
    public void Test1()
    {
        var result = _service.CountPrimes(1, 100, 2);
        Assert.That(result.PrimeCount, Is.EqualTo(25));
    }

    [Test]
    public void Test2()
    {
        var result = _service.CountPrimes(1, 10000, 4);
        Assert.That(result.PrimeCount, Is.EqualTo(1229));
    }

    [Test]
    public void Test3()
    {
        Assert.That(_service.GetVersionName(), Is.EqualTo("Mutex"));
    }
}
