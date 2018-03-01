using System;
using System.Collections.Generic;
using _08.MilitaryElit.Models;
using _08.MilitaryElit.Interfaces;
using System.Linq;

namespace _08.MilitaryElit
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var army = new List<ISoldier>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input
                    .Split();

                var type = inputArgs[0];
                var id = inputArgs[1];
                var firstName = inputArgs[2];
                var lastName = inputArgs[3];
                var salary = decimal.Parse(inputArgs[4]);

                if (type == "Private")
                {
                    var @private = new Private(id, firstName, lastName, salary);

                    army.Add(@private);
                }
                else if (type == "LeutenantGeneral")
                {
                    var general = new LeutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < inputArgs.Length; i++)
                    {
                        var currentId = inputArgs[i];

                        var @private = army
                            .First(p => p.Id == currentId);

                        general.AddPrivate(@private);
                    }

                    army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        var corps = inputArgs[5];

                        var engineer = new Engineer(id, firstName, lastName, salary, corps);

                        for (int i = 6; i < inputArgs.Length; i += 2)
                        {
                            var partName = inputArgs[i];
                            var workHours = int.Parse(inputArgs[i + 1]);

                            var repair = new Repair(partName, workHours);


                            engineer.AddRepair(repair);
                        }

                        army.Add(engineer);
                    }
                    catch (Exception) { }
                }
                else if (type == "Commando")
                {
                    var corps = inputArgs[5];

                    try
                    {
                        var commando = new Commando(id, firstName, lastName, salary, corps);

                        for (int i = 6; i < inputArgs.Length; i += 2)
                        {
                            try
                            {
                                var codeName = inputArgs[i];
                                var state = inputArgs[i + 1];

                                var mission = new Mission(codeName, state);

                                commando.AddMission(mission);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }

                        army.Add(commando);
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                else if (type == "Spy")
                {
                    var codeNumber = (int)salary;
                    var spy = new Spy(id, firstName, lastName, codeNumber);

                    army.Add(spy);
                }
            }

            foreach (var soldier in army)
            {
                Type type = soldier.GetType();

                var actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual);
            }
        }
    }
}
