using System;
using System.Collections.Generic;
using System.IO;

// 1️. SINGLETON – Logger
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

// 2️. BUILDER – Reports
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
        foreach (string s in Sections)
            Console.WriteLine(s);
        Console.WriteLine(Footer);
    }
}

public interface IReportBuilder
{
    void SetHeader(string header);
    void SetContent(string content);
    void SetFooter(string footer);
    void AddSection(string section);
    Report GetReport();
}

public class SimpleReportBuilder : IReportBuilder
{
    private Report _report = new Report();

    public void SetHeader(string header) => _report.Header = header;
    public void SetContent(string content) => _report.Content = content;
    public void SetFooter(string footer) => _report.Footer = footer;
    public void AddSection(string section) => _report.Sections.Add(section);
    public Report GetReport() => _report;
}

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

// 3️. PROTOTYPE – Character & Weapon
public class Weapon : ICloneable
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public object Clone()
    {
        return new Weapon { Name = this.Name, Damage = this.Damage };
    }
}

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

// MAIN
class Program
{
    static void Main()
    {
        // -------- Logger Singleton --------
        Console.WriteLine("=== Logger Singleton ===");
        var logger1 = Logger.GetInstance();
        var logger2 = Logger.GetInstance();

        logger1.Log("Starting application", LogLevel.INFO);
        logger2.Log("Warning message", LogLevel.WARNING);

        Console.WriteLine($"Same instance: {object.ReferenceEquals(logger1, logger2)}\n");

        // -------- Builder --------
        Console.WriteLine("=== Builder Report ===");
        ReportDirector director = new ReportDirector();
        IReportBuilder builder = new SimpleReportBuilder();
        director.ConstructReport(builder);
        builder.GetReport().Export();

        // -------- Prototype --------
        Console.WriteLine("\n=== Prototype Character ===");
        Character hero = new Character
        {
            Health = 100,
            Weapon = new Weapon { Name = "Sword", Damage = 10 }
        };
        hero.Skills.Add("Fireball");

        Character clone = (Character)hero.Clone();
        clone.Weapon.Name = "Axe";
        clone.Skills.Add("Ice Blast");

        Console.WriteLine($"Hero Weapon: {hero.Weapon.Name}, Skills: {string.Join(",", hero.Skills)}");
        Console.WriteLine($"Clone Weapon: {clone.Weapon.Name}, Skills: {string.Join(",", clone.Skills)}");
    }
}