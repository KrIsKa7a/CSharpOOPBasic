using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private const int MIN_NAME_LENGHT = 3;

    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    protected string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < MIN_NAME_LENGHT)
            {
                throw new ArgumentException($"Name's length should not be less than {MIN_NAME_LENGHT} symbols!");
            }

            this.name = value;
        }
    }

    public virtual int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            this.age = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                             this.Name,
                             this.Age));

        return stringBuilder.ToString();
    }
}
