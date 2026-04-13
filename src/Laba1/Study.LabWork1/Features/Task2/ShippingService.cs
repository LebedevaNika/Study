using System;
using System.Collections.Generic;
using System.Text;
// подготовка доставки
namespace Study.LabWork1.Features.Task2
{
    public class ShippingService
    {
        public string CreateLabel()
        {
            return "Этикетка доставки создана";
        }

        public string PrintLabel()
        {
            return "Этикетка доставки распечатана";
        }
    }
}
