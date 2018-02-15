using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private string birthday;
    private List<Person> parents;
    private List<Person> children;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Birthday
    {
        get { return this.birthday; }
        set { this.birthday = value; }
    }

    public List<Person> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    public List<Person> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }

    public Person()
    {
        this.parents = new List<Person>();
        this.children = new List<Person>();
    }

    public Person(string name, string birthDay)
    {
        this.Name = name;
        this.Birthday = birthDay;
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public void AddParent(Person person)
    {
        this.parents.Add(person);
    }

    public void AddChild(Person person)
    {
        this.children.Add(person);
    }

    public override string ToString()
    {
        return $"{this.name} {this.Birthday}";
    }
}
