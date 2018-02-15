using System;

class Program
{
    static void Main(string[] args)
    {
        var p1 = new Person() { Name = "Pesho", Age = 20 };
        var p2 = new Person();
        p2.Name = "Gosho";
        p2.Age = 18;
        var p3 = new Person() { Name = "Stamat", Age = 43 };
    }
}
