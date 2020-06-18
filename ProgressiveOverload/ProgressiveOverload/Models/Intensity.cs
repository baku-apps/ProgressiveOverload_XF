using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressiveOverload.Models
{
    public class OneRM : IIntensity
    {
        public OneRM(double oneRepMaxValue)
        {

            OneRepMaxValue = oneRepMaxValue;
        }

        public double OneRepMaxValue { get; }

        public override string ToString()
        {
            return $"{OneRepMaxValue}%";
        }
    }

    public class RPE : IIntensity
    {
        public RPE(int rpeValue)
        {
            if (rpeValue > 10)
                RpeValue = 10;
            else if (rpeValue < 1)
                RpeValue = 1;
            else
                RpeValue = rpeValue;
        }

        public int RpeValue { get; }

        public override string ToString()
        {
            return $"RPE{RpeValue}";
        }
    }

    public interface IIntensity
    {
    }

}
