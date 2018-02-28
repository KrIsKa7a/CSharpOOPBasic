using System;
using System.Collections.Generic;
using System.Text;

public class Animal : ISoundProducable
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    private string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    private int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }

            this.age = value;
        }
    }

    private string Gender
    {
        get { return this.gender; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || (value != "Male" && value != "Female"))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = value;
        }
    }

    public virtual string ProduceSound()
    {
        return "NOISE";
    }

    public override string ToString()
    {
        //Tom 12 Male
        var sb = new StringBuilder();
        sb.AppendLine(GetType().Name)
            .AppendLine($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine(ProduceSound());

        var result = sb.ToString().TrimEnd();

        return result;
    }
}
