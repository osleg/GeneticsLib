using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    [Serializable]
    class SynapseBasic:ISynapse
    {
        public int Position { set; get; }

        public int Source { set; get; }

        public int Destination { set; get; }

        public dynamic Number { set; get; }

        public SynapseBasic(int position, int source, int destination,Type T)
        {
            Position = position;
            Source = source;
            Destination = destination;
            if (T == typeof(int))
            {
                Number = new int();
            }
            else if (T == typeof(double))
            {
                Number = new double();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
