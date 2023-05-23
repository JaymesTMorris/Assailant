using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assailant
{
    static class TimeKeeper
    {
        static Stopwatch _Stopwatch = Stopwatch.StartNew();
        public static double hires_time_in_seconds()
        {
            return _Stopwatch.ElapsedMilliseconds / (double)1000;
        }
    }
}
