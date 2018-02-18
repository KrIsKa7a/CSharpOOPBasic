using System;
using System.Collections.Generic;
using System.Linq;

class RawData
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            AddCar(cars);
        }

        string command = Console.ReadLine();

        FilterAndPrintCars(cars, command);
    }

    private static void FilterAndPrintCars(List<Car> cars, string command)
    {
        if (command == "fragile")
        {
            List<string> fragile = cars
                .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragile));
        }
        else
        {
            List<string> flamable = cars
                .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamable));
        }
    }

    private static void AddCar(List<Car> cars)
    {
        string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string model, cargoType;
        int engineSpeed, enginePower, cargoWeight, tire1age, tire2age, tire3age, tire4age;
        double tire1Pressure, tire2Pressure, tire3Pressure, tire4Pressure;

        GetCarParametes(parameters, out model, out engineSpeed, out enginePower, out cargoWeight, out cargoType, out tire1Pressure, out tire1age, out tire2Pressure, out tire2age, out tire3Pressure, out tire3age, out tire4Pressure, out tire4age);

        var carEngine = new Engine(engineSpeed, enginePower);
        var carCargo = new Cargo(cargoWeight, cargoType);
        var carTires = new Tire[]
        {
                new Tire(tire1Pressure, tire1age),
                new Tire(tire2Pressure, tire2age),
                new Tire(tire3Pressure, tire3age),
                new Tire(tire4Pressure, tire4age)
        };

        var currentCar = new Car(model, carEngine, carCargo, carTires);

        cars.Add(currentCar);
    }

    private static void GetCarParametes(string[] parameters, out string model, out int engineSpeed, out int enginePower, out int cargoWeight, out string cargoType, out double tire1Pressure, out int tire1age, out double tire2Pressure, out int tire2age, out double tire3Pressure, out int tire3age, out double tire4Pressure, out int tire4age)
    {
        model = parameters[0];
        engineSpeed = int.Parse(parameters[1]);
        enginePower = int.Parse(parameters[2]);
        cargoWeight = int.Parse(parameters[3]);
        cargoType = parameters[4];
        tire1Pressure = double.Parse(parameters[5]);
        tire1age = int.Parse(parameters[6]);
        tire2Pressure = double.Parse(parameters[7]);
        tire2age = int.Parse(parameters[8]);
        tire3Pressure = double.Parse(parameters[9]);
        tire3age = int.Parse(parameters[10]);
        tire4Pressure = double.Parse(parameters[11]);
        tire4age = int.Parse(parameters[12]);
    }
}
