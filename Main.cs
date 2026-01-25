class Program
{
    static void Main()
    {
        Vehicle car = new Vehicle("Toyota", "Corolla", 2020);

        Console.WriteLine($"{car.Brand} {car.Model}, {car.Year}");
        car.StartEngine();
        car.StopEngine();

        Console.ReadLine();
    }
}

class Program
{
    static void Main() {
        Car car = new Car("BMW", "X5", 2021, 5, "Автомат");
        Motorcycle motorcycle = new Motorcycle("Yamaha", "R6", 2019, "Спортивный", false);

        Console.WriteLine($"{car.Brand} {car.Model}, {car.Year}, Дверей: {car.DoorsCount}, КПП: {car.TransmissionType}");
        car.StartEngine();
        car.StopEngine();

        Console.WriteLine();

        Console.WriteLine($"{motorcycle.Brand} {motorcycle.Model}, {motorcycle.Year}, Тип: {motorcycle.BodyType}, Бокс: {motorcycle.HasSideBox}");
        motorcycle.StartEngine();
        motorcycle.StopEngine();

        Console.ReadLine();
    }
}
