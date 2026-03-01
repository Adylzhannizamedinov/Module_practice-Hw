// using System;
// using System.Collections.Generic;
// using System.IO;


// // 1. SINGLETON
// public sealed class ConfigurationManager
// {
//     private static ConfigurationManager _instance;
//     private static readonly object _lock = new object();

//     private Dictionary<string, string> _settings;

//     private ConfigurationManager()
//     {
//         _settings = new Dictionary<string, string>();
//     }

//     public static ConfigurationManager GetInstance()
//     {
//         lock (_lock)
//         {
//             if (_instance == null)
//                 _instance = new ConfigurationManager();

//             return _instance;
//         }
//     }

//     public void SetSetting(string key, string value)
//     {
//         _settings[key] = value;
//     }

//     public string GetSetting(string key)
//     {
//         if (_settings.ContainsKey(key))
//             return _settings[key];

//         throw new Exception("Настройка не найдена");
//     }
// }

// // 2. BUILDER
// public class Report
// {
//     public string Header { get; set; }
//     public string Content { get; set; }
//     public string Footer { get; set; }

//     public void Show()
//     {
//         Console.WriteLine(Header);
//         Console.WriteLine(Content);
//         Console.WriteLine(Footer);
//     }
// }

// public interface IReportBuilder
// {
//     void SetHeader(string header);
//     void SetContent(string content);
//     void SetFooter(string footer);
//     Report GetReport();
// }

// public class TextReportBuilder : IReportBuilder
// {
//     private Report _report = new Report();

//     public void SetHeader(string header) => _report.Header = "TEXT: " + header;
//     public void SetContent(string content) => _report.Content = content;
//     public void SetFooter(string footer) => _report.Footer = footer;
//     public Report GetReport() => _report;
// }

// public class HtmlReportBuilder : IReportBuilder
// {
//     private Report _report = new Report();

//     public void SetHeader(string header) => _report.Header = $"<h1>{header}</h1>";
//     public void SetContent(string content) => _report.Content = $"<p>{content}</p>";
//     public void SetFooter(string footer) => _report.Footer = $"<footer>{footer}</footer>";
//     public Report GetReport() => _report;
// }

// public class ReportDirector
// {
//     public void ConstructReport(IReportBuilder builder)
//     {
//         builder.SetHeader("Report Header");
//         builder.SetContent("Report Content");
//         builder.SetFooter("Report Footer");
//     }
// }

// // 3. PROTOTYPE
// public class Product : ICloneable
// {
//     public string Name { get; set; }
//     public double Price { get; set; }
//     public int Quantity { get; set; }

//     public object Clone()
//     {
//         return new Product
//         {
//             Name = this.Name,
//             Price = this.Price,
//             Quantity = this.Quantity
//         };
//     }
// }

// public class Discount : ICloneable
// {
//     public string Description { get; set; }
//     public double Percent { get; set; }

//     public object Clone()
//     {
//         return new Discount
//         {
//             Description = this.Description,
//             Percent = this.Percent
//         };
//     }
// }

// public class Order : ICloneable
// {
//     public List<Product> Products { get; set; } = new List<Product>();
//     public double DeliveryCost { get; set; }
//     public Discount Discount { get; set; }
//     public string PaymentMethod { get; set; }

//     public object Clone()
//     {
//         Order clone = (Order)this.MemberwiseClone();

//         clone.Products = new List<Product>();
//         foreach (var product in this.Products)
//             clone.Products.Add((Product)product.Clone());

//         clone.Discount = (Discount)this.Discount.Clone();

//         return clone;
//     }

//     public void Show()
//     {
//         Console.WriteLine("Order:");
//         foreach (var p in Products)
//             Console.WriteLine($"{p.Name} - {p.Price} x {p.Quantity}");

//         Console.WriteLine($"Delivery: {DeliveryCost}");
//         Console.WriteLine($"Discount: {Discount.Description}");
//         Console.WriteLine($"Payment: {PaymentMethod}");
//     }
// }

// // MAIN (ОДИН!)
// class Program
// {
//     static void Main()
//     {
//         // -------- Singleton --------
//         Console.WriteLine("=== Singleton ===");
//         var config1 = ConfigurationManager.GetInstance();
//         var config2 = ConfigurationManager.GetInstance();

//         config1.SetSetting("Theme", "Dark");
//         Console.WriteLine(config2.GetSetting("Theme"));
//         Console.WriteLine(object.ReferenceEquals(config1, config2));

//         // -------- Builder --------
//         Console.WriteLine("\n=== Builder ===");
//         ReportDirector director = new ReportDirector();

//         IReportBuilder textBuilder = new TextReportBuilder();
//         director.ConstructReport(textBuilder);
//         textBuilder.GetReport().Show();

//         IReportBuilder htmlBuilder = new HtmlReportBuilder();
//         director.ConstructReport(htmlBuilder);
//         htmlBuilder.GetReport().Show();

//         // -------- Prototype --------
//         Console.WriteLine("\n=== Prototype ===");

//         Order order1 = new Order();
//         order1.Products.Add(new Product { Name = "Laptop", Price = 1000, Quantity = 1 });
//         order1.DeliveryCost = 50;
//         order1.Discount = new Discount { Description = "New Year", Percent = 10 };
//         order1.PaymentMethod = "Card";

//         Order order2 = (Order)order1.Clone();
//         order2.Products[0].Name = "Tablet";

//         order1.Show();
//         order2.Show();
//     }
// // }