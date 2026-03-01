using System;
using System.Collections.Generic;

internal class Program
{
    //STRATEGY PATTERN
    // Интерфейс стратегии оплаты
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    // Оплата банковской картой
    public class CardPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Оплата {amount} с помощью банковской карты.");
        }
    }

    // Оплата через PayPal
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Оплата {amount} через PayPal.");
        }
    }

    // Оплата криптовалютой
    public class CryptoPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Оплата {amount} криптовалютой.");
        }
    }

    // Контекст оплаты
    public class PaymentContext
    {
        private IPaymentStrategy _strategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public void PayAmount(double amount)
        {
            if (_strategy == null)
                throw new Exception("Стратегия оплаты не выбрана!");
            
            _strategy.Pay(amount);
        }
    }

    // OBSERVER PATTERN

    public interface IObserver
    {
        void Update(string currency, double rate);
        string Name { get; }
    }

    public interface ISubject
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify(string currency, double rate);
    }

    // Субъект — обмен валют
    public class CurrencyExchange : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"{observer.Name} подписался на обновления валют.");
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"{observer.Name} отписался от обновлений валют.");
        }

        public void Notify(string currency, double rate)
        {
            foreach (var obs in _observers)
            {
                obs.Update(currency, rate);
            }
        }

        // Метод для изменения курса валюты
        public void ChangeRate(string currency, double rate)
        {
            Console.WriteLine($"\nКурс {currency} изменился на {rate}");
            Notify(currency, rate);
        }
    }

    // Наблюдатель 1 — простой вывод в консоль
    public class ConsoleObserver : IObserver
    {
        public string Name { get; private set; }
        public ConsoleObserver(string name) { Name = name; }

        public void Update(string currency, double rate)
        {
            Console.WriteLine($"{Name} видит: {currency} = {rate}");
        }
    }

    // Наблюдатель 2 — уведомление если курс выше 70
    public class AlertObserver : IObserver
    {
        public string Name { get; private set; }
        public AlertObserver(string name) { Name = name; }

        public void Update(string currency, double rate)
        {
            if (rate > 70)
                Console.WriteLine($"{Name} ALERT: {currency} превышает 70! ({rate})");
        }
    }

    // Наблюдатель 3 — всегда сохраняет последний курс
    public class SaveRateObserver : IObserver
    {
        public string Name { get; private set; }
        public double LastRate { get; private set; }

        public SaveRateObserver(string name) { Name = name; }

        public void Update(string currency, double rate)
        {
            LastRate = rate;
            Console.WriteLine($"{Name} сохранил новый курс {currency}: {LastRate}");
        }
    }

    // MAIN

    static void Main(string[] args)
    {
        Console.WriteLine("===== ПАТТЕРН СТРАТЕГИЯ: ОПЛАТА =====");
        PaymentContext payment = new PaymentContext();

        double amount = 100;

        payment.SetPaymentStrategy(new CardPayment());
        payment.PayAmount(amount);

        payment.SetPaymentStrategy(new PayPalPayment());
        payment.PayAmount(amount);

        payment.SetPaymentStrategy(new CryptoPayment());
        payment.PayAmount(amount);

        Console.WriteLine("\n===== ПАТТЕРН НАБЛЮДАТЕЛЬ: ОБМЕН ВАЛЮТ =====");
        CurrencyExchange exchange = new CurrencyExchange();

        var obs1 = new ConsoleObserver("Observer1");
        var obs2 = new AlertObserver("Observer2");
        var obs3 = new SaveRateObserver("Observer3");

        exchange.Subscribe(obs1);
        exchange.Subscribe(obs2);
        exchange.Subscribe(obs3);

        exchange.ChangeRate("USD", 65);
        exchange.ChangeRate("EUR", 75);

        exchange.Unsubscribe(obs1);
        exchange.ChangeRate("GBP", 80);
    }
}