using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                AddPatientsToTheDictionary(doctors, departments, command);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                PrintOutput(doctors, departments, args);

                command = Console.ReadLine();
            }
        }

        private static void PrintOutput(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[args[0]]
                    .Where(x => x.Count > 0)
                    .SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int staq))
            {
                Console.WriteLine(string.Join("\n",
                    departments[args[0]][staq - 1]
                    .OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n",
                    doctors[args[0] + args[1]].OrderBy(x => x)));
            }
        }

        private static void AddPatientsToTheDictionary(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
        {
            string[] commandTokens = command
                                .Split();

            var departament = commandTokens[0];
            var firstName = commandTokens[1];
            var secondName = commandTokens[2];
            var pacient = commandTokens[3];
            var fullName = firstName + secondName;

            SetDefaultValues(doctors, departments, departament, firstName, secondName, fullName);

            bool hasEnoughSpaceInRoom = departments[departament].SelectMany(x => x).Count() < 60;

            if (hasEnoughSpaceInRoom)
            {
                AddPatientToARoom(doctors, departments, departament, pacient, fullName);
            }
        }

        private static void SetDefaultValues(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string firstName, string secondName, string fullName)
        {
            if (!doctors.ContainsKey(firstName + secondName))
            {
                doctors[fullName] = new List<string>();
            }

            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();

                for (int stai = 0; stai < 20; stai++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private static void AddPatientToARoom(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string pacient, string fullName)
        {
            int room = 0;

            doctors[fullName].Add(pacient);

            for (int st = 0; st < departments[departament].Count; st++)
            {
                if (departments[departament][st].Count < 3)
                {
                    room = st;
                    break;
                }
            }

            departments[departament][room].Add(pacient);
        }
    }
}
