using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private const int MIN_LENGHT = 3;
    private const decimal MIN_SALARY = 460m;

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (value?.Length < MIN_LENGHT)
            {
                throw new ArgumentException($"First name cannot contain fewer than {MIN_LENGHT} symbols!");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        private set
        {
            if (value?.Length < MIN_LENGHT)
            {
                throw new ArgumentException($"Last name cannot contain fewer than {MIN_LENGHT} symbols!");
            }

            this.lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }

            this.age = value;
        }
    }

    public decimal Salary
    {
        get { return this.salary; }
        private set
        {
            if (value < MIN_SALARY)
            {
                throw new ArgumentException($"Salary cannot be less than {MIN_SALARY} leva!");
            }

            this.salary = value;
        }
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.age < 30)
        {
            this.salary += (percentage / 100 / 2) * this.salary;
        }
        else
        {
            this.salary += (percentage / 100) * this.salary;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} gets {this.salary:f2} leva.";
    }
}
