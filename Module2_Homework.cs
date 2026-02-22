// using System;
// using System.Linq;

// namespace Module2Homework
// {
//     // ===== Задача 1: Logger =====
//     public enum LogLevel
//     {
//         Error,
//         Warning,
//         Info
//     }

//     public class Logger
//     {
//         public void Log(LogLevel level, string message)
//         {
//             Console.WriteLine($"{level.ToString().ToUpper()}: {message}");
//         }
//     }

//     // Задача 2: DatabaseService и LoggingService 
//     public static class Config
//     {
//         public static string ConnectionString =
//             "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;";
//     }

//     public class DatabaseService
//     {
//         public void Connect()
//         {
//             string connectionString = Config.ConnectionString;
//             Console.WriteLine($"Connecting to database with: {connectionString}");
//         }
//     }

//     public class LoggingService
//     {
//         public void Log(string message)
//         {
//             string connectionString = Config.ConnectionString;
//             Console.WriteLine($"Logging message to database with: {connectionString}");
//             Console.WriteLine($"Message: {message}");
//         }
//     }

//     //  Задача 3: ProcessNumbers 
//     public class NumberProcessor
//     {
//         public void ProcessNumbers(int[] numbers)
//         {
//             if (numbers == null || numbers.Length == 0) return;

//             foreach (var number in numbers)
//             {
//                 if (number > 0)
//                 {
//                     Console.WriteLine(number);
//                 }
//             }
//         }

//         // ===== Задача 4: Избегание ненужного использования LINQ =====
//         public void PrintPositiveNumbers(int[] numbers)
//         {
//             if (numbers == null) return;

//             var positiveNumbers = numbers.Where(n => n > 0).OrderBy(n => n).ToList();
//             foreach (var number in positiveNumbers)
//             {
//                 Console.WriteLine(number);
//             }
//         }

//         // ===== Задача 5: Избегание избыточного использования исключений =====
//         public int Divide(int a, int b)
//         {
//             if (b == 0) return 0; // проще, без try/catch
//             return a / b;
//         }
//     }

    

//     // ===== Точка входа =====
//     class Program
//     {
//         static void Main()
//         {
//             // Задача 1: Logger
//             var logger = new Logger();
//             logger.Log(LogLevel.Error, "File not found");

//             // Задача 2: DatabaseService и LoggingService
//             var dbService = new DatabaseService();
//             dbService.Connect();

//             var logService = new LoggingService();
//             logService.Log("This is a test log");

//             // Задачи 3-5: NumberProcessor
//             var numbers = new int[] { 5, -2, 0, 7 };
//             var processor = new NumberProcessor();
//             processor.ProcessNumbers(numbers);
//             processor.PrintPositiveNumbers(numbers);

//             int result = processor.Divide(10, 0);
//             Console.WriteLine($"Divide result: {result}");

           
//         }
//     }
// }
