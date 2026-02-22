// Я недобавил использован е в Director и Weapon

using System;
using System.IO;
using System.Collections.Generic;
class Program
{
   static void Main(string[] args)
    {
        Console.WriteLine("Программа запущена!");

        Logger logger = Logger.GetInstance();
        logger.Log("Тест логирования", LogLevel.INFO);
    }
}
public enum LogLevel
{
    INFO,
    WARNING,
    ERROR
}

public sealed class Logger
{
    private static Logger _instance;
    private static object _lock = new object();

    private LogLevel _currentLevel = LogLevel.INFO;
    private string _filePath = "log.txt";

    private Logger() { }

    public static Logger GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
                _instance = new Logger();
            return _instance;
        }
    }

    public void SetLogLevel(LogLevel level)
    {
        _currentLevel = level;
    }

    public void Log(string message, LogLevel level)
    {
        if (level < _currentLevel)
            return;

        string text = $"{DateTime.Now} [{level}] {message}";
        File.AppendAllText(_filePath, text + "\n");
        Console.WriteLine(text);
    }
}

// class Report



public class Report
{
    public string Header { get; set; }
    public string Content { get; set; }
    public string Footer { get; set; }

    public List<string> Sections { get; set; } = new List<string>();

    public void Export()
    {
        Console.WriteLine(Header);
        Console.WriteLine(Content);

        foreach (string section in Sections)
        {
            Console.WriteLine(section);
        }

        Console.WriteLine(Footer);
    }
}
// Интерфейс Builder
public interface IReportBuilder
{
    void SetHeader(string header);
    void SetContent(string content);
    void SetFooter(string footer);
    void AddSection(string section);
    Report GetReport();
}
// Конкретный строитель

public class SimpleReportBuilder : IReportBuilder
{
    private Report _report = new Report();

    public void SetHeader(string header)
    {
        _report.Header = header;
    }

    public void SetContent(string content)
    {
        _report.Content = content;
    }

    public void SetFooter(string footer)
    {
        _report.Footer = footer;
    }

    public void AddSection(string section)
    {
        _report.Sections.Add(section);
    }

    public Report GetReport()
    {
        return _report;
    }
}

// Director

public class ReportDirector
{
    public void ConstructReport(IReportBuilder builder)
    {
        builder.SetHeader("=== Report Header ===");
        builder.SetContent("Main content of report");
        builder.AddSection("Section 1: Introduction");
        builder.AddSection("Section 2: Data");
        builder.SetFooter("=== Report Footer ===");
    }
}
// 3.Prototype
public class Weapon : ICloneable
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public object Clone()
    {
        return new Weapon
        {
            Name = this.Name,
            Damage = this.Damage
        };
    }
}
// Character
public class Character : ICloneable
{
    public int Health { get; set; }
    public Weapon Weapon { get; set; }
    public List<string> Skills { get; set; } = new List<string>();

    public object Clone()
    {
        Character clone = (Character)this.MemberwiseClone();

        clone.Weapon = (Weapon)this.Weapon.Clone();
        clone.Skills = new List<string>(this.Skills);

        return clone;
    }
}
