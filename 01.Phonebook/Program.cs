using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();
            Start:
            List<string> command = Console.ReadLine().Split().ToList();

            switch (command[0])
            {
                case "A":
                    if (dict.ContainsKey(command[1]))
                    {
                        dict[command[1]] = command[2];
                    }
                    else
                    {
                        dict.Add(command[1], command[2]);
                    }
                    
                    goto Start;
                case "S":
                    if (dict.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"{command[1]} -> {dict[command[1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {command[1]} does not exist.");
                    }
                    goto Start;
                case "END":
                    return;
                default:
                    break;
            }
        }
    }
}
