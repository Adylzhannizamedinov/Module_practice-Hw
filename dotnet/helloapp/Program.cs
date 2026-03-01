// string name = "Tom";  // определяем переменную и инициализируем ее
  
// Console.WriteLine(name);    // Tom
  
// name = "Bob";       // меняем значение переменной
// Console.WriteLine(name);
// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
        

// string name = "Tom";
// int age = 33;
// bool isEmployed= false;
// double weight = 78.65;

// Console.WriteLine($"Имя:{name}");
// Console.WriteLine($"Возраст:{age}");
// Console.WriteLine($"Вес:{weight}");
// Console.WriteLine($"Работает:{isEmployed}");
//     }}

// float a = 3.14F;
// float b = 30.06f;

// uint a =10U;
// long b = 20L;
// ulong c = 30L;

// int a;
// a = 20;

// using System;

// class Program
// {
//     static void Main()
// {
//     Console.WriteLine("Hello");
//     Console.WriteLine("Welcome to C#");
// }
// }

//глава 2  консольный ввод вывод
//пример 1
// string hello = "hello world";
// Console.WriteLine(hello);
// Console.WriteLine("Welcome to C#!;");
// Console.WriteLine("Goodbye world...");
// Console.WriteLine(24.5);

// string name = "Tom";
// int age = 34;
// double height = 1.7;
// Console.WriteLine($"Имя:{name}  Возраст:{age} Рост:{height}");

// Task2
// string name ="Tom";
// int age = 34;
// double height = 1.7;
// Console.WriteLine("Имя:{0}  Возраст:{2}  Рост:{1}", name, height, age);


// public class Order{
//     public int  id{ get; set;}

//     public decemical Price{get;set;}
//     public string name{ get; set;}
//     public int Count  {get; set;}
//     public  int PaymentMathod{get;set;}
//     public deliverymathod{}
// }

// task3
// Console.Write("Write your name:");
// string? name = Console.ReadLine();
// Console.WriteLine($"Hello {name}");

// task4
// Console.Write("Введите имя: ");
// string? name = Console.ReadLine();
 
// Console.Write("Введите возраст: ");
// int age = Convert.ToInt32(Console.ReadLine());
 
// Console.Write("Введите рост: ");
// double height = Convert.ToDouble(Console.ReadLine());
 
// Console.Write("Введите размер зарплаты: ");
// decimal salary = Convert.ToDecimal(Console.ReadLine());
 
// Console.WriteLine($"Имя: {name}  Возраст: {age}  Рост: {height}м  Зарплата: {salary}$");

// арефмитические операции C#

// int a = 10;
// int b =  a+3;
// int s = 4;
// int z = s-1;
// int f = 10;
// int g = f*5;
// int q = 12;
// int w = q/2;
//  double e = 13;
//  double r = 2;
//  double  t =e/r;
// Console.WriteLine($"b= {b}, z={z}, g={g}, w={w}, t= {t}");

// public class Order
// {
//     public string ProductName { get; set; }
//     public int Quantity { get; set; }
//     public double Price { get; set; }

//     public class priceCalculator{
//     public double CalculateTotalPrice()
//     {
//         // Рассчет стоимости с учетом скидок
//         return Quantity * Price * 0.9;
//     }
//     }
//     public class  VoidService{

    
//     public void ProcessPayment(string paymentDetails)
//     {
//         // Логика обработки платежа
//         Console.WriteLine("Payment processed using: " + paymentDetails);
//     }
//     }
//     public class Notification{
//     public void SendConfirmationEmail(string email)
//     {
//         // Логика отправки уведомления
//         Console.WriteLine("Confirmation email sent to: " + email);
//     }
// }
// }


// public class Order {
//     public class Product{
//         public string name(get;,set;)
//     }
// }

// public   class Order{
//  public Order()
// }
// public List<Product>Producrts;
// public

// public class Order
// {
//     public string ProductName { get; set; }
//     public int Quantity { get; set; }
//     public double Price { get; set; }

//     public  class  pricecalculate{

    
//     public double CalculateTotalPrice()
//     {
//         // Рассчет стоимости с учетом скидок
//         return Quantity * Price * 0.9;
//     }
//     }
//     public class  PayService{

    
//     public void ProcessPayment(string paymentDetails)
//     {
//         // Логика обработки платежа
//         Console.WriteLine("Payment processed using: " + paymentDetails);
//     }
//     }

