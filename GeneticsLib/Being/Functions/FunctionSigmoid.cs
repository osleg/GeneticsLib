using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    class FunctionSigmoid:IFunction
    {
        public double Calculate(double Sum)
        {
            return Sum / (1 + Math.Abs(Sum));
        }
    }
}
