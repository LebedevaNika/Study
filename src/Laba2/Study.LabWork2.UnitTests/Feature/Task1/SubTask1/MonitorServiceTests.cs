using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MonitorServiceTests
{
    private MonitorService service;

    [SetUp]
    public void Setup()
    {
        service = new MonitorService();
    }

    [Test]
    public void Test1()
    {
        var result = service.CountPrimes(1, 100, 2);
        Assert.That(result.PrimeCount, Is.EqualTo(25));
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
        Assert.That(service.GetVersionName(), Is.EqualTo("Monitor"));
    }
}
