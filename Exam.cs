using System;

interface ICommand
{
    void Execute();
    void Undo();
}

class User
{
    public string Name { get; set; }
    public User(string name)
    {
        Name = name;
    }
}

class Task
{
    public string Title { get; set; }
    public User AssignedUser { get; set; }

    public Task(string title)
    {
        Title = title;
    }
}

class AssignUserCommand : ICommand
{
    private Task task;
    private User newUser;
    private User oldUser;

    public AssignUserCommand(Task task, User user)
    {
        this.task = task;
        this.newUser = user;
    }

    public void Execute()
    {
        oldUser = task.AssignedUser;
        task.AssignedUser = newUser;

        Console.WriteLine(
            $"Пользователь {newUser.Name} назначен на задачу {task.Title}"
        );
    }

    public void Undo()
    {
        task.AssignedUser = oldUser;
        Console.WriteLine("Назначение отменено");
    }
}

class Program
{
    static void Main()
    {
        Task task = new Task("Создать отчет");
        User user1 = new User("Adyl");

        ICommand command = new AssignUserCommand(task, user1);
        command.Execute();
        command.Undo();
    }
}