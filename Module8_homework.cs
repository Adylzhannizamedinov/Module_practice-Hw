// // 1. Базовый интерфейс
// public interface IBeverage
// {
//     string GetDescription();
//     double Cost();
// }
// // 2. Базовые напитки
// public class Espresso : IBeverage
// {
//     public string GetDescription() => "Espresso";
//     public double Cost() => 2.0;
// }

// public class Tea : IBeverage
// {
//     public string GetDescription() => "Tea";
//     public double Cost() => 1.5;
// }

// public class Latte : IBeverage
// {
//     public string GetDescription() => "Latte";
//     public double Cost() => 2.5;
// }

// public class Mocha : IBeverage
// {
//     public string GetDescription() => "Mocha";
//     public double Cost() => 3.0;
// }
// // 3. Абстрактный декоратор
// public abstract class BeverageDecorator : IBeverage
// {
//     protected IBeverage _beverage;

//     public BeverageDecorator(IBeverage beverage)
//     {
//         _beverage = beverage;
//     }

//     public virtual string GetDescription()
//     {
//         return _beverage.GetDescription();
//     }

//     public virtual double Cost()
//     {
//         return _beverage.Cost();
//     }
// }
// // 4. Конкретные декораторы (добавки)
// public class Milk : BeverageDecorator
// {
//     public Milk(IBeverage beverage) : base(beverage) { }

//     public override string GetDescription() =>
//         _beverage.GetDescription() + ", Milk";

//     public override double Cost() =>
//         _beverage.Cost() + 0.5;
// }

// public class Sugar : BeverageDecorator
// {
//     public Sugar(IBeverage beverage) : base(beverage) { }

//     public override string GetDescription() =>
//         _beverage.GetDescription() + ", Sugar";

//     public override double Cost() =>
//         _beverage.Cost() + 0.2;
// }

// public class WhippedCream : BeverageDecorator
// {
//     public WhippedCream(IBeverage beverage) : base(beverage) { }

//     public override string GetDescription() =>
//         _beverage.GetDescription() + ", Whipped Cream";

//     public override double Cost() =>
//         _beverage.Cost() + 0.7;
// }
// // 5. Дополнительные добавки
// public class Caramel : BeverageDecorator
// {
//     public Caramel(IBeverage beverage) : base(beverage) { }

//     public override string GetDescription() =>
//         _beverage.GetDescription() + ", Caramel";

//     public override double Cost() =>
//         _beverage.Cost() + 0.6;
// }

// public class Chocolate : BeverageDecorator
// {
//     public Chocolate(IBeverage beverage) : base(beverage) { }

//     public override string GetDescription() =>
//         _beverage.GetDescription() + ", Chocolate";

//     public override double Cost() =>
//         _beverage.Cost() + 0.8;
// }
// // 6. Клиентский код
// class Program
// {
//     static void Main()
//     {
//         IBeverage drink = new Espresso();

//         drink = new Milk(drink);
//         drink = new Sugar(drink);
//         drink = new WhippedCream(drink);

//         Console.WriteLine(drink.GetDescription());
//         Console.WriteLine("Total: $" + drink.Cost());

//         // Второй пример
//         IBeverage drink2 = new Latte();
//         drink2 = new Caramel(drink2);
//         drink2 = new Chocolate(drink2);

//         Console.WriteLine("\n" + drink2.GetDescription());
//         Console.WriteLine("Total: $" + drink2.Cost());
//     }
// }