using System;
using System.Collections.Generic;
using System.Text;

//проверка товара, резервирование и оплата
namespace Study.LabWork1.Features.Task2
{
    public class PurchaseProcessor
    {
        public string CheckAvailability()
        {
            return "Проверка наличия товара на складе";
        }

        public string ReserveItem()
        {
            return "Товар зарезервирован";
        }

        public string ProcessPayment()
        {
            return "Платеж успешно оформлен";
        }
    }
}
