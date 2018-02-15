using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var engines = new List<Engine>();
        AddEngines(n, engines);

        var m = int.Parse(Console.ReadLine());

        var cars = new List<Car>();
        FindAllCars(engines, m, cars);

        Console.WriteLine();
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static void FindAllCars(List<Engine> engines, int m, List<Car> cars)
    {
        for (int i = 0; i < m; i++)
        {
            var carArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = carArgs[0];
            var engine = engines.First(e => e.Model == carArgs[1]);

            if (carArgs.Length == 2)
            {
                var currentCar = new Car(model, engine);
                cars.Add(currentCar);
            }
            else if (carArgs.Length == 3)
            {
                var parameter = carArgs[2];

                if (Char.IsDigit(parameter[0]))
                {
                    var currentCar = new Car(model, engine, parameter);
                    cars.Add(currentCar);
                }
                else
                {
                    var currentCar = new Car(model, engine, "n/a", parameter);
                    cars.Add(currentCar);
                }
            }
            else if (carArgs.Length == 4)
            {
                var currentCar = new Car(model, engine, carArgs[2], carArgs[3]);
                cars.Add(currentCar);
            }
        }
    }

    private static void AddEngines(int n, List<Engine> engines)
    {
        for (int i = 0; i < n; i++)
        {
            var engineArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = engineArgs[0];
            var power = double.Parse(engineArgs[1]);

            if (engineArgs.Length == 2)
            {
                var currentEngine = new Engine(model, power);
                engines.Add(currentEngine);
            }
            else if (engineArgs.Length == 3)
            {
                var parameter = engineArgs[2];

                if (Char.IsLetter(parameter[0]))
                {
                    var currentEngine = new Engine(model, power, "n/a", parameter);
                    engines.Add(currentEngine);
                }
                else
                {
                    var currentEngine = new Engine(model, power, parameter);
                    engines.Add(currentEngine);
                }
            }
            else if (engineArgs.Length == 4)
            {
                var currentEngine = new Engine(model, power, engineArgs[2], engineArgs[3]);
                engines.Add(currentEngine);
            }
        }
    }
}
