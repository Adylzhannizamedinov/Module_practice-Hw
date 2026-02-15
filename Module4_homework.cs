using System;

namespace VehicleFactoryMethod
{
    // 1. Интерфейс
    public interface IVehicle
    {
        void Drive();
        void Refuel();
    }
    // 2. Конкретные транспортные средства
    public class Car : IVehicle
    {
        public string Brand { get; }
        public string Model { get; }
        public string FuelType { get; }

        public Car(string brand, string model, string fuelType)
        {
            Brand = brand;
            Model = model;
            FuelType = fuelType;
        }

        public void Drive()
        {
            Console.WriteLine($"🚗 Автомобиль {Brand} {Model} едет.");
        }

        public void Refuel()
        {
            Console.WriteLine($"⛽ Автомобиль заправляется топливом: {FuelType}.");
        }
    }

    public class Motorcycle : IVehicle
    {
        public string Type { get; }
        public int EngineCapacity { get; }

        public Motorcycle(string type, int engineCapacity)
        {
            Type = type;
            EngineCapacity = engineCapacity;
        }

        public void Drive()
        {
            Console.WriteLine($"🏍 Мотоцикл типа {Type} едет.");
        }

        public void Refuel()
        {
            Console.WriteLine($"⛽ Мотоцикл с объемом двигателя {EngineCapacity}cc заправляется.");
        }
    }

    public class Truck : IVehicle
    {
        public double LoadCapacity { get; }
        public int Axles { get; }

        public Truck(double loadCapacity, int axles)
        {
            LoadCapacity = loadCapacity;
            Axles = axles;
        }

        public void Drive()
        {
            Console.WriteLine($"🚛 Грузовик грузоподъемностью {LoadCapacity} тонн едет.");
        }

        public void Refuel()
        {
            Console.WriteLine("⛽ Грузовик заправляется дизельным топливом.");
        }
    }

    // Новый тип транспорта (расширяемость системы)
    public class Bus : IVehicle
    {
        public int PassengerCapacity { get; }
        public bool IsElectric { get; }

        public Bus(int passengerCapacity, bool isElectric)
        {
            PassengerCapacity = passengerCapacity;
            IsElectric = isElectric;
        }

        public void Drive()
        {
            Console.WriteLine($" Автобус на {PassengerCapacity} пассажиров движется.");
        }

        public void Refuel()
        {
            if (IsElectric)
                Console.WriteLine(" Автобус заряжается от электросети.");
            else
                Console.WriteLine(" Автобус заправляется топливом.");
        }
    }
    // 3. Абстрактная фабрика
    public abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle();
    }

    // ================================
    // 4. Конкретные фабрики
    // ================================

    public class CarFactory : VehicleFactory
    {
        private string _brand;
        private string _model;
        private string _fuelType;

        public CarFactory(string brand, string model, string fuelType)
        {
            _brand = brand;
            _model = model;
            _fuelType = fuelType;
        }

        public override IVehicle CreateVehicle()
        {
            return new Car(_brand, _model, _fuelType);
        }
    }

    public class MotorcycleFactory : VehicleFactory
    {
        private string _type;
        private int _engineCapacity;

        public MotorcycleFactory(string type, int engineCapacity)
        {
            _type = type;
            _engineCapacity = engineCapacity;
        }

        public override IVehicle CreateVehicle()
        {
            return new Motorcycle(_type, _engineCapacity);
        }
    }

    public class TruckFactory : VehicleFactory
    {
        private double _loadCapacity;
        private int _axles;

        public TruckFactory(double loadCapacity, int axles)
        {
            _loadCapacity = loadCapacity;
            _axles = axles;
        }

        public override IVehicle CreateVehicle()
        {
            return new Truck(_loadCapacity, _axles);
        }
    }

    public class BusFactory : VehicleFactory
    {
        private int _passengerCapacity;
        private bool _isElectric;

        public BusFactory(int passengerCapacity, bool isElectric)
        {
            _passengerCapacity = passengerCapacity;
            _isElectric = isElectric;
        }

        public override IVehicle CreateVehicle()
        {
            return new Bus(_passengerCapacity, _isElectric);
        }
    }

    // 5. Точка входа
    class Program
    {
        static void Main()
        {
            Console.WriteLine("===== Система создания транспорта (Factory Method) =====");
            Console.WriteLine("Выберите тип транспорта:");
            Console.WriteLine("1 - Автомобиль");
            Console.WriteLine("2 - Мотоцикл");
            Console.WriteLine("3 - Грузовик");
            Console.WriteLine("4 - Автобус");

            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            VehicleFactory factory = null;

            switch (choice)
            {
                case "1":
                    Console.Write("Марка: ");
                    string brand = Console.ReadLine();

                    Console.Write("Модель: ");
                    string model = Console.ReadLine();

                    Console.Write("Тип топлива: ");
                    string fuel = Console.ReadLine();

                    factory = new CarFactory(brand, model, fuel);
                    break;

                case "2":
                    Console.Write("Тип мотоцикла: ");
                    string type = Console.ReadLine();

                    Console.Write("Объем двигателя (cc): ");
                    int capacity = int.Parse(Console.ReadLine());

                    factory = new MotorcycleFactory(type, capacity);
                    break;

                case "3":
                    Console.Write("Грузоподъемность (тонны): ");
                    double load = double.Parse(Console.ReadLine());

                    Console.Write("Количество осей: ");
                    int axles = int.Parse(Console.ReadLine());

                    factory = new TruckFactory(load, axles);
                    break;

                case "4":
                    Console.Write("Вместимость пассажиров: ");
                    int passengers = int.Parse(Console.ReadLine());

                    Console.Write("Электрический? (true/false): ");
                    bool electric = bool.Parse(Console.ReadLine());

                    factory = new BusFactory(passengers, electric);
                    break;

                default:
                    Console.WriteLine("❌ Неверный выбор.");
                    return;
            }

            IVehicle vehicle = factory.CreateVehicle();

            Console.WriteLine("\n--- Транспорт создан ---");
            vehicle.Drive();
            vehicle.Refuel();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
