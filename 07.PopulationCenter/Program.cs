using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PopulationCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            var countries = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split('|').ToArray();
                if (input[0] == "report")
                {                    
                    PrintTheReport(countries);
                    return;
                }

                EnterPopulationToTheDictionary(countries, input);
            
            }
        }

        private static void EnterPopulationToTheDictionary(Dictionary<string, Dictionary<string, long>> countries, string[] input)
        {
            string country = input[1];
            string town = input[0];
            long population = long.Parse(input[2]);

            if (!countries.ContainsKey(country))
            {
                countries.Add(country, new Dictionary<string, long> { { town, population} });
            }
            else
            {
                if (countries[country].ContainsKey(town))
                {
                    countries[country][town] += population;
                }
                else
                {
                    countries[country].Add(town, population);
                }
            }
        }

        private static void PrintTheReport(Dictionary<string, Dictionary<string, long>> countries)
        {
            
            foreach (var country in countries.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {                    
                Console.Write(country.Key + " ");
                Console.WriteLine($"(total population: {country.Value.Values.Sum()})");
                foreach (var pop in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{pop.Key}: {pop.Value}");
                }
            }
        }
    }
}
