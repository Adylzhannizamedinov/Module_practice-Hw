using System;

namespace Module2Homework
{
    // ===== Задача 1: OrderService (DRY) =====
    public class OrderService
    {
        public void CreateOrder(string productName, int quantity, double price)
        {
            PrintOrderInfo(productName, quantity, price, "created");
        }

        public void UpdateOrder(string productName, int quantity, double price)
        {
            PrintOrderInfo(productName, quantity, price, "updated");
        }

        private void PrintOrderInfo(string productName, int quantity, double price, string action)
        {
            double totalPrice = quantity * price;
            Console.WriteLine($"Order for {productName} {action}. Total: {totalPrice}");
        }
    }

    // ===== Задача 2: Car и Truck с общим базовым классом (KISS) =====
    public class Vehicle
    {
        private readonly string _name;

        public Vehicle(string name)
        {
            _name = name;
        }

        public void Start()
        {
            Console.WriteLine($"{_name} is starting");
        }

        public void Stop()
        {
            Console.WriteLine($"{_name} is stopping");
        }
    }

    // ===== Задача 3: Calculator без лишних абстракций (KISS) =====
    public class Calculator
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }

    // ===== Задача 4: Singleton упрощённый (YAGNI) =====
    public class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        private Singleton() { }

        public static Singleton Instance => _instance;

        public void DoSomething()
        {
            Console.WriteLine("Doing something...");
        }
    }

    public class Client
    {
        public void Execute()
        {
            Singleton.Instance.DoSomething();
        }
    }

}