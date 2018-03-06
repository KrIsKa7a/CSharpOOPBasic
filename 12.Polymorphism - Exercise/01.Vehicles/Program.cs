using System;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = GetCar();
            Vehicle truck = GetTruck();
            Bus bus = GetBus();

            var n = int.Parse(Console.ReadLine());

            ParseCommands(car, truck, bus, n);

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ParseCommands(Vehicle car, Vehicle truck, Bus bus, int n)
        {
            for (int i = 0; i < n; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var cmdType = cmdArgs[0];
                    var whatToGet = cmdArgs[1];
                    var distance = double.Parse(cmdArgs[2]);
                    ApplyChanges(car, truck, bus, cmdType, whatToGet, distance);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private static void ApplyChanges(Vehicle car, Vehicle truck, Bus bus, string cmdType, string whatToGet, double distance)
        {
            if (cmdType == "Drive")
            {
                if (whatToGet == "Car")
                {
                    Console.WriteLine(car.Drive(distance));
                }
                else if (whatToGet == "Truck")
                {
                    Console.WriteLine(truck.Drive(distance));
                }
                else if (whatToGet == "Bus")
                {
                    Console.WriteLine(bus.Drive(distance));
                }
            }
            else if (cmdType == "Refuel")
            {
                var amount = distance;

                if (whatToGet == "Car")
                {
                    car.Refuel(amount);
                }
                else if (whatToGet == "Truck")
                {
                    truck.Refuel(amount);
                }
                else if (whatToGet == "Bus")
                {
                    bus.Refuel(amount);
                }
            }
            else if (cmdType == "DriveEmpty")
            {
                Console.WriteLine(bus.DriveEmpty(distance));
            }
        }

        private static Bus GetBus()
        {
            var busTokens = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var busFuelQuantity = double.Parse(busTokens[1]);
            var busFuelConsumption = double.Parse(busTokens[2]);
            var busTankCapacity = double.Parse(busTokens[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            return bus;
        }

        private static Vehicle GetTruck()
        {
            var truckTokens = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var truckFuelQuantity = double.Parse(truckTokens[1]);
            var truckFuelConsumption = double.Parse(truckTokens[2]);
            var truckTankCapacity = double.Parse(truckTokens[3]);

            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            return truck;
        }

        private static Vehicle GetCar()
        {
            var carTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var carFuelQuantity = double.Parse(carTokens[1]);
            var carFuelConsumption = double.Parse(carTokens[2]);
            var carTankCapacity = double.Parse(carTokens[3]);

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            return car;
        }
    }
}
