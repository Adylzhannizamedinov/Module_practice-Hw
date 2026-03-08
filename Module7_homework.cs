using System;
using System.Collections.Generic;


/// PATTERN 1 — COMMAND (Умный дом)


// Интерфейс команды
public interface ICommand
{
    void Execute();
    void Undo();
}

// ===== Receiver =====

public class Light
{
    public void On()
    {
        Console.WriteLine("Свет включен");
    }

    public void Off()
    {
        Console.WriteLine("Свет выключен");
    }
}

public class Door
{
    public void Open()
    {
        Console.WriteLine("Дверь открыта");
    }

    public void Close()
    {
        Console.WriteLine("Дверь закрыта");
    }
}

public class Thermostat
{
    private int temperature = 20;

    public void IncreaseTemp()
    {
        temperature++;
        Console.WriteLine($"Температура увеличена до {temperature}");
    }

    public void DecreaseTemp()
    {
        temperature--;
        Console.WriteLine($"Температура уменьшена до {temperature}");
    }
}

public class TV
{
    public void On()
    {
        Console.WriteLine("Телевизор включен");
    }

    public void Off()
    {
        Console.WriteLine("Телевизор выключен");
    }
}

// ===== Конкретные команды =====

// Light
public class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.On();
    }

    public void Undo()
    {
        light.Off();
    }
}

public class LightOffCommand : ICommand
{
    private Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.Off();
    }

    public void Undo()
    {
        light.On();
    }
}

// Door
public class DoorOpenCommand : ICommand
{
    private Door door;

    public DoorOpenCommand(Door door)
    {
        this.door = door;
    }

    public void Execute()
    {
        door.Open();
    }

    public void Undo()
    {
        door.Close();
    }
}

public class DoorCloseCommand : ICommand
{
    private Door door;

    public DoorCloseCommand(Door door)
    {
        this.door = door;
    }

    public void Execute()
    {
        door.Close();
    }

    public void Undo()
    {
        door.Open();
    }
}

// Thermostat
public class IncreaseTempCommand : ICommand
{
    private Thermostat thermostat;

    public IncreaseTempCommand(Thermostat thermostat)
    {
        this.thermostat = thermostat;
    }

    public void Execute()
    {
        thermostat.IncreaseTemp();
    }

    public void Undo()
    {
        thermostat.DecreaseTemp();
    }
}

public class DecreaseTempCommand : ICommand
{
    private Thermostat thermostat;

    public DecreaseTempCommand(Thermostat thermostat)
    {
        this.thermostat = thermostat;
    }

    public void Execute()
    {
        thermostat.DecreaseTemp();
    }

    public void Undo()
    {
        thermostat.IncreaseTemp();
    }
}

// TV
public class TVOnCommand : ICommand
{
    private TV tv;

    public TVOnCommand(TV tv)
    {
        this.tv = tv;
    }

    public void Execute()
    {
        tv.On();
    }

    public void Undo()
    {
        tv.Off();
    }
}

// ===== Invoker =====

public class RemoteControl
{
    private Stack<ICommand> history = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        history.Push(command);
    }

    public void Undo()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("Нет команд для отмены");
            return;
        }

        ICommand command = history.Pop();
        command.Undo();
    }
}


/// PATTERN 2 — TEMPLATE METHOD (Напитки)


public abstract class Beverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();

        if (CustomerWantsCondiments())
        {
            AddCondiments();
        }
    }

    protected void BoilWater()
    {
        Console.WriteLine("Кипятим воду");
    }

    protected void PourInCup()
    {
        Console.WriteLine("Наливаем в чашку");
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();

    protected virtual bool CustomerWantsCondiments()
    {
        return true;
    }
}

// Tea
public class Tea : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем чай");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем лимон");
    }
}

// Coffee
public class Coffee : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем кофе");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем молоко и сахар");
    }

    protected override bool CustomerWantsCondiments()
    {
        Console.Write("Добавить молоко и сахар? (y/n): ");
        string input = Console.ReadLine();

        if (input.ToLower() == "y")
            return true;
        if (input.ToLower() == "n")
            return false;

        Console.WriteLine("Некорректный ввод. Добавки не добавлены.");
        return false;
    }
}

// Новый напиток
public class HotChocolate : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Готовим горячий шоколад");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем маршмеллоу");
    }
}

// PATTERN 3 — MEDIATOR (Чат)


public interface IMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}

public class ChatRoom : IMediator
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
        Console.WriteLine($"{user.Name} присоединился к чату");
    }

    public void SendMessage(string message, User sender)
    {
        if (!users.Contains(sender))
        {
            Console.WriteLine("Ошибка: пользователь не находится в чате");
            return;
        }

        foreach (var user in users)
        {
            if (user != sender)
            {
                user.Receive(message, sender);
            }
        }
    }
}

public class User
{
    private IMediator mediator;
    public string Name { get; }

    public User(IMediator mediator, string name)
    {
        this.mediator = mediator;
        Name = name;
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} отправляет: {message}");
        mediator.SendMessage(message, this);
    }

    public void Receive(string message, User sender)
    {
        Console.WriteLine($"{Name} получил сообщение от {sender.Name}: {message}");
    }
}

/// MAIN (Клиентский код)


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== COMMAND: Умный дом =====");

        RemoteControl remote = new RemoteControl();

        Light light = new Light();
        Door door = new Door();
        Thermostat thermostat = new Thermostat();
        TV tv = new TV();

        remote.ExecuteCommand(new LightOnCommand(light));
        remote.ExecuteCommand(new DoorOpenCommand(door));
        remote.ExecuteCommand(new IncreaseTempCommand(thermostat));
        remote.ExecuteCommand(new TVOnCommand(tv));

        Console.WriteLine("\nОтмена команд:");

        remote.Undo();
        remote.Undo();
        remote.Undo();

        

        Console.WriteLine("\n===== TEMPLATE METHOD: Напитки =====");

        Console.WriteLine("\nГотовим чай:");
        Beverage tea = new Tea();
        tea.PrepareRecipe();

        Console.WriteLine("\nГотовим кофе:");
        Beverage coffee = new Coffee();
        coffee.PrepareRecipe();

        Console.WriteLine("\nГотовим горячий шоколад:");
        Beverage chocolate = new HotChocolate();
        chocolate.PrepareRecipe();

        Console.WriteLine("\n===== MEDIATOR: Чат =====");

        ChatRoom chat = new ChatRoom();

        User user1 = new User(chat, "Али");
        User user2 = new User(chat, "Бек");
        User user3 = new User(chat, "Дана");

        chat.AddUser(user1);
        chat.AddUser(user2);
        chat.AddUser(user3);

        user1.Send("Привет всем!");
        user2.Send("Здравствуйте!");
    }
}