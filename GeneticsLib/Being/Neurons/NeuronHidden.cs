using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    [Serializable]
    class NeuronHidden:INeuron
    {
        public double Sum { set; get; }

        public double Reply { set; get; }

        public IFunction Function { set; get; }

        public NeuronHidden(FunctionType Func)
        {
            Sum = 0;
            Reply = 0;
            switch (Func)
            {
                case FunctionType.None:
                    Function = new FunctionNone();
                    break;
                case FunctionType.Sigmoid:
                    Function = new FunctionSigmoid();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        public NeuronHidden()
        {
            Sum = 0;
            Reply = 0;
            Function = new FunctionSigmoid();
        }

        public void Fire()
        {
            Reply = Function.Calculate(Sum);
        }

        public void Nullify()
        {
            Sum = 0;
            Reply = 0;
        }
    }
}
