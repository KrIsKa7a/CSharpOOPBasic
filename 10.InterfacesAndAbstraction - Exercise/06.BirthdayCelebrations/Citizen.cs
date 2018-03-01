using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IIdentifiable, IBirthdate
{
    public Citizen(string name, int age, string id, DateTime birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthDate;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }

    public DateTime BirthDate { get; private set; }
}
