using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >0)
            {
                int i = 0;
                while(i<args.Length)
                {
                    Console.WriteLine("Hello, " + args[i]);
                    i++;
                }
                
            }
            else
            {
                Console.WriteLine("Please input your name:");
                string name = Console.ReadLine();
                Console.WriteLine("How many hours of sleep did you get last night?");
                int hoursOfSleep = int.Parse(Console.ReadLine());
                Console.WriteLine("Hello, "+ name + "!");
                if (hoursOfSleep>8)
                {
                    Console.WriteLine("You are well rested");
                }
                else
                {
                    Console.WriteLine("You need more sleep");
                }
            }
        }
    }
}
