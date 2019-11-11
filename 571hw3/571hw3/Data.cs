using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _571hw3
{
    public class Data
    {
        public int Number, Time, p1188, p918, p648, p384, pIdle;

        public Data(string LineIn)
        {
            string[] values = LineIn.Split(' ');
            Number = Convert.ToInt32(values[0]);
            Time = Convert.ToInt32(values[1]);
            p1188 = Convert.ToInt32(values[2]);
            p918 = Convert.ToInt32(values[3]);
            p648 = Convert.ToInt32(values[4]);
            p384 = Convert.ToInt32(values[5]);
            pIdle = Convert.ToInt32(values[6]);
        }
    }
}
