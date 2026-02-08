using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementSOLID
{
    // задание 1 классы закааза
    class OrderItem
    {
        public string Name { get; }
        public int Quantity { get; }
        public double Price { get; }

        public OrderItem(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public double TotalPrice => Quantity * Price;
    }

    class Order
    {
        private List<OrderItem> items = new List<OrderItem>();
        private DiscountCalculator discountCalculator;

       public IPayment? Payment { get; set; }
       public IDelivery? Delivery { get; set; }

        public Order(DiscountCalculator discountCalculator)
        {
            this.discountCalculator = discountCalculator;
        }

        public void AddItem(string name, int quantity, double price)
        {
            items.Add(new OrderItem(name, quantity, price));
        }

        public double CalculateTotal()
        {
            double total = items.Sum(i => i.TotalPrice);
            double discount = discountCalculator.CalculateDiscount(total);
            return total - discount;
        }
    }

    //  задание 2 оплата
    interface IPayment
    {
        void ProcessPayment(double amount);
    }

    class CreditCardPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Оплата кредитной картой: {amount} ₽");
        }
    }

    class PayPalPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Оплата через PayPal: {amount} ₽");
        }
    }

    class BankTransferPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Банковский перевод: {amount} ₽");
        }
    }

    // задание3 доставка
    interface IDelivery
    {
        void Deliver();
    }

    class CourierDelivery : IDelivery
    {
        public void Deliver()
        {
            Console.WriteLine("Доставка курьером");
        }
    }

    class PostDelivery : IDelivery
    {
        public void Deliver()
        {
            Console.WriteLine("Доставка почтой");
        }
    }

    class PickUpPointDelivery : IDelivery
    {
        public void Deliver()
        {
            Console.WriteLine("Самовывоз из пункта выдачи");
        }
    }

    // задание4 увидомление
    interface INotification
    {
        void Send(string message);
    }

    class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
    }

    class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS: {message}");
        }
    }

    // задание5 расчеь стоимости
    interface IDiscountRule
    {
        double Calculate(double total);
    }

    class DiscountCalculator
    {
        private List<IDiscountRule> rules = new List<IDiscountRule>();

        public void AddRule(IDiscountRule rule)
        {
            rules.Add(rule);
        }

        public double CalculateDiscount(double total)
        {
            return rules.Sum(r => r.Calculate(total));
        }
    }

    class PercentageDiscount : IDiscountRule
    {
        private double percent;

        public PercentageDiscount(double percent)
        {
            this.percent = percent;
        }

        public double Calculate(double total)
        {
            return total * percent / 100;
        }
    }

    class FixedDiscount : IDiscountRule
    {
        private double amount;

        public FixedDiscount(double amount)
        {
            this.amount = amount;
        }

        public double Calculate(double total)
        {
            return total >= amount ? amount : 0;
        }
    }

    // задние6 пример использования

    class Program
    {
        static void Main()
        {
            // Скидки
            DiscountCalculator discountCalculator = new DiscountCalculator();
            discountCalculator.AddRule(new PercentageDiscount(10));
            discountCalculator.AddRule(new FixedDiscount(500));

            // Заказ
            Order order = new Order(discountCalculator);
            order.AddItem("Телефон", 1, 30000);
            order.AddItem("Наушники", 2, 4000);

            // Оплата и доставка
            order.Payment = new CreditCardPayment();
            order.Delivery = new CourierDelivery();

            double total = order.CalculateTotal();

            // Оформление
            order.Payment.ProcessPayment(total);
            order.Delivery.Deliver();

            // Уведомление
            INotification notification = new EmailNotification();
            notification.Send("Ваш заказ успешно оформлен");

            Console.WriteLine($"Итоговая сумма заказа: {total} Тг");
        }
    }
}
