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

            //-------------------------------------------------------------------------------------------------------------------------------------------
            //Reading Files / Constructing Objects

            string[] line = new string[6];
            int i;

            if (Input == "input1.txt")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"E:\VScode\571\571hw3\571hw3\input1.txt");

                for (i = 0; i < 6; i++)
                {
                    line[i] = file.ReadLine();
                }
            }
            else if(Input == "input2.txt")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"E:\VScode\571\571hw3\571hw3\input2.txt");
                for (i = 0; i < 6; i++)
                {
                    line[i] = file.ReadLine();
                }
            }

            Data data = new Data(line[0]);
            Task w1 = new Task(line[1]);
            Task w2 = new Task(line[2]);
            Task w3 = new Task(line[3]);
            Task w4 = new Task(line[4]);
            Task w5 = new Task(line[5]);    

            //--------------------------------------------------------------------------------------------------------------------------------------
            //Schedule Algorithms

            if(Type == "EDF")
            {
                EDF(w1, w2, w3, w4, w5, data, Energy);
            }
            else if(Type == "RM")
            {
                RM(w1, w2, w3, w4, w5, data, Energy);
            }

            Console.ReadKey();

        }

        static void RM(Task w1, Task w2, Task w3, Task w4, Task w5, Data data, string EE)
        {
            Console.WriteLine("RM selected");
            return;
        }
        static void EDF(Task w1, Task w2, Task w3, Task w4, Task w5, Data data, string EE)
        {
            Console.WriteLine("EDF selected");
            return;
        }
    }
}
