using System;
using System.Collections.Generic;
using System.Text;

public class Pet : IBirthdate
{
    public Pet(string name, DateTime birthdate)
    {
        this.Name = name;
        this.BirthDate = birthdate;
    }

    public string Name { get; set; }

    public DateTime BirthDate { get; private set; }
}
