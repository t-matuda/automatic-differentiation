using AD.ForwardMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Launcher
{
    public static class BlackScholesDual
    {
        public static Dual VanillaCall(Dual S, Dual K, Dual vol, Dual T, Dual r)
        {
            return S * Normsdist(D1(S, K, vol, T, r)) - K * MathDual.Exp(-1.0 * r * T) * Normsdist(D2(S, K, vol, T, r));
        }

        private static Dual D1(Dual S, Dual K, Dual vol, Dual T, Dual r)
        {
            return (MathDual.Log(S / K) + (r + vol * vol / 2) * T) / (vol * MathDual.Sqrt(T));
        }

        private static Dual D2(Dual S, Dual K, Dual vol, Dual T, Dual r)
        {
            return D1(S, K, vol, T, r) - vol * MathDual.Sqrt(T);
        }

        private static Dual Normsdist(Dual z)
        {
            return 1 / (1.0 + MathDual.Exp(-1.7 * z));
        }
    }
}
