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

            string[] line = new string[6];
            int i;

            if (Input == "input1.txt")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"E:\VScode\571\571hw3\571hw3\input1.txt");

                for (i = 0; i < 6; i++)
                {
                    line[i] = file.ReadLine();
                    Console.WriteLine("{0}", line[i]);
                }
            }
            else if(Input == "input2.txt")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"E:\VScode\571\571hw3\571hw3\input2.txt");
                for (i = 0; i < 6; i++)
                {
                    line[i] = file.ReadLine();
                    Console.WriteLine("{0}", line[i]);
                }
            }
            

            Console.ReadKey();


            //Successful push


        }
    }
}
