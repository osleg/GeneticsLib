using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    class FunctionNone:IFunction
    {
        public double Calculate(double Sum)
        {
            return Sum;
        }
    }
}
