using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public string FirstName
    {
        get { return this.firstName; }
    }

    public int Age
    {
        get { return this.age; }
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
        return $"{this.firstName} {this.lastName} receives {this.salary:f2} leva.";
    }
}
