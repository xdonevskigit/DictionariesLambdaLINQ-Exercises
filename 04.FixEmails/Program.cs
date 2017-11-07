using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();

            Start:
            string name = Console.ReadLine();
            if (name.Equals("stop"))
            {
                foreach (var item in dict)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
                return;
            }
           
                string email = Console.ReadLine();
            int length = email.Length;
            var domain = email.Substring(length - 2, 2);

            if (domain.Equals("uk") 
                || domain.Equals("us"))
            {
                
                goto Start;
            }
            else 
            {
                dict.Add(name, email);
                goto Start;
            }
            
        }
    }
}
