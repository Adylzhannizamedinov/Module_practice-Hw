using System;
using System.Collections.Generic;



// Подсистемы
class TV
{
    public void On() => Console.WriteLine("TV включен");
    public void Off() => Console.WriteLine("TV выключен");
    public void SetChannel(int channel) => Console.WriteLine($"TV канал: {channel}");
}

class AudioSystem
{
    public void On() => Console.WriteLine("Аудиосистема включена");
    public void Off() => Console.WriteLine("Аудиосистема выключена");
    public void SetVolume(int volume) => Console.WriteLine($"Громкость: {volume}");
}

class DVDPlayer
{
    public void Play() => Console.WriteLine("DVD воспроизведение");
    public void Stop() => Console.WriteLine("DVD остановлен");
}

class GameConsole
{
    public void On() => Console.WriteLine("Консоль включена");
    public void StartGame() => Console.WriteLine("Игра запущена");
}

// Фасад
class HomeTheaterFacade
{
    private TV tv;
    private AudioSystem audio;
    private DVDPlayer dvd;
    private GameConsole console;

    public HomeTheaterFacade(TV tv, AudioSystem audio, DVDPlayer dvd, GameConsole console)
    {
        this.tv = tv;
        this.audio = audio;
        this.dvd = dvd;
        this.console = console;
    }

    public void WatchMovie()
    {
        Console.WriteLine("\n🎬 Фильм...");
        tv.On();
        audio.On();
        audio.SetVolume(20);
        dvd.Play();
    }

    public void PlayGame()
    {
        Console.WriteLine("\n🎮 Игра...");
        tv.On();
        console.On();
        console.StartGame();
    }

    public void ListenMusic()
    {
        Console.WriteLine("\n🎵 Музыка...");
        tv.On();
        audio.On();
        audio.SetVolume(15);
    }

    public void Shutdown()
    {
        Console.WriteLine("\n🔻 Выключение...");
        dvd.Stop();
        audio.Off();
        tv.Off();
    }
}



// Абстрактный компонент
abstract class FileSystemComponent
{
    public string Name { get; set; }

    public FileSystemComponent(string name)
    {
        Name = name;
    }

    public abstract void Display(int depth = 0);
    public abstract int GetSize();
}

// Файл
class File : FileSystemComponent
{
    private int size;

    public File(string name, int size) : base(name)
    {
        this.size = size;
    }

    public override void Display(int depth = 0)
    {
        Console.WriteLine($"{new string('-', depth)} Файл: {Name} ({size} KB)");
    }

    public override int GetSize() => size;
}

// Папка
class Directory : FileSystemComponent
{
    private List<FileSystemComponent> components = new List<FileSystemComponent>();

    public Directory(string name) : base(name) { }

    public void Add(FileSystemComponent component)
    {
        if (!components.Contains(component))
            components.Add(component);
        else
            Console.WriteLine("Уже существует!");
    }

    public void Remove(FileSystemComponent component)
    {
        if (components.Contains(component))
            components.Remove(component);
        else
            Console.WriteLine("Не найден!");
    }

    public override void Display(int depth = 0)
    {
        Console.WriteLine($"{new string('-', depth)} Папка: {Name}");
        foreach (var c in components)
            c.Display(depth + 2);
    }

    public override int GetSize()
    {
        int total = 0;
        foreach (var c in components)
            total += c.GetSize();
        return total;
    }
}



class Module9App
{
    static void Main()
    {
        // FACADE
        var facade = new HomeTheaterFacade(
            new TV(),
            new AudioSystem(),
            new DVDPlayer(),
            new GameConsole()
        );

        facade.WatchMovie();
        facade.PlayGame();
        facade.ListenMusic();
        facade.Shutdown();

        // COMPOSITE 
        Console.WriteLine("\n=== ФАЙЛОВАЯ СИСТЕМА ===");

        var file1 = new File("file1.txt", 10);
        var file2 = new File("file2.txt", 20);
        var file3 = new File("file3.txt", 30);

        var folder1 = new Directory("Documents");
        var folder2 = new Directory("Images");

        folder1.Add(file1);
        folder1.Add(file2);
        folder2.Add(file3);

        var root = new Directory("Root");
        root.Add(folder1);
        root.Add(folder2);

        root.Display();

        Console.WriteLine($"\nОбщий размер: {root.GetSize()} KB");
    }
}
