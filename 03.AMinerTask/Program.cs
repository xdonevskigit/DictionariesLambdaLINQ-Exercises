using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new Dictionary<string, int>();
            Start:
            string resours = Console.ReadLine();
            int quantity;
            if (resours.Equals("stop"))
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
               
            }
            else
            {
                quantity = int.Parse(Console.ReadLine());
                if (collection.ContainsKey(resours))
                {
                    collection[resours] += quantity;
                }
                else
                {
                    collection[resours] = quantity;
                }
                goto Start;
            }

        }
    }
}
