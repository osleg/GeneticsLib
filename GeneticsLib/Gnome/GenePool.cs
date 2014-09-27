using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib.Gnome
{
    [Serializable]
    class GenePool
    {
        private List<Genome> genome = new List<Genome>();
        public List<Genome> Genome
        {
            set { genome = value; }
            get { return genome; }
        }
    }
}
