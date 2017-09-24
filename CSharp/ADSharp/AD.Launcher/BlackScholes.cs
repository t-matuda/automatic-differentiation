using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Launcher
{
    public static class BlackScholes
    {
        public static double VanillaCall(double S, double K, double vol, double T, double r)
        {
            if (T <= 0.0)
            {
                return Math.Max(0.0, S - K);
            }
            else
            {
                return S * Normsdist(D1(S, K, vol, T, r)) - K * Math.Exp(-r * T) * Normsdist(d2(S, K, vol, T, r));
            }
        }

        public static double Delta(double S, double K, double vol, double T, double r)
        {
            return Normsdist(D1(S, K, vol, T, r));
        }


        private static double D1(double S, double K, double vol, double T, double r)
        {
            return (Math.Log(S / K) + (r + vol * vol / 2) * T) / (vol * Math.Sqrt(T));
        }

        private static double d2(double S, double K, double vol, double T, double r)
        {
            return D1(S, K, vol, T, r) - vol * Math.Sqrt(T);
        }

        private static double Normsdist(double z)
        {
            return 1 / (1 + Math.Exp(-1.7 * z));
        }
    }
}
