using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.ForwardMode
{
    public static class MathDual
    {
        public static Dual Abs(Dual x)
        {
            return new Dual(Math.Abs(x.Var), Math.Abs(x.Eps));
        }

        public static Dual Log(Dual x)
        {
            return new Dual(Math.Log(x.Var), 1 / x.Eps);
        }

        public static Dual Pow(Dual x, double y)
        {
            return new Dual(Math.Pow(x.Var, y), y * Math.Pow(x.Var, y - 1) * x.Eps);
        }

        public static Dual Sin(Dual x)
        {
            return new Dual(Math.Sin(x.Var), Math.Cos(x.Var) * x.Eps);
        }

        public static Dual Cos(Dual x)
        {
            return new Dual(Math.Cos(x.Var), -1 * Math.Sin(x.Var) * x.Eps);
        }

        public static Dual Exp(Dual x)
        {
            return new Dual(Math.Exp(x.Var), Math.Exp(x.Var) * x.Eps);
        }

        public static Dual Sqrt(Dual x)
        {
            return new Dual(Math.Sqrt(x.Var), 0.5 * Math.Pow(x.Var, -0.5) * x.Eps);
        }
    }
}
