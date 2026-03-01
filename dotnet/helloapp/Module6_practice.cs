using System;
using System.Collections.Generic;

internal class Program
{
    // STRATEGY
    public enum TravelClass
    {
        Economy,
        Business
    }

    // Интерфейс стратегии
    public interface ICostCalculationStrategy
    {
        double CalculateCost(double distance, int passengers,
                             TravelClass travelClass, bool hasDiscount);
    }

    // Самолет 
    public class PlaneStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(double distance, int passengers,
                                    TravelClass travelClass, bool hasDiscount)
        {
            double pricePerKm = 0.5;
            double total = distance * pricePerKm;

            if (travelClass == TravelClass.Business)
                total *= 2;

            total *= passengers;

            if (hasDiscount)
                total *= 0.9; // 10% скидка

            return total;
        }
    }

    //  Поезд 
    public class TrainStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(double distance, int passengers,
                                    TravelClass travelClass, bool hasDiscount)
        {
            double pricePerKm = 0.3;
            double total = distance * pricePerKm;

            if (travelClass == TravelClass.Business)
                total *= 1.5;

            total *= passengers;

            if (hasDiscount)
                total *= 0.9;

            return total;
        }
    }

    //  Автобус 
    public class BusStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(double distance, int passengers,
                                    TravelClass travelClass, bool hasDiscount)
        {
            double pricePerKm = 0.2;
            double total = distance * pricePerKm;

            total *= passengers;

            if (hasDiscount)
                total *= 0.9;

            return total;
        }
    }

    // Контекст
    public class TravelBookingContext
    {
        private ICostCalculationStrategy strategy;

        public void SetStrategy(ICostCalculationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public double GetCost(double distance, int passengers,
                              TravelClass travelClass, bool hasDiscount)
        {
            if (strategy == null)
                throw new Exception("Стратегия не выбрана!");

            return strategy.CalculateCost(distance, passengers,
                                          travelClass, hasDiscount);
        }
    }

    // OBSERVER
    public interface IObserver
    {
        void Update(string stockName, double price);
        string Name { get; }
    }

    public interface ISubject
    {
        void Subscribe(string stockName, IObserver observer);
        void Unsubscribe(string stockName, IObserver observer);
        void ChangePrice(string stockName, double newPrice);
    }

    public class StockExchange : ISubject
    {
        private Dictionary<string, List<IObserver>> observers =
            new Dictionary<string, List<IObserver>>();

        public void AddStock(string name)
        {
            observers[name] = new List<IObserver>();
        }

        public void Subscribe(string stockName, IObserver observer)
        {
            observers[stockName].Add(observer);
            Console.WriteLine(observer.Name + " подписался на " + stockName);
        }

        public void Unsubscribe(string stockName, IObserver observer)
        {
            observers[stockName].Remove(observer);
        }

        public void ChangePrice(string stockName, double newPrice)
        {
            Console.WriteLine("Цена акции " + stockName + " изменилась: " + newPrice);

            foreach (var observer in observers[stockName])
            {
                observer.Update(stockName, newPrice);
            }
        }
    }

    // Трейдер
    public class Trader : IObserver
    {
        public string Name { get; private set; }

        public Trader(string name)
        {
            Name = name;
        }

        public void Update(string stockName, double price)
        {
            Console.WriteLine("Трейдер " + Name +
                              " получил уведомление: " +
                              stockName + " = " + price);
        }
    }
    // Робот
    public class Robot : IObserver
    {
        public string Name { get; private set; }
        private double limit;

        public Robot(string name, double limit)
        {
            Name = name;
            this.limit = limit;
        }

        public void Update(string stockName, double price)
        {
            if (price > limit)
                Console.WriteLine("Робот " + Name + " продает " + stockName);
            else
                Console.WriteLine("Робот " + Name + " покупает " + stockName);
        }
    }
    //MAIN 
    static void Main(string[] args)
    {
        Console.WriteLine("===== СИСТЕМА БРОНИРОВАНИЯ =====");

        TravelBookingContext context = new TravelBookingContext();

        double distance = 1000;
        int passengers = 2;
        TravelClass travelClass = TravelClass.Business;
        bool hasDiscount = true;

        // Самолет
        context.SetStrategy(new PlaneStrategy());
        Console.WriteLine("Самолет: " +
            context.GetCost(distance, passengers, travelClass, hasDiscount));

        // Поезд
        context.SetStrategy(new TrainStrategy());
        Console.WriteLine("Поезд: " +
            context.GetCost(distance, passengers, travelClass, hasDiscount));

        // Автобус
        context.SetStrategy(new BusStrategy());
        Console.WriteLine("Автобус: " +
            context.GetCost(distance, passengers, travelClass, hasDiscount));


        Console.WriteLine("\n===== БИРЖА =====");

        StockExchange exchange = new StockExchange();
        exchange.AddStock("AAPL");

        Trader trader = new Trader("Иван");
        Robot robot = new Robot("R2D2", 200);

        exchange.Subscribe("AAPL", trader);
        exchange.Subscribe("AAPL", robot);

        exchange.ChangePrice("AAPL", 150);
        exchange.ChangePrice("AAPL", 250);
    }
}