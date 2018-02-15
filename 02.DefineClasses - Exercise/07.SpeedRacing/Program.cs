using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            ParseInputAndAddCar(cars);
        }

        DriveCars(cars);

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static void DriveCars(List<Car> cars)
    {
        var command = Console.ReadLine();

        while (command != "End")
        {
            var cmdArgs = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var carModel = cmdArgs[1];
            var amountKm = double.Parse(cmdArgs[2]);

            var carToBeDriven = cars.First(c => c.Model == carModel);
            carToBeDriven.MoveCar(amountKm);

            command = Console.ReadLine();
        }
    }

    private static void ParseInputAndAddCar(List<Car> cars)
    {
        var currentCarTokens = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var model = currentCarTokens[0];
        var fuelAmount = double.Parse(currentCarTokens[1]);
        var fuelConsumption = double.Parse(currentCarTokens[2]);

        var currentCar = new Car(model, fuelAmount, fuelConsumption);

        cars.Add(currentCar);
    }
}
