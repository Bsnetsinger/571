using System;

public class Task
{
    public string name;
    public int period;
    public int wcet1188, wcet918, wcet648, wcet384;
    public int[] execArray = new int[4];
    public bool available;
    public int remainingTime;
    public int periodCount;
    public int nextArrival;
    bool missed;
    public int freq;
    public int exeTime;

    public Task(string LineIn)
    {
        string[] values = LineIn.Split(' ');
        name = values[0];
        period = Convert.ToInt32(values[1]);
        wcet1188 = Convert.ToInt32(values[2]);
        wcet918 = Convert.ToInt32(values[3]);
        wcet648 = Convert.ToInt32(values[4]);
        wcet384 = Convert.ToInt32(values[5]);
        execArray = new int[] { wcet1188, wcet918, wcet648, wcet384 };

        available = true;
        remainingTime = wcet1188;
        periodCount = 0;
        nextArrival = period;
        missed = false;
        freq = 1188;
        exeTime = wcet1188;
        
    }

    public void CurrentTime(int Time)
    {
        if (missed)
        {
            return;
        }

        if (Time >= nextArrival)
        {
            nextArrival += period;
            if(remainingTime > 0)
            {
                Console.WriteLine("Deadline for task {0} missed.", this.name);
                missed = true;
            }
            else
            {
                switch (freq)
                {
                    case 1188:
                        remainingTime = wcet1188;
                        break;
                    case 918:
                        remainingTime = wcet918;
                        break;
                    case 648:
                        remainingTime = wcet648;
                        break;
                    case 384:
                        remainingTime = wcet384;
                        break;
                    default:
                        remainingTime = wcet1188;
                        break;
                }
            }
        }
        if(Time < nextArrival && remainingTime > 0)
        {
            available = true;
        }
        else
        {
            available = false;
        }
    }
    public void Execute(int time)
    {
        if (remainingTime > 0)
            remainingTime -= time;

        if (remainingTime == 0) //Once current task completed, calculate next arrival
        {
            available = false;
        }
    }
}