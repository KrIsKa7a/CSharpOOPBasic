using System;
using System.Collections.Generic;
using System.Text;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.repo = new Dictionary<string, Student>();
    }

    public void ParseCommand()
    {
        string[] args = Console.ReadLine().Split();

        if (args[0] == "Create")
        {
            CreateStudent(args);
        }
        else if (args[0] == "Show")
        {
            var name = args[1];

            if (repo.ContainsKey(name))
            {
                PrintStudent(name);
            }

        }
        else if (args[0] == "Exit")
        {
            Environment.Exit(0);
        }
    }

    private void PrintStudent(string name)
    {
        var student = repo[name];

        Console.WriteLine(student);
    }

    private void CreateStudent(string[] args)
    {
        var name = args[1];
        var age = int.Parse(args[2]);
        var grade = double.Parse(args[3]);

        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            repo[name] = student;
        }
    }
}
