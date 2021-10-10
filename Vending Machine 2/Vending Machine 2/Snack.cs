using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_2
{
    public class Snack
    {
        public string Name;
        public double Price;
        public int Stock;
        public int Index;
        public Snack(string N, double P, int S, int I)
        {
            Name = N;
            Price = P;
            Stock = S;
            Index = I;
        }
    }
}
