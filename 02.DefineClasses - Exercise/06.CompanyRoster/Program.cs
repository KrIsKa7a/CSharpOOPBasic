using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var employees = new Dictionary<string, List<Employee>>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length == 4)
            {
                var currEm = new Employee(input[0], decimal.Parse(input[1]),
                    input[2], input[3]);

                if (!employees.ContainsKey(input[3]))
                {
                    employees[input[3]] = new List<Employee>();
                }

                employees[input[3]].Add(currEm);
            }
            else if (input.Length == 5)
            {
                var atIndexFour = input[4];
                int age;

                bool hasParsed = int.TryParse(atIndexFour, out age);

                if (hasParsed)
                {
                    var currEm = new Employee(input[0], decimal.Parse(input[1]),
                    input[2], input[3], age);

                    if (!employees.ContainsKey(input[3]))
                    {
                        employees[input[3]] = new List<Employee>();
                    }

                    employees[input[3]].Add(currEm);
                }
                else
                {
                    var currEm = new Employee(input[0], decimal.Parse(input[1]),
                    input[2], input[3], atIndexFour);

                    if (!employees.ContainsKey(input[3]))
                    {
                        employees[input[3]] = new List<Employee>();
                    }

                    employees[input[3]].Add(currEm);
                }
            }
            else if (input.Length == 6)
            {
                var currEm = new Employee(input[0], decimal.Parse(input[1]),
                    input[2], input[3], input[4], int.Parse(input[5]));

                if (!employees.ContainsKey(input[3]))
                {
                    employees[input[3]] = new List<Employee>();
                }

                employees[input[3]].Add(currEm);
            }
        }

        var bestDepartment = employees
            .OrderByDescending(e => e.Value.Sum(v => v.Salary))
            .FirstOrDefault();
        Console.WriteLine();
        PrintResult(bestDepartment);
    }

    private static void PrintResult(KeyValuePair<string, List<Employee>> bestDepartment)
    {
        Console.WriteLine($"Highest Average Salary: {bestDepartment.Key}");

        foreach (var em in bestDepartment.Value.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{em.Name} {em.Salary:f2} {em.Email} {em.Age}");
        }
    }
}
