using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Bag
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] itemsInSafe = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            long goldCount = 0;
            long gemsCount = 0;
            long money = 0;

            FillInTheBag(bagCapacity, itemsInSafe, bag, ref goldCount, ref gemsCount, ref money);

            foreach (var itemType in bag)
            {
                var sumOfThatItemType = itemType.Value.Values.Sum();

                Console.WriteLine($"<{itemType.Key}> ${sumOfThatItemType}");


                foreach (var item in itemType.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void FillInTheBag(long bagCapacity, string[] itemsInSafe, Dictionary<string, Dictionary<string, long>> bag, ref long goldCount, ref long gemsCount, ref long money)
        {
            for (int i = 0; i < itemsInSafe.Length; i += 2)
            {
                string itemName = itemsInSafe[i];
                long itemQuanity = long.Parse(itemsInSafe[i + 1]);

                string itemType = GetItemType(itemName);

                bool cantProcess = itemType == string.Empty ||
                   (bagCapacity < bag.Values
                   .Select(x => x.Values.Sum()).Sum() + itemQuanity);
                var haveProblems = CheckIfThereAreProblemsInInserting(bag, itemQuanity, itemType);

                if (cantProcess || haveProblems)
                {
                    continue;
                }

                if (!bag.ContainsKey(itemType))
                {
                    bag[itemType] = new Dictionary<string, long>();
                }

                if (!bag[itemType].ContainsKey(itemName))
                {
                    bag[itemType][itemName] = 0;
                }

                bag[itemType][itemName] += itemQuanity;

                AddCount(ref goldCount, ref gemsCount, ref money, itemQuanity, itemType);
            }
        }

        private static void AddCount(ref long goldCount, ref long gemsCount, ref long money, long itemQuanity, string itemType)
        {
            if (itemType == "Gold")
            {
                goldCount += itemQuanity;
            }
            else if (itemType == "Gem")
            {
                gemsCount += itemQuanity;
            }
            else if (itemType == "Cash")
            {
                money += itemQuanity;
            }
        }

        private static bool CheckIfThereAreProblemsInInserting(Dictionary<string, Dictionary<string, long>> bag, long itemQuanity, string itemType)
        {
            switch (itemType)
            {
                case "Gem":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (itemQuanity > bag["Gold"].Values.Sum())
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + itemQuanity > bag["Gold"].Values.Sum())
                    {
                        return true;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (itemQuanity > bag["Gem"].Values.Sum())
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + itemQuanity > bag["Gem"].Values.Sum())
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        private static string GetItemType(string itemName)
        {
            string itemType = string.Empty;

            if (itemName.Length == 3)
            {
                itemType = "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }
            else if (itemName.ToLower() == "gold")
            {
                itemType = "Gold";
            }

            return itemType;
        }
    }
}