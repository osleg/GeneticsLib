using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    [Serializable]
    class NeuronInput:INeuron

    {
        public double Sum { set; get; }

        public double Reply { set; get; }

        public IFunction Function { get; set; }

        public NeuronInput(FunctionType Func)
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
        public NeuronInput()
        {
            Sum = 0;
            Reply = 0;
            Function = new FunctionNone();
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
