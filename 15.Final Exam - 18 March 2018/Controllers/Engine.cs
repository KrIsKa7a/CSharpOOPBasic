using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Controllers
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (!String.IsNullOrWhiteSpace(command) && !dungeonMaster.IsGameOver())
            {
                var cmdArgs = command
                    .Split();

                var cmdType = cmdArgs[0];
                var methodArgs = cmdArgs.Skip(1).ToArray();

                try
                {
                    ParseCommand(cmdType, methodArgs);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Parameter Error: " + ae.Message);
                }
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine("Invalid Operation: " + ioe.Message);
                }

                if (dungeonMaster.IsGameOver())
                {
                    break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }

        private void ParseCommand(string cmdType, string[] methodArgs)
        {
            switch (cmdType)
            {
                case "JoinParty":
                    Console.WriteLine(dungeonMaster.JoinParty(methodArgs));
                    break;
                case "AddItemToPool":
                    Console.WriteLine(dungeonMaster.AddItemToPool(methodArgs));
                    break;
                case "PickUpItem":
                    Console.WriteLine(dungeonMaster.PickUpItem(methodArgs));
                    break;
                case "UseItem":
                    Console.WriteLine(dungeonMaster.UseItem(methodArgs));
                    break;
                case "UseItemOn":
                    Console.WriteLine(dungeonMaster.UseItemOn(methodArgs));
                    break;
                case "GiveCharacterItem":
                    Console.WriteLine(dungeonMaster.GiveCharacterItem(methodArgs));
                    break;
                case "GetStats":
                    Console.WriteLine(dungeonMaster.GetStats());
                    break;
                case "Attack":
                    Console.WriteLine(dungeonMaster.Attack(methodArgs));
                    break;
                case "Heal":
                    Console.WriteLine(dungeonMaster.Heal(methodArgs));
                    break;
                case "EndTurn":
                    Console.WriteLine(dungeonMaster.EndTurn(methodArgs));
                    break;
                case "IsGameOver":
                    /*Console.WriteLine(*/dungeonMaster.IsGameOver();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
