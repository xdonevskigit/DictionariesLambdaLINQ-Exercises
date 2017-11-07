using System;
using System.Collections.Generic;
using System.Linq;


namespace _11.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {       
            var allDragons = new Dictionary<string, Dictionary<string, List<double>>>();
                     
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<double> defaultStats = new List<double> { 45, 250, 10 };
                var dragonList = Console.ReadLine().Trim().Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();

                string type = dragonList[0];
                string name = dragonList[1];
                string damage = dragonList[2];
                string health = dragonList[3];
                string defence = dragonList[4];

                if (damage != "null")
                {
                    defaultStats[0] = double.Parse(dragonList[2]);
                }
                if (health != "null")
                {
                    defaultStats[1] = double.Parse(dragonList[3]);
                }
                if (defence != "null")
                {
                    defaultStats[2] = double.Parse(dragonList[4]);
                }
                if (!allDragons.ContainsKey(type))
                {
                    allDragons.Add(type, new Dictionary<string, List<double>>());
                    allDragons[type].Add(name, new List<double>(defaultStats));
                }
                else if (allDragons.ContainsKey(type) && !allDragons[type].ContainsKey(name))
                {
                    allDragons[type].Add(name, new List<double>(defaultStats));
                }
                else if (allDragons.ContainsKey(type) && allDragons[type].ContainsKey(name))
                {                   
                    allDragons[type][name] = new List<double>(defaultStats);
                }               
            }
                    
            foreach (var item in allDragons)
            {
                var averageDamage = item.Value.Values.Average(i => i[0]);
                var averageHealth = item.Value.Values.Average(i => i[1]);
                var averageDefence = item.Value.Values.Average(i => i[2]);
                
                Console.WriteLine($"{item.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageDefence:F2})");
                foreach (var stats in item.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{stats.Key} -> damage: {stats.Value[0]}, " +
                        $"health: {stats.Value[1]}, armor: {stats.Value[2]}");
                }
            }
        }
    }
}
