using AD.ForwardMode;
using System;
using System.Diagnostics;
using System.Linq;

namespace AD.Launcher
{
    public class Program
    {
        static void Main(string[] args)
        {
            var S = 100.0;
            var K = 110.0;
            var r = 0.07;
            var vol = 0.2;
            var T = 0.25;

            var S_Dual = new Dual(S, 1);
            var K_Dual = new Dual(K, 0);
            var r_Dual = new Dual(r, 0);
            var vol_Dual = new Dual(vol, 0);
            var T_Dual = new Dual(T, 0);

            //Func<double, double> bs = (s) => BlackScholes.VanillaCall(s, K, vol, T, r);
            using (var _ = new StopwatchEx("BlackSholes"))
            {
                foreach (var __ in Enumerable.Range(0, 1))
                {
                    var p_Dual = BlackScholesDual.VanillaCall(S_Dual, K_Dual, vol_Dual, T_Dual, r_Dual);
                    var p = BlackScholes.VanillaCall(S, K, vol, T, r);
                    var delta = BlackScholes.Delta(S, K, vol, T, r);
                    //var delta_fd = FiniteDifference(bs, S, 1e-13);
                    
                    Console.WriteLine(p_Dual);
                    Console.WriteLine("Price ={0}, Delta = {1}", p, delta);
                    //Console.WriteLine("Delta(FD) = {0}", delta_fd);
                }
            }
        }
        
        public static double FiniteDifference(Func<double, double> func, double x, double h)
        {
            return (func(x + h) - func(x - h)) / (2 * h);
        }
    }

    public class StopwatchEx : IDisposable
    {
        private Stopwatch sw;
        private string funcName;

        public StopwatchEx()
        {
            sw = Stopwatch.StartNew();
        }

        public StopwatchEx(string funcName)
        {
            sw = Stopwatch.StartNew();
            this.funcName = funcName;
        }

        public void Dispose()
        {
            sw.Stop();
            Console.WriteLine("{0} : {1}[ms]", funcName, sw.ElapsedMilliseconds);
        }
    }
}
