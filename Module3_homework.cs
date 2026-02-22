// using System;

// namespace SOLID_Examples
// {
//     // Задание1  SRP
//     public class Order
//     {
//         public string ProductName { get; set; }
//         public int Quantity { get; set; }
//         public double Price { get; set; }
//     }

//     public class OrderPriceCalculator
//     {
//         public double CalculateTotalPrice(Order order)
//         {
//             return order.Quantity * order.Price * 0.9; // скидка 10%
//         }
//     }

//     public class PaymentProcessor
//     {
//         public void ProcessPayment(string paymentDetails)
//         {
//             Console.WriteLine("Payment processed using: " + paymentDetails);
//         }
//     }

//     public class NotificationService
//     {
//         public void SendConfirmationEmail(string email)
//         {
//             Console.WriteLine("Confirmation email sent to: " + email);
//         }
//     }

// //    Задание2  OCP
//     public class Employee
//     {
//         public string Name { get; set; }
//         public double BaseSalary { get; set; }
//     }

//     public interface ISalaryCalculator
//     {
//         double CalculateSalary(Employee employee);
//     }

//     public class PermanentEmployeeSalary : ISalaryCalculator
//     {
//         public double CalculateSalary(Employee employee) => employee.BaseSalary * 1.2;
//     }

//     public class ContractEmployeeSalary : ISalaryCalculator
//     {
//         public double CalculateSalary(Employee employee) => employee.BaseSalary * 1.1;
//     }

// //    Задание3 ISP
//     public interface IPrinter
//     {
//         void Print(string content);
//     }

//     public interface IScanner
//     {
//         void Scan(string content);
//     }

//     public interface IFax
//     {
//         void Fax(string content);
//     }

//     public class AllInOnePrinter : IPrinter, IScanner, IFax
//     {
//         public void Print(string content) => Console.WriteLine("Printing: " + content);
//         public void Scan(string content) => Console.WriteLine("Scanning: " + content);
//         public void Fax(string content) => Console.WriteLine("Faxing: " + content);
//     }

//     public class BasicPrinter : IPrinter, IScanner
//     {
//         public void Print(string content) => Console.WriteLine("Printing: " + content);
//         public void Scan(string content) => Console.WriteLine("Scanning: " + content);
//     }

    
//     // Задание4 DIP
    
//     public interface IMessageSender
//     {
//         void SendMessage(string message);
//     }

//     public class EmailSender : IMessageSender
//     {
//         public void SendMessage(string message) => Console.WriteLine("Email sent: " + message);
//     }

//     public class SmsSender : IMessageSender
//     {
//         public void SendMessage(string message) => Console.WriteLine("SMS sent: " + message);
//     }

//     public class NotificationServiceDIP
//     {
//         private readonly IMessageSender[] senders;
//         public NotificationServiceDIP(params IMessageSender[] senders) => this.senders = senders;

//         public void SendNotification(string message)
//         {
//             foreach (var sender in senders)
//                 sender.SendMessage(message);
//         }
//     }

    
//     // 5 Main
   
//     class Program
//     {
//         static void Main()
//         {
//             Console.WriteLine("=== SRP ===");
//             var order = new Order { ProductName = "Laptop", Quantity = 2, Price = 50000 };
//             var calculator = new OrderPriceCalculator();
//             Console.WriteLine($"Total price: {calculator.CalculateTotalPrice(order)}");
//             var payment = new PaymentProcessor();
//             payment.ProcessPayment("Credit Card");
//             var notifier = new NotificationService();
//             notifier.SendConfirmationEmail("customer@example.com");
//             Console.WriteLine();

//             Console.WriteLine("=== OCP ===");
//             var employee = new Employee { Name = "Alice", BaseSalary = 100000 };
//             ISalaryCalculator salaryCalc = new PermanentEmployeeSalary();
//             Console.WriteLine($"Salary of {employee.Name}: {salaryCalc.CalculateSalary(employee)}");
//             Console.WriteLine();

//             Console.WriteLine("=== ISP ===");
//             IPrinter printer = new AllInOnePrinter();
//             printer.Print("Document1");
//             IScanner scanner = new AllInOnePrinter();
//             scanner.Scan("Document1");
//             Console.WriteLine();

//             Console.WriteLine("=== DIP ===");
//             var dipNotifier = new NotificationServiceDIP(new EmailSender(), new SmsSender());
//             dipNotifier.SendNotification("Hello user!");
//         }
//     }
// }
