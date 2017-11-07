using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var legendaryDict = new Dictionary<string, long>();
            var junkDict = new Dictionary<string, long>();
            legendaryDict["shards"] = 0;
            legendaryDict["motes"] = 0;
            legendaryDict["fragments"] = 0;
            long quantity = 0;
            string type = "";
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                string[] materials = input.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i <= materials.Length; i++)
                {
                    quantity = 0;
                    if (legendaryDict["shards"] >= 250)
                    {
                        legendaryDict["shards"] -= 250;
                        Console.WriteLine("Shadowmourne obtained!");
                        foreach (var item in legendaryDict
                            .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                        foreach (var item in junkDict.OrderBy(x => x.Key))
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                        return;
                    }
                    else if (legendaryDict["motes"] >= 250)
                    {
                        legendaryDict["motes"] -= 250;
                        Console.WriteLine("Dragonwrath obtained!");
                        foreach (var item in legendaryDict
                            .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                        foreach (var item in junkDict.OrderBy(x => x.Key))
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                        return;
                    }
                    else if (legendaryDict["fragments"] >= 250)
                    {
                        legendaryDict["fragments"] -= 250;
                        Console.WriteLine("Valanyr obtained!");
                        foreach (var item in legendaryDict
                            .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                        foreach (var item in junkDict.OrderBy(x => x.Key))
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                        return;
                    }
                    
                    
                    if (i % 2 == 1)
                    {
                        type = materials[i];
                        quantity = long.Parse(materials[i - 1]);
                    }
                  
                    if (type == "shards" || type == "fragments" || type == "motes")
                    {
                        CollectTheLegendaryMaterials(type, quantity, legendaryDict);
                    }
                    else if (type != "")
                    {
                        CollectTheJunkMaterials(type, quantity, junkDict);
                    }
                }
            }

        }

        private static void CollectTheLegendaryMaterials(string type, long quantity, Dictionary<string, long> legendaryDict)
        {
            if (!legendaryDict.ContainsKey(type))
            {
                legendaryDict.Add(type, quantity);
            }
            else
            {
                legendaryDict[type] += quantity;
            }

        }

        private static void CollectTheJunkMaterials(string type, long quantity, Dictionary<string, long> junkDict)
        {
            if (!junkDict.ContainsKey(type))
            {
                junkDict.Add(type, quantity);
            }
            else
            {
                junkDict[type] += quantity;
            }
        }
    }
}
