using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.MusicUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {            
                string[] input = (Console.ReadLine()).Trim().Split(
                    new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                List<string> districtedInput = new List<string>(input);
                    
                if (input[0] == "End")
                {
                    PrintTheTicketInfo(dictionary);
                    return;
                }
                try
                {
                    WriteTheTicketStats(districtedInput, dictionary);
                }
                catch (Exception)
                {
                    continue;
                }                   
            }
        }

        private static void WriteTheTicketStats(List<string> input, 
            Dictionary<string, Dictionary<string, int>> dictionary)
        {
            int index = -1; 
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].StartsWith("@"))
                {
                    input[i] = input[i].Substring(1);
                    index = i;
                }
            }
            if (index == -1)
            {
                throw new Exception();
            }
            int range = input.Count - 2 - index;

            List<string> listVanue = new List<string>();
            for (int i = index; i < range + index; i++)
            {
                listVanue.Add(input[i]);
            }
            List<string> listName = new List<string>();
            for (int i = 0; i < index; i++)
            {
                listName.Add(input[i]);
            }
            int ticketPrice = int.Parse(input[input.Count - 2]);
            int ticketCount = int.Parse(input[input.Count - 1]);

            string name = String.Join(" ", listName);

            string vanue = String.Join(" ", listVanue);

            if (!dictionary.ContainsKey(vanue))
            {
                dictionary.Add(vanue, new Dictionary<string, int>());
                dictionary[vanue].Add(name, ticketPrice * ticketCount);
            }
            else if (!dictionary[vanue].ContainsKey(name))
            {
                dictionary[vanue].Add(name, ticketPrice * ticketCount);
            }
            else
            {
                dictionary[vanue][name] += ticketPrice * ticketCount;
            }
        }

        private static void PrintTheTicketInfo(Dictionary<string, Dictionary<string, int>> dictionary)
        {
            foreach (var names in dictionary)
            {
                Console.WriteLine(String.Join("", names.Key));
                foreach (var item in names.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
