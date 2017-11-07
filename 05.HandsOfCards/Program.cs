using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HandsOfCards
{
    class Program
    {
        static void Main()
        {
            var people = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "JOKER")
            {
                string[] commandArgs = input.Split(':');
                string name = commandArgs[0];
                string[] cardArgs = commandArgs[1].Trim()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new Dictionary<string, int>());
                    AddsCardToPerson(people[name], cardArgs);
                }
                else
                {
                    AddsCardToPerson(people[name], cardArgs);
                }
                input = Console.ReadLine();      
            }
            foreach (var item in people)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()}");
            }

            
        }

        private static void AddsCardToPerson(Dictionary<string, int> people, string[] cardArgs)
        {
            foreach (var item in cardArgs)
            {
                if (!people.ContainsKey(item))
                {
                    people.Add(item, ParseDigitsFromCards(item));
                }
            }
        }

        public static int ParseDigitsFromCards(string card)
        {
            int power = 0;
            switch (card[0])
            {               
                case '2': 
                case '3': 
                case '4': 
                case '5': 
                case '6': 
                case '7': 
                case '8': 
                case '9': power += (int)card[0] - 48;
                    break;
                case '1':power += 10;
                    break;
                case 'J':
                    power += 11;
                    break;
                case 'Q':
                    power += 12;
                    break;
                case 'K':
                    power += 13;
                    break;
                case 'A':
                    power += 14;
                    break;

                default:
                    break;                                     
            }
            switch (card[card.Length - 1])
            {
                case 'S':
                    power *= 4;
                    break;
                case 'H':
                    power *= 3;
                    break;
                case 'D':
                    power *= 2;
                    break;
                case 'C':
                    power *= 1;
                    break;
                default:
                    break;
            }
            return power;
        }  

    }
}
