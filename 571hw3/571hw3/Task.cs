using System;

public class Task
{
    public string name;
    public int period;
    public int wcet1188, wcet918, wcet648, wcet384;
    public bool available;
    public int remainingTime;
    public int periodCount;

    public Task(string LineIn)
    {
        string[] values = LineIn.Split(' ');
        name = values[0];
        period = Convert.ToInt32(values[1]);
        wcet1188 = Convert.ToInt32(values[2]);
        wcet918 = Convert.ToInt32(values[3]);
        wcet648 = Convert.ToInt32(values[4]);
        wcet384 = Convert.ToInt32(values[5]);
        available = true;
        remainingTime = wcet1188;
        periodCount = 0;
    }
    public void CurrentTime(int Time)
    {
        if ((periodCount + 1) * period == Time) //Begin new period, task re-enters the system
        {
            periodCount++;
            remainingTime = wcet1188; //Reset execution time
        }
               
        if (remainingTime > 0 && Time >= (periodCount * period)) //Has not been fully executed and task is in the system
            available = true;
        else
            available = false;
    }
    public void Execute()
    {
        if (remainingTime > 0)
            remainingTime--;
        else
            Console.WriteLine("Error: Attempt to execute completed task.");
    }
}