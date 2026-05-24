using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

[TestFixture]
public sealed class NumberSetProcessorTests
{
    [Test]
    public void Test1()
    {
        // Создаём один набор чисел
        var sets = new List<int[]>
        {
            new int[] { 10, 20, 30 }  // сумма = 60
        };

        // Создаём процессор
        var processor = new NumberSetProcessor(sets, 2);

        // Запускаем обработку
        processor.Process();

        // Получаем результат
        var result = processor.GetResult();

        // Проверяем: сумма должна быть 60
        Assert.That(result.TotalSum, Is.EqualTo(60));

        // Проверяем: обработан 1 набор
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(1));
    }

    [Test]
    public void Test2()
    {
        // Создаём два набора чисел
        var sets = new List<int[]>
        {
            new int[] { 1, 2, 3 },  // сумма = 6
            new int[] { 4, 5, 6 }   // сумма = 15
        };

        var processor = new NumberSetProcessor(sets, 2);
        processor.Process();
        var result = processor.GetResult();

        // Общая сумма: 6 + 15 = 21
        Assert.That(result.TotalSum, Is.EqualTo(21));

        // Обработано 2 набора
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(2));
    }

    [Test]
    public void Test3()
    {
        // Создаём три набора
        var sets = new List<int[]>
        {
            new int[] { 1, 1, 1 },  // сумма = 3
            new int[] { 2, 2, 2 },  // сумма = 6
            new int[] { 3, 3, 3 }   // сумма = 9
        };

        var processor = new NumberSetProcessor(sets, 2);
        processor.Process();
        var result = processor.GetResult();

        // Проверяем, что все 3 набора обработаны
        Assert.That(result.Results.Count, Is.EqualTo(3));

        // Проверяем суммы каждого набора
        Assert.That(result.Results[0].Sum, Is.EqualTo(3));
        Assert.That(result.Results[1].Sum, Is.EqualTo(6));
        Assert.That(result.Results[2].Sum, Is.EqualTo(9));

        // Общая сумма: 3 + 6 + 9 = 18
        Assert.That(result.TotalSum, Is.EqualTo(18));
    }

    [Test]
    public void Test4()
    {
        // Пустой список наборов
        var sets = new List<int[]>();

        var processor = new NumberSetProcessor(sets, 2);
        processor.Process();
        var result = processor.GetResult();

        // Сумма должна быть 0
        Assert.That(result.TotalSum, Is.EqualTo(0));

        // Обработано 0 наборов
        Assert.That(result.ProcessedSetsCount, Is.EqualTo(0));
    }
}
