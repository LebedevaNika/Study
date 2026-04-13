using Study.LabWork1.Features.Task1;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1() 
    {
        var a = new HSL(120, 50, 50);
        var b = new HSL(60, 20, 30);

        Console.WriteLine("A: " + a);
        Console.WriteLine("B: " + b);
        Console.WriteLine("A + B: " + (a + b));

        var rgb = a.ToRGB();
        Console.WriteLine($"RGB: {rgb.R}, {rgb.G}, {rgb.B}");
        Console.WriteLine("HEX: " + a.ToHex());
    }

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
