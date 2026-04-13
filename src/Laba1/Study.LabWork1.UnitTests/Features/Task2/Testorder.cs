using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;
using Study.LabWork1.Features.Task2;

namespace Study.LabWork1.UnitTests.Features.Task2
{
    internal class Testorder
    {
            // возврат всех этапов
            [Test]
            public void ProcessOrder_ReturnsAllStepsInCorrectOrder()
            {
                var facade = new PurchaseFacade();

                var result = facade.ProcessOrder();

                var expected = new List<string>
            {
                "Проверка наличия товара на складе",
                "Товар зарезервирован",
                "Платеж успешно оформлен",
                "Этикетка доставки создана",
                "Этикетка доставки распечатана",
                "Уведомление покупателю отправлено"
            };

                CollectionAssert.AreEqual(expected, result);
            }
        }
    }
