using System;
using System.Collections.Generic;
using System.Text;
//объединяет все этапы 

namespace Study.LabWork1.Features.Task2
{
    public class PurchaseFacade
    {
        private readonly PurchaseProcessor purchaseProcessor;
        private readonly ShippingService shippingService;
        private readonly BuyerNotificationService buyerNotificationService;
        //конструктор
        public PurchaseFacade()
        {
            purchaseProcessor = new PurchaseProcessor();
            shippingService = new ShippingService();
            buyerNotificationService = new BuyerNotificationService();
        }
        //метод всего процесса оформления заказа
        public List<string> ProcessOrder()
        {
            var steps = new List<string>();

            steps.Add(purchaseProcessor.CheckAvailability());
            steps.Add(purchaseProcessor.ReserveItem());
            steps.Add(purchaseProcessor.ProcessPayment());
            steps.Add(shippingService.CreateLabel());
            steps.Add(shippingService.PrintLabel());
            steps.Add(buyerNotificationService.SendNotification());

            return steps;
        }
    }
}
