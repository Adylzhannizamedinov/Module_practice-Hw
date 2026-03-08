using System;
using System.Collections.Generic;


/// 1. COMMAND PATTERN – SMART HOME


public interface ICommand
{
    void Execute();
    void Undo();
}

public class NoCommand : ICommand
{
    public void Execute() { Console.WriteLine("Команда не назначена."); }
    public void Undo() { Console.WriteLine("Нечего отменять."); }
}


/// DEVICES


public class Light
{
    public void On() => Console.WriteLine("Свет включен");
    public void Off() => Console.WriteLine("Свет выключен");
}

public class TV
{
    public void On() => Console.WriteLine("Телевизор включен");
    public void Off() => Console.WriteLine("Телевизор выключен");
}

public class AirConditioner
{
    public void On() => Console.WriteLine("Кондиционер включен");
    public void Off() => Console.WriteLine("Кондиционер выключен");
}


/// COMMANDS


public class LightOnCommand : ICommand
{
    private Light light;
    public LightOnCommand(Light l) { light = l; }
    public void Execute() => light.On();
    public void Undo() => light.Off();
}

public class LightOffCommand : ICommand
{
    private Light light;
    public LightOffCommand(Light l) { light = l; }
    public void Execute() => light.Off();
    public void Undo() => light.On();
}

public class TVOnCommand : ICommand
{
    private TV tv;
    public TVOnCommand(TV t) { tv = t; }
    public void Execute() => tv.On();
    public void Undo() => tv.Off();
}

public class TVOffCommand : ICommand
{
    private TV tv;
    public TVOffCommand(TV t) { tv = t; }
    public void Execute() => tv.Off();
    public void Undo() => tv.On();
}

public class ACOnCommand : ICommand
{
    private AirConditioner ac;
    public ACOnCommand(AirConditioner a) { ac = a; }
    public void Execute() => ac.On();
    public void Undo() => ac.Off();
}

public class ACOffCommand : ICommand
{
    private AirConditioner ac;
    public ACOffCommand(AirConditioner a) { ac = a; }
    public void Execute() => ac.Off();
    public void Undo() => ac.On();
}


/// MACRO COMMAND


public class MacroCommand : ICommand
{
    private List<ICommand> commands;

    public MacroCommand(List<ICommand> commands)
    {
        this.commands = commands;
    }

    public void Execute()
    {
        foreach (var cmd in commands)
            cmd.Execute();
    }

    public void Undo()
    {
        for (int i = commands.Count - 1; i >= 0; i--)
            commands[i].Undo();
    }
}


/// REMOTE CONTROL


public class RemoteControl
{
    private ICommand[] onCommands = new ICommand[5];
    private ICommand[] offCommands = new ICommand[5];

    private Stack<ICommand> undoStack = new();
    private Stack<ICommand> redoStack = new();

    public RemoteControl()
    {
        ICommand noCommand = new NoCommand();
        for (int i = 0; i < 5; i++)
        {
            onCommands[i] = noCommand;
            offCommands[i] = noCommand;
        }
    }

    public void SetCommand(int slot, ICommand on, ICommand off)
    {
        onCommands[slot] = on;
        offCommands[slot] = off;
    }

    public void PressOn(int slot)
    {
        onCommands[slot].Execute();
        undoStack.Push(onCommands[slot]);
    }

    public void PressOff(int slot)
    {
        offCommands[slot].Execute();
        undoStack.Push(offCommands[slot]);
    }

    public void Undo()
    {
        if (undoStack.Count == 0)
        {
            Console.WriteLine("Нет команд для отмены");
            return;
        }

        ICommand cmd = undoStack.Pop();
        cmd.Undo();
        redoStack.Push(cmd);
    }

    public void Redo()
    {
        if (redoStack.Count == 0)
        {
            Console.WriteLine("Нет команд для повтора");
            return;
        }

        ICommand cmd = redoStack.Pop();
        cmd.Execute();
        undoStack.Push(cmd);
    }
}


/// 2. TEMPLATE METHOD – REPORT GENERATOR


public abstract class ReportGenerator
{
    public void GenerateReport()
    {
        FetchData();
        FormatData();
        GenerateHeader();
        SaveReport();
    }

    protected void FetchData()
    {
        Console.WriteLine("Получение данных...");
    }

    protected abstract void FormatData();
    protected abstract void GenerateHeader();

    protected virtual void SaveReport()
    {
        Console.WriteLine("Сохранение отчета...");
    }
}

