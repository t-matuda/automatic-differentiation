using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD.ForwardMode
{
    public class Dual
    {
        public double Var { get; private set; }
        public double Eps { get; private set; }

        public Dual(double var, double eps)
        {
            this.Var = var;
            this.Eps = eps;
        }

        public static Dual operator+ (Dual a, Dual b)
        {
            return new Dual(a.Var + b.Var, a.Eps + b.Eps);
        }

        public static Dual operator +(Dual a, double b)
        {
            return a + new Dual(b, 0);
        }

        public static Dual operator +(double a, Dual b)
        {
            return new Dual(a, 0) + b;
        }

        public static Dual operator- (Dual a, Dual b)
        {
            return new Dual(a.Var - b.Var, a.Eps - b.Eps);
        }

        public static Dual operator -(Dual a, double b)
        {
            return a - new Dual(b, 0);
        }

        public static Dual operator -(double a, Dual b)
        {
            return new Dual(a, 0) - b;
        }

        public static Dual operator* (Dual a, Dual b)
        {
            return new Dual(a.Var * b.Var, a.Eps * b.Var + b.Eps * a.Var);
        }

        public static Dual operator *(Dual a, double b)
        {
            return a * new Dual(b, 0);
        }

        public static Dual operator *(double a, Dual b)
        {
            return new Dual(a, 0) * b;
        }

        public static Dual operator/ (Dual a, Dual b)
        {
            return new Dual(a.Var / b.Var, a.Eps * b.Var - a.Eps * b.Var / Math.Pow(a.Var, 2.0));
        }

        public static Dual operator /(Dual a, double b)
        {
            return a / new Dual(b, 0);
        }

        public static Dual operator /(double a, Dual b)
        {
            return new Dual(a, 0) / b;
        }

        public override string ToString()
        {
            return string.Format("Var = {0}, Eps = {1}", Var, Eps);
        }
    }
}
