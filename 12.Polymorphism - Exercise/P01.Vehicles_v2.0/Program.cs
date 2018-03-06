using System;
using System.Collections.Generic;

namespace P01.Vehicles_v2._0
{
    class Program
    {
        private static List<Vehicle> vehicles = new List<Vehicle>();

        static void Main(string[] args)
        {
            //Vehicle {initial fuel quantity} {liters per km} {tank capacity}
            Vehicle car = GetCar();
            Vehicle truck = GetTruck();
            Bus bus = GetBus();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine()
                    .Split();

                var type = cmdArgs[0];
                var whatToOperate = cmdArgs[1];

                if (whatToOperate == "Car")
                {
                    if (type == "Drive")
                    {
                        var distance = double.Parse(cmdArgs[2]);
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (type == "Refuel")
                    {
                        var liters = double.Parse(cmdArgs[2]);
                        try
                        {
                            car.Refuel(liters);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (whatToOperate == "Truck")
                {
                    if (type == "Drive")
                    {
                        var distance = double.Parse(cmdArgs[2]);
                        Console.WriteLine(truck.Drive(distance));
                    }
                    else if (type == "Refuel")
                    {
                        var liters = double.Parse(cmdArgs[2]);
                        try
                        {
                            truck.Refuel(liters);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (whatToOperate == "Bus")
                {
                    if (type == "Drive")
                    {
                        var distance = double.Parse(cmdArgs[2]);
                        Console.WriteLine(bus.Drive(distance));
                    }
                    else if (type == "DriveEmpty")
                    {
                        var distance = double.Parse(cmdArgs[2]);
                        Console.WriteLine(bus.DriveEmpty(distance));
                    }
                    else if (type == "Refuel")
                    {
                        var liters = double.Parse(cmdArgs[2]);
                        try
                        {
                            bus.Refuel(liters);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }

            foreach (var veh in vehicles)
            {
                Console.WriteLine(veh);
            }
        }

        private static Bus GetBus()
        {
            var busArgs = Console.ReadLine()
                .Split();

            var fuelQuantity = double.Parse(busArgs[1]);
            var fuelConsupmtion = double.Parse(busArgs[2]);
            var fuelCapacity = double.Parse(busArgs[3]);

            var bus = new Bus(fuelQuantity, fuelConsupmtion, fuelCapacity);
            vehicles.Add(bus);

            return bus;
        }

        private static Vehicle GetTruck()
        {
            var truckArgs = Console.ReadLine()
                .Split();

            var fuelQuantity = double.Parse(truckArgs[1]);
            var fuelConsupmtion = double.Parse(truckArgs[2]);
            var fuelCapacity = double.Parse(truckArgs[3]);

            var truck = new Truck(fuelQuantity, fuelConsupmtion, fuelCapacity);
            vehicles.Add(truck);

            return truck;
        }

        private static Vehicle GetCar()
        {
            var carArgs = Console.ReadLine()
                .Split();

            var fuelQuantity = double.Parse(carArgs[1]);
            var fuelConsupmtion = double.Parse(carArgs[2]);
            var fuelCapacity = double.Parse(carArgs[3]);

            var car = new Car(fuelQuantity, fuelConsupmtion, fuelCapacity);
            vehicles.Add(car);

            return car;
        }
    }
}
