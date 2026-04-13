using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    public class HSLtest
    {
        // правильно ли задаются значения
        [Test]
        public void Constructor_SetsValuesCorrectly()
        {
            var color = new HSL(120, 50, 25);

            ClassicAssert.AreEqual(120, color.Hue);
            ClassicAssert.AreEqual(50, color.Saturation);
            ClassicAssert.AreEqual(25, color.Lightness);
        }

        // проверка зацикливания оттенка
        [Test]
        public void Hue_WrapsAround()
        {
            var color = new HSL(370, 50, 50);

            ClassicAssert.AreEqual(10, color.Hue);
        }

        // насыщенность не меньше 0 и не больше 100
        [Test]
        public void Saturation_Clamped()
        {
            var color = new HSL(100, 150, 50);

            ClassicAssert.AreEqual(100, color.Saturation);
        }

        // светлота не меньше 0 и не больше 100
        [Test]
        public void Lightness_Clamped()
        {
            var color = new HSL(100, 50, -10);

            ClassicAssert.AreEqual(0, color.Lightness);
        }

        // проверка оператора сложения
        [Test]
        public void Plus_Works()
        {
            var a = new HSL(100, 20, 30);
            var b = new HSL(50, 10, 15);

            var result = a + b;

            ClassicAssert.AreEqual(150, result.Hue);
            ClassicAssert.AreEqual(30, result.Saturation);
            ClassicAssert.AreEqual(45, result.Lightness);
        }

        // проверка деления на ноль
        [Test]
        public void Divide_ByZero_Throws()
        {
            var color = new HSL(100, 40, 60);

            Assert.Throws<Exception>(() =>
            {
                var result = color / 0;
            });
        }

        // проверка оператора ==
        [Test]
        public void EqualOperator_Works()
        {
            var a = new HSL(120, 50, 50);
            var b = new HSL(120, 50, 50);

            ClassicAssert.IsTrue(a == b);
        }

        // проверка перевода в HEX
        [Test]
        public void ToHex_Works()
        {
            var color = new HSL(0, 0, 0);

            var hex = color.ToHex();

            ClassicAssert.AreEqual("#000000", hex);
        }
    }
}
