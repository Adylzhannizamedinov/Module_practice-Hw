using System;

namespace DocumentFactoryMethod
{
    // 1. Интерфейс Document
    public interface Document
    {
        void Open();
    }

    // 2. Конкретные документы

    public class Report : Document
    {
        public void Open()
        {
            Console.WriteLine("📊 Открывается отчет...");
        }
    }

    public class Resume : Document
    {
        public void Open()
        {
            Console.WriteLine("📄 Открывается резюме...");
        }
    }

    public class Letter : Document
    {
        public void Open()
        {
            Console.WriteLine("✉ Открывается письмо...");
        }
    }

    // Новый тип документа
    public class Invoice : Document
    {
        public void Open()
        {
            Console.WriteLine("🧾 Открывается счет (Invoice)...");
        }
    }

    // 3. Абстрактный класс Creator
    public abstract class DocumentCreator
    {
        // Фабричный метод
        public abstract Document CreateDocument();

        // Общий метод, использующий фабричный
        public void OpenDocument()
        {
            Document doc = CreateDocument();
            doc.Open();
        }
    }

    // 4. Конкретные фабрики

    public class ReportCreator : DocumentCreator
    {
        public override Document CreateDocument()
        {
            return new Report();
        }
    }

    public class ResumeCreator : DocumentCreator
    {
        public override Document CreateDocument()
        {
            return new Resume();
        }
    }

    public class LetterCreator : DocumentCreator
    {
        public override Document CreateDocument()
        {
            return new Letter();
        }
    }

    public class InvoiceCreator : DocumentCreator
    {
        public override Document CreateDocument()
        {
            return new Invoice();
        }
    }

    // 5. Главный класс (тестирование)
    class Program
    {
        static void Main()
        {
            Console.WriteLine("===== Система создания документов (Factory Method) =====");
            Console.WriteLine("Выберите тип документа:");
            Console.WriteLine("1 - Отчет");
            Console.WriteLine("2 - Резюме");
            Console.WriteLine("3 - Письмо");
            Console.WriteLine("4 - Счет (Invoice)");

            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            DocumentCreator creator = null;

            switch (choice)
            {
                case "1":
                    creator = new ReportCreator();
                    break;
                case "2":
                    creator = new ResumeCreator();
                    break;
                case "3":
                    creator = new LetterCreator();
                    break;
                case "4":
                    creator = new InvoiceCreator();
                    break;
                default:
                    Console.WriteLine("❌ Неверный выбор.");
                    return;
            }

            Console.WriteLine("\nДокумент создается...");
            creator.OpenDocument();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
