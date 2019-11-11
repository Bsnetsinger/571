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
            int lastExec = 0;
            int startTime = 0;
            for(int i = 0; i < 1000; i++)
            {
                w1.CurrentTime(i);
                w2.CurrentTime(i);
                w3.CurrentTime(i);
                w4.CurrentTime(i);
                w5.CurrentTime(i);

                int highestPriority = LowestPeriod(w1, w2, w3, w4, w5);

                switch (highestPriority)
                {
                    case 1:
                        w1.Execute();
                        if(highestPriority != lastExec)
                        {
                            Console.WriteLine("{0}  {1}  {2}  {3}  {4}", startTime, w1.name, i, "TBD");
                        }
                        break;
                    case 2:
                        w1.Execute();
                        if (highestPriority != lastExec)
                        {
                            Console.WriteLine("{0}  {1}  {2}  {3}  {4}", startTime, w1.name, i, "TBD");
                        }
                        break;
                    case 3:
                        w3.Execute();
                        if (highestPriority != lastExec)
                        {
                            Console.WriteLine("{0}  {1}  {2}  {3}  {4}", startTime, w3.name, i, "TBD");
                        }
                        break;
                    case 4:
                        w4.Execute();
                        if (highestPriority != lastExec)
                        {
                            Console.WriteLine("{0}  {1}  {2}  {3}  {4}", startTime, w4.name, i, "TBD");
                        }
                        break;
                    case 5:
                        w1.Execute();
                        if (highestPriority != lastExec)
                        {
                            Console.WriteLine("{0}  {1}  {2}  {3}  {4}", startTime, w5.name, i, "TBD");
                        }
                        break;
                }
                lastExec = highestPriority;
            }

            Console.WriteLine("RM selected");
            return;
        }
        static void EDF(Task w1, Task w2, Task w3, Task w4, Task w5, Data data, string EE)
        {
            Console.WriteLine("EDF selected");
            return;
        }

        //Returns int corresponding with lowest period task
        static int LowestPeriod(Task w1, Task w2, Task w3, Task w4, Task w5)
        {
            int lowest = w1.period;
            int task = 1;

            if(w1.period >= w2.period)
            {
                lowest = w2.period;
                task = 2;
            }
            if(lowest >= w3.period)
            {
                lowest = w3.period;
                task = 3;
            }
            if(lowest >= w4.period)
            {
                lowest = w4.period;
                task = 4;
            }
            if(lowest >= w5.period)
            {
                lowest = w4.period;
                task = 5;
            }
            return task;
        }
    }
}