public class PdfReport : ReportGenerator
{
    protected override void FormatData()
    {
        Console.WriteLine("Форматирование данных для PDF");
    }

    protected override void GenerateHeader()
    {
        Console.WriteLine("Создание заголовка PDF");
    }
}

public class ExcelReport : ReportGenerator
{
    protected override void FormatData()
    {
        Console.WriteLine("Форматирование таблицы Excel");
    }

    protected override void GenerateHeader()
    {
        Console.WriteLine("Создание заголовка Excel");
    }

    protected override void SaveReport()
    {
        Console.WriteLine("Excel файл сохранен");
    }
}

public class HtmlReport : ReportGenerator
{
    protected override void FormatData()
    {
        Console.WriteLine("HTML разметка данных");
    }

    protected override void GenerateHeader()
    {
        Console.WriteLine("Создание HTML заголовка");
    }
}

public class CsvReport : ReportGenerator
{
    protected override void FormatData()
    {
        Console.WriteLine("Форматирование CSV");
    }

    protected override void GenerateHeader()
    {
        Console.WriteLine("CSV не требует сложного заголовка");
    }
}


/// 3. MEDIATOR – CHAT SYSTEM


public interface IMediator
{
    void SendMessage(string channel, string message, IUser sender);
    void JoinChannel(string channel, IUser user);
    void LeaveChannel(string channel, IUser user);
}

public interface IUser
{
    string Name { get; }
    void Receive(string channel, string message, string sender);
}

public class ChatMediator : IMediator
{
    private Dictionary<string, List<IUser>> channels = new();

    public void JoinChannel(string channel, IUser user)
    {
        if (!channels.ContainsKey(channel))
            channels[channel] = new List<IUser>();

        channels[channel].Add(user);
        Console.WriteLine($"{user.Name} вошел в канал {channel}");
    }

    public void LeaveChannel(string channel, IUser user)
    {
        if (channels.ContainsKey(channel))
        {
            channels[channel].Remove(user);
            Console.WriteLine($"{user.Name} покинул канал {channel}");
        }
    }

    public void SendMessage(string channel, string message, IUser sender)
    {
        if (!channels.ContainsKey(channel))
        {
            Console.WriteLine("Канал не существует");
            return;
        }

        foreach (var user in channels[channel])
        {
            if (user != sender)
                user.Receive(channel, message, sender.Name);
        }
    }
}

public class User : IUser
{
    public string Name { get; private set; }
    private IMediator mediator;

    public User(string name, IMediator mediator)
    {
        Name = name;
        this.mediator = mediator;
    }

    public void Send(string channel, string message)
    {
        mediator.SendMessage(channel, message, this);
    }

    public void Receive(string channel, string message, string sender)
    {
        Console.WriteLine($"{Name} получил сообщение в {channel} от {sender}: {message}");
    }
}


/// MAIN


class Program
{
    static void Main()
    {
        Console.WriteLine("=== COMMAND PATTERN ===");

        RemoteControl remote = new RemoteControl();

        Light light = new Light();
        TV tv = new TV();
        AirConditioner ac = new AirConditioner();

        remote.SetCommand(0, new LightOnCommand(light), new LightOffCommand(light));
        remote.SetCommand(1, new TVOnCommand(tv), new TVOffCommand(tv));
        remote.SetCommand(2, new ACOnCommand(ac), new ACOffCommand(ac));

        remote.PressOn(0);
        remote.PressOn(1);
        remote.Undo();
        remote.Redo();

        Console.WriteLine("\n=== MACRO COMMAND ===");

        var macro = new MacroCommand(new List<ICommand>
        {
            new LightOnCommand(light),
            new TVOnCommand(tv),
            new ACOnCommand(ac)
        });

        macro.Execute();
        macro.Undo();

        Console.WriteLine("\n=== TEMPLATE METHOD ===");

        ReportGenerator pdf = new PdfReport();
        pdf.GenerateReport();

        ReportGenerator excel = new ExcelReport();
        excel.GenerateReport();

        ReportGenerator html = new HtmlReport();
        html.GenerateReport();

        Console.WriteLine("\n=== MEDIATOR CHAT ===");

        ChatMediator chat = new ChatMediator();

        User alice = new User("Alice", chat);
        User bob = new User("Bob", chat);
        User charlie = new User("Charlie", chat);

        chat.JoinChannel("general", alice);
        chat.JoinChannel("general", bob);
        chat.JoinChannel("games", charlie);

        alice.Send("general", "Привет всем!");
        bob.Send("general", "Здравствуйте!");
    }
}