//     public class Notification{

    
//     public void SendConfirmationEmail(string email)
//     {
//         // Логика отправки уведомления
//         Console.WriteLine("Confirmation email sent to: " + email);
//     }
// }
// }

// public class Employee
// {
//     public string Name { get; set; }
//     public double BaseSalary { get; set; }
//     public string EmployeeType { get; set; } // "Permanent", "Contract", "Intern"
// }

// public class EmployeeSalaryCalculator
// {

// public interface IEmploySaklryCAlculator







//     public double CalculateSalary(Employee employee)
//     {
//         if (employee.EmployeeType == "Permanent")
//         {
//             return employee.BaseSalary * 1.2; // Permanent employee gets 20% bonus
//         }
//         else if (employee.EmployeeType == "Contract")
//         {
//             return employee.BaseSalary * 1.1; // Contract employee gets 10% bonus
//         }
//         else if (employee.EmployeeType == "Intern")
//         {
//             return employee.BaseSalary * 0.8; // Intern gets 80% of the base salary
//         }
//         else
//         {
//             throw new NotSupportedException("Employee type not supported");
//         }
//     }
// }

// public interface IPrinter
// {
//     void Print(string content);
//     void Scan(string content);
//     void Fax(string content);
// }

// public interface IPrinter
// {
//     void Print(string content);
// }

// public class AllInOnePrinter : IPrinter, IScanner, IFax
// {
//     public void Print(string content)
//     {
//         Console.WriteLine("Printing: " + content);
//     }

//     public void Scan(string content)
//     {
//         Console.WriteLine("Scanning: " + content);
//     }

//     public void Fax(string content){
//         Console.WriteLine("Faxing: " + content);
//     }
// }


// public class BasicPrinter : IPrinter
// {
//     public void Print(string content)
//     {
//         Console.WriteLine("Printing: " + content);
//     }
// }

// public class EmailSender
// {
//     public void SendEmail(string message)
//     {
//         Console.WriteLine("Email sent: " + message);
//     }
// }

// public class SmsSender
// {
//     public void SendSms(string message)
//     {
//         Console.WriteLine("SMS sent: " + message);
//     }
// }

// public class NotificationService
// {
//     public void SendNotification(string message) 
// }

// byte a = 6;
// int b = a+88;
// Условные выражения
// int a = 10;
// int b = 4;

// bool c = a == b;
// bool d = a != 10;

// Console.WriteLine(c);
// Console.WriteLine(d);

// int a = 10;
// int b= 5;
// bool c= a!=b;
// bool d =b!=10;
// Console.WriteLine(c);
// Console.WriteLine(d);

// int a = 10;
// int b = 2;
// bool c = a<b;
// Console.WriteLine(c);

// int a = 10;
// int b = 4;
// bool c = a>b;
// bool d = a >25;
// Console.WriteLine(c);
// Console.WriteLine(d);

// <=

// int a = 10;
// int b = 4;
// bool  c = a >= b;
// bool  d = a >= 25;
// Console.WriteLine(c);
// Console.WriteLine(d);

// >=

// int a = 10;;
// int b = b= 4;
// bool c = a>= b; 
// bool d = a>= 25;
// Console.WriteLine(c);
// Console.WriteLine(d);

// | logical operation

// bool x1 = (5>6)  | (4<6);
// bool x2 = (5>6)  | (4>6);
 
// bool x3 = (5>6) & (4<6);
// bool  x4 =  (5<6) & (4<6);

// bool x5 = (5>6) || (4<6);
// bool x6 =  (5<6) || (4>6);

// bool x7 = (5>6)  && (4<6);
// bool x8  = (5<6) && (4<6);

// bool a = true;
// bool b = !a;

// bool x9 = (5>6) ^(4<6);
// bool x10 = (50>6)^ (4/2<3);
// Console.WriteLine(x1);
// Console.WriteLine(x2);
// Console.WriteLine(x3);
// Console.WriteLine(x4);
// Console.WriteLine(x5);
// Console.WriteLine(x6);
// Console.WriteLine(x7);
// Console.WriteLine(x8);
// Console.WriteLine(x9);
// Console.WriteLine(x10);

//  if else 

// int a =8;
// int b = 4;
// if (a>b)
// {
//     Console.WriteLine($"Integer {a} bigger than {b}");
// }