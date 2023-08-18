using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public enum UnitOfWeight
    {
        G,
        Kg
    }

    public struct Weight
    {
        public double Amount { get; private set; }
        public UnitOfWeight Unit { get; private set; }

        public Weight(double weight, UnitOfWeight unit)
        {
            Amount = weight;
            Unit = unit;
        }

        public void DecreaseWeight(Weight weight)
        {
            if (Amount >= weight.Amount)
                Amount -= weight.Amount;
        }

        public void IncreaseWeight(Weight weight)
        {
            Amount += weight.Amount;
        }

        public override string ToString()
        {
            return Amount + "гр.";
        }

    }
}
