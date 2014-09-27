using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    [Serializable]
    public class NeuronOutput:INeuron//todo remove public
    {
        public GeneticsLib.Gnome.IGene Gene { set; get; }

        public double Sum { set; get; }

        public double Reply { set; get; }

        public IFunction Function { set; get; }

        public NeuronOutput(FunctionType Func, GeneticsLib.Gnome.GeneType Gen)
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
            switch (Gen)
            {
                case Gnome.GeneType.Integer:
                    Gene = new GeneticsLib.Gnome.GeneInteger();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        public NeuronOutput()
        {
            Sum = 0;
            Reply = 0;
            Function = new FunctionNone();
            Gene = new GeneticsLib.Gnome.GeneInteger();
        }

        public void Fire()
        {
            Reply = Function.Calculate(Sum)*Gene.ToNumber();
        }

        public void Nullify()
        {
            Sum = 0;
            Reply = 0;
        }
    }
}
