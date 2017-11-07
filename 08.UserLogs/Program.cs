using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new SortedDictionary<string, Dictionary<string, int>>();
            while (true)
            {           
            string[] input = Console.ReadLine().Split().ToArray();
                if (input[0] == "end")
                {
                    PrintInfo(dictionary);
                    return;
                }

            string[] ipAddres = input[0].Split(new String[] { "IP=" } ,
                StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] username = input[2].Split(new String[] { "user=" },
                StringSplitOptions.RemoveEmptyEntries).ToArray();

                int count = 1;
                if (!dictionary.ContainsKey(username[0]))
                {
                    dictionary.Add(username[0], new Dictionary<string, int> { { ipAddres[0],count} });
                }
                else
                {
                    if (dictionary[username[0]].ContainsKey(ipAddres[0]))
                    {
                        dictionary[username[0]][ipAddres[0]] += count;        
                    }
                    else
                    {
                        dictionary[username[0]].Add(ipAddres[0], count = 1);
                    }
                    
                }
            }
          
        }

        private static void PrintInfo(SortedDictionary<string, Dictionary<string, int>> dictionary)
        {
            foreach (var user in dictionary)
            {
                int commaCounter = 0;
                Console.WriteLine(user.Key + ":");
                foreach (var item in user.Value)
                {
                    string ip = item.Key;
                    string count = item.Value.ToString();
                    string result = ip + " => " + count;
                    
                    Console.Write(result);
                    
                    if (commaCounter < user.Value.Count - 1)
                    {
                        Console.Write(", ");
                        commaCounter++;
                    }
                    else
                    {
                        Console.WriteLine(".");
                    }
                }
            }
        }

        
    }
}
