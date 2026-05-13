// using System;
// using System.Collections.Generic;

// //  HOTEL FACADE 

// class RoomBookingSystem
// {
//     public void BookRoom(string name) => Console.WriteLine($"Номер забронирован для {name}");
//     public void CancelBooking(string name) => Console.WriteLine($"Бронь отменена для {name}");
// }

// class RestaurantSystem
// {
//     public void BookTable(string name) => Console.WriteLine($"Стол забронирован для {name}");
//     public void OrderFood(string dish) => Console.WriteLine($"Заказано блюдо: {dish}");
// }

// class EventManagementSystem
// {
//     public void BookHall(string eventName) => Console.WriteLine($"Зал забронирован для: {eventName}");
//     public void OrderEquipment(string equipment) => Console.WriteLine($"Оборудование: {equipment}");
// }

// class CleaningService
// {
//     public void ScheduleCleaning(string room) => Console.WriteLine($"Уборка запланирована для {room}");
//     public void CleanNow(string room) => Console.WriteLine($"Уборка выполнена в {room}");
// }

// class TaxiService
// {
//     public void CallTaxi(string name) => Console.WriteLine($"Такси вызвано для {name}");
// }

// class HotelFacade
// {
//     private RoomBookingSystem room = new RoomBookingSystem();
//     private RestaurantSystem restaurant = new RestaurantSystem();
//     private EventManagementSystem events = new EventManagementSystem();
//     private CleaningService cleaning = new CleaningService();
//     private TaxiService taxi = new TaxiService();

//     public void BookFullService(string name)
//     {
//         Console.WriteLine("\n=== Полный сервис ===");
//         room.BookRoom(name);
//         restaurant.OrderFood("Завтрак");
//         cleaning.ScheduleCleaning("номер " + name);
//     }

//     public void OrganizeEvent(string eventName, string guest)
//     {
//         Console.WriteLine("\n=== Мероприятие ===");
//         events.BookHall(eventName);
//         events.OrderEquipment("Проектор");
//         room.BookRoom(guest);
//     }

//     public void BookDinnerWithTaxi(string name)
//     {
//         Console.WriteLine("\n=== Ужин ===");
//         restaurant.BookTable(name);
//         restaurant.OrderFood("Стейк");
//         taxi.CallTaxi(name);
//     }

//     public void CancelRoom(string name)
//     {
//         room.CancelBooking(name);
//     }

//     public void RequestCleaning(string roomName)
//     {
//         cleaning.CleanNow(roomName);
//     }
// }

// //  COMPOSITE 

// abstract class OrganizationComponent
// {
//     public string Name;

//     public OrganizationComponent(string name)
//     {
//         Name = name;
//     }

//     public abstract void Display(int depth = 0);
//     public abstract double GetBudget();
//     public abstract int GetEmployeeCount();
// }

// class Employee : OrganizationComponent
// {
//     public string Position;
//     public double Salary;

//     public Employee(string name, string position, double salary)
//         : base(name)
//     {
//         Position = position;
//         Salary = salary;
//     }

//     public void SetSalary(double newSalary)
//     {
//         Salary = newSalary;
//     }

//     public override void Display(int depth = 0)
//     {
//         Console.WriteLine($"{new string('-', depth)} {Name} ({Position}) - {Salary}");
//     }

//     public override double GetBudget() => Salary;

//     public override int GetEmployeeCount() => 1;
// }

// class Contractor : OrganizationComponent
// {
//     public double Payment;

//     public Contractor(string name, double payment) : base(name)
//     {
//         Payment = payment;
//     }

//     public override void Display(int depth = 0)
//     {
//         Console.WriteLine($"{new string('-', depth)} {Name} (Contractor) - {Payment}");
//     }

//     public override double GetBudget() => 0;

//     public override int GetEmployeeCount() => 1;
// }

// class Department : OrganizationComponent
// {
//     private List<OrganizationComponent> components = new List<OrganizationComponent>();

//     public Department(string name) : base(name) { }

//     public void Add(OrganizationComponent component)
//     {
//         if (!components.Contains(component))
//             components.Add(component);
//     }

//     public override void Display(int depth = 0)
//     {
//         Console.WriteLine($"{new string('-', depth)} [Отдел] {Name}");
//         foreach (var c in components)
//             c.Display(depth + 2);
//     }

//     public override double GetBudget()
//     {
//         double total = 0;
//         foreach (var c in components)
//             total += c.GetBudget();
//         return total;
//     }

//     public override int GetEmployeeCount()
//     {
//         int total = 0;
//         foreach (var c in components)
//             total += c.GetEmployeeCount();
//         return total;
//     }

//     public OrganizationComponent Find(string name)
//     {
//         foreach (var c in components)
//         {
//             if (c.Name == name)
//                 return c;

//             if (c is Department dept)
//             {
//                 var found = dept.Find(name);
//                 if (found != null) return found;
//             }
//         }
//         return null;
//     }

//     public List<string> GetAllEmployees()
//     {
//         List<string> list = new List<string>();

//         foreach (var c in components)
//         {
//             if (c is Employee || c is Contractor)
//                 list.Add(c.Name);

//             if (c is Department dept)
//                 list.AddRange(dept.GetAllEmployees());
//         }

//         return list;
//     }
// }

// // MAIN 

// class Module9App
// {
//     static void Main()
//     {
//         var hotel = new HotelFacade();

//         hotel.BookFullService("Али");
//         hotel.OrganizeEvent("Конференция", "Бек");
//         hotel.BookDinnerWithTaxi("Санжар");

//         hotel.RequestCleaning("101");
//         hotel.CancelRoom("Али");

//         Console.WriteLine("\n=== ОРГАНИЗАЦИЯ ===");

//         var dev1 = new Employee("Иван", "Разработчик", 1000);
//         var dev2 = new Employee("Анна", "Разработчик", 1200);
//         var contractor = new Contractor("Фрилансер", 500);

//         var devDept = new Department("IT");
//         devDept.Add(dev1);
//         devDept.Add(dev2);
//         devDept.Add(contractor);

//         var hr = new Employee("Оля", "HR", 800);
//         var hrDept = new Department("HR");
//         hrDept.Add(hr);

//         var company = new Department("Компания");
//         company.Add(devDept);
//         company.Add(hrDept);

//         company.Display();

//         Console.WriteLine($"\nБюджет: {company.GetBudget()}");
//         Console.WriteLine($"Сотрудников: {company.GetEmployeeCount()}");

//         var found = company.Find("Анна");
//         if (found != null)
//             Console.WriteLine($"\nНайден: {found.Name}");

//         Console.WriteLine("\nВсе сотрудники:");
//         foreach (var name in company.GetAllEmployees())
//             Console.WriteLine(name);
//     }
// }