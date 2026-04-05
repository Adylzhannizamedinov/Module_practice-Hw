// using System;

// // Интерфейс
// interface IReport
// {
//     string Generate();
// }

// // Базовый отчет
// class SalesReport : IReport
// {
//     public string Generate() => "Sales: 100, 200";
// }

// // Декоратор
// class ReportDecorator : IReport
// {
//     protected IReport report;

//     public ReportDecorator(IReport report)
//     {
//         this.report = report;
//     }

//     public virtual string Generate() => report.Generate();
// }

// // Конкретные декораторы
// class DateFilter : ReportDecorator
// {
//     public DateFilter(IReport r) : base(r) { }

//     public override string Generate() =>
//         report.Generate() + " | Date filtered";
// }

// class CsvExport : ReportDecorator
// {
//     public CsvExport(IReport r) : base(r) { }

//     public override string Generate() =>
//         "CSV: " + report.Generate();
// }
// // Адаптер (доставка)
// // Интерфейс
// interface IDelivery
// {
//     void Deliver(string id);
// }

// // Внутренняя служба
// class InternalDelivery : IDelivery
// {
//     public void Deliver(string id)
//     {
//         Console.WriteLine("Internal delivery " + id);
//     }
// }

// // Сторонний сервис
// class ExternalService
// {
//     public void Send(int id)
//     {
//         Console.WriteLine("External delivery " + id);
//     }
// }

// // Адаптер
// class Adapter : IDelivery
// {
//     ExternalService service = new ExternalService();

//     public void Deliver(string id)
//     {
//         service.Send(int.Parse(id));
//     }
// }
// // Main (тест)
// class Program
// {
//     static void Main()
//     {
//         // Декоратор
//         IReport report = new SalesReport();
//         report = new DateFilter(report);
//         report = new CsvExport(report);

//         Console.WriteLine(report.Generate());

//         // Адаптер
//         IDelivery delivery = new Adapter();
//         delivery.Deliver("123");
//     }
// }
