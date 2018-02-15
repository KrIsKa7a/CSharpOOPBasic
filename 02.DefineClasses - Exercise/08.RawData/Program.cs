using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var allCars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            AddNewCar(allCars);
        }

        var cargoType = Console.ReadLine();

        if (cargoType == "fragile")
        {
            var wantedCars = allCars
                .Where(c => c.Cargo.Type == "fragile")
                .Where(c => c.Tires.Any(t => t.Pressure < 1))
                .ToList();

            foreach (var car in wantedCars)
            {
                Console.WriteLine(car);
            }
        }
        else if (cargoType == "flamable")
        {
            var wantedCars = allCars
                .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                .ToList();

            foreach (var car in wantedCars)
            {
                Console.WriteLine(car);
            }
        }
    }

    private static void AddNewCar(List<Car> allCars)
    {
        var carArgs = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var currentCarModel = carArgs[0];
        var currentCarEngine = new Engine(double.Parse(carArgs[1]),
            double.Parse(carArgs[2]));
        var currentCarCargo = new Cargo(double.Parse(carArgs[3]), carArgs[4]);
        var currentCarTires = new List<Tire>();
        currentCarTires.Add(new Tire(double.Parse(carArgs[5]),
            double.Parse(carArgs[6])));
        currentCarTires.Add(new Tire(double.Parse(carArgs[7]),
            double.Parse(carArgs[8])));
        currentCarTires.Add(new Tire(double.Parse(carArgs[9]),
            double.Parse(carArgs[10])));
        currentCarTires.Add(new Tire(double.Parse(carArgs[11]),
            double.Parse(carArgs[12])));

        var currentCar = new Car(currentCarModel, currentCarEngine, currentCarCargo, currentCarTires);

        allCars.Add(currentCar);
    }
}
