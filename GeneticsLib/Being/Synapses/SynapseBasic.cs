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

        public Gnome.IGene Gene { set; get; }

        public SynapseBasic(int position, int source, int destination)
        {
            Position = position;
            Source = source;
            Destination = destination;
        }


        public void ChangeGeneType(GeneticsLib.Gnome.GeneType Gen)
        {
            switch (Gen)
            {
                case Gnome.GeneType.Integer:
                    Gene = new GeneticsLib.Gnome.GeneInteger();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
