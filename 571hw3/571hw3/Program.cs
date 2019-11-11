using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _571hw3
{
    class Program
    {
        static void Main(string[] args)
        {
            string Input;
            string Type;
            string Energy;

            Console.WriteLine("Input file name: ");
            Input = Console.ReadLine();
            Console.WriteLine("Scheduling type: ");
            Type = Console.ReadLine();
            Console.WriteLine("EE or N/A: ");
            Energy = Console.ReadLine();

            Console.WriteLine("{0} , {1}, {2}", Input, Type, Energy);


            Console.ReadKey();

        }
    }

    class Task
    {
        private string name;
        private int period;
        private int wcet1188, wcet918, wcet648, wcet384;

        public Task(string LineIn)
        {
            string[] values = LineIn.Split(' ');
            name = values[0];
            period = Convert.ToInt32(values[1]);
            wcet1188 = Convert.ToInt32(values[2]);
            wcet918 = Convert.ToInt32(values[3]);
            wcet648 = Convert.ToInt32(values[4]);
            wcet384 = Convert.ToInt32(values[5]);
        }
    }
}
