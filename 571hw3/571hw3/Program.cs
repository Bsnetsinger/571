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
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\micha\OneDrive\Desktop\571\571\571hw3\571hw3\input1.txt");

                for (i = 0; i < 6; i++)
                {
                    line[i] = file.ReadLine();
                }
            }
            else if(Input == "input2.txt")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"C: \Users\micha\OneDrive\Desktop\571\571\571hw3\571hw3\input2.txt");
                for (i = 0; i < 6; i++)
                {
                    line[i] = file.ReadLine();
                }
            }

            Data data = new Data(line[0]);
            Task[] taskArray = new Task[5];
            taskArray[0] = new Task(line[1]);
            taskArray[1] = new Task(line[2]);
            taskArray[2] = new Task(line[3]);
            taskArray[3] = new Task(line[4]);
            taskArray[4] = new Task(line[5]);
            

            //--------------------------------------------------------------------------------------------------------------------------------------
            //Schedule Algorithms

            if(Type == "EDF")
            {
                EDF(taskArray, data, Energy);
            }
            else if(Type == "RM")
            {
                RM(taskArray, data, Energy);
            }

            Console.ReadKey();

        }

        static void RM(Task[] taskArray, Data data, string EE)
        {

            Console.WriteLine("RM selected");

            int counter = 0;
            Task[] priorityArray = LowestPeriod(taskArray);
            while (counter <= data.Time)
            {
                bool idle = false;
                string processName;

                for(int k = 0; k < 5; k++)
                {
                    priorityArray[k].CurrentTime(counter); //If task arrived, resets remaining time and becomes available 
                }

                int availableHiPriority = 0; //Set to index of available task w/ highest priority
                while (!(priorityArray[availableHiPriority].available))
                {
                    availableHiPriority++;
                    if (availableHiPriority == 5)
                    {
                        idle = true;
                        break;
                    }
                }

                int nextArrival = data.Time;
                for (int j = 0; j < 5; j++)
                {
                    if (nextArrival > priorityArray[j].nextArrival && priorityArray[j].nextArrival > counter)
                        nextArrival = priorityArray[j].nextArrival;
                }

                int time;
                double power;

                if (idle)
                {
                    time = nextArrival - counter;
                }
                else
                {
                    if (priorityArray[availableHiPriority].remainingTime + counter > nextArrival && nextArrival > counter)
                        time = nextArrival - counter;
                    else
                        time = priorityArray[availableHiPriority].remainingTime;
                }
                
                counter += time;

                if (idle)
                {
                    processName = "IDLE";
                    power = time * data.pIdle / 1000.0;
                }
                else
                {
                    processName = priorityArray[availableHiPriority].name;
                    priorityArray[availableHiPriority].Execute(time);
                    power = time * data.p1188 / 1000.0;
                }


                Console.WriteLine("{0} {1} {2} {3} {4}J", counter - time, processName, 1188, time, power.ToString());
            }
            return;
        }
        static void EDF(Task[] taskArray, Data data, string EE)
        {
            Console.WriteLine("EDF selected");

            int counter = 0;
            while (counter <= data.Time)
            {
                bool idle = false;
                string processName;

                for (int k = 0; k < 5; k++)
                {
                    taskArray[k].CurrentTime(counter); //If task arrived, resets remaining time and becomes available 
                }

                int nextArrival = data.Time;
                int nextTask = 0;

                idle = true;
                for (int j = 0; j < 5; j++)
                {
                    if (nextArrival >= taskArray[j].nextArrival && taskArray[j].nextArrival > counter )
                    {
                        nextArrival = taskArray[j].nextArrival;
                    }
                    if (taskArray[j].available)
                    {
                        idle = false;
                    }
                }
                int nextDeadline = data.Time + data.Time;
                for(int k = 0; k < 5; k++)
                {
                    if (nextDeadline >= taskArray[k].nextArrival && taskArray[k].available)
                    {
                        nextDeadline = taskArray[k].nextArrival;
                        nextTask = k;
                    }
                }

                int time;
                double power;

                if (idle)
                {
                    time = nextArrival - counter;
                }
                else
                {
                    if (taskArray[nextTask].remainingTime + counter > nextArrival && nextArrival > counter)
                        time = nextArrival - counter;
                    else
                        time = taskArray[nextTask].remainingTime;
                }

                counter += time;

                if (idle)
                {
                    processName = "IDLE";
                    power = time * data.pIdle / 1000.0;
                }
                else
                {
                    processName = taskArray[nextTask].name;
                    taskArray[nextTask].Execute(time);
                    power = time * data.p1188 / 1000.0;
                }


                 Console.WriteLine("{0} {1} {2} {3} {4}J", counter - time, processName, 1188, time, power.ToString());
            }
            return;
        }

        //Bubble sorts array with respect to period
        static Task[] LowestPeriod(Task[] taskArray)
        {
            Task[] newTaskArray = taskArray;
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if( newTaskArray[j].period > newTaskArray[j+1].period )
                    {
                        Task temp = newTaskArray[j];
                        newTaskArray[j] = newTaskArray[j + 1];
                        newTaskArray[j + 1] = temp;
                    }
                }
            }
            return newTaskArray;
        }
    }
}
