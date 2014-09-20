using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib.Gnome
{
    public class Genome
    {
        private List<IGene> genes = new List<IGene>();
        public List<IGene> Genes
        {
            get { return genes; }
            set { genes = value; }
        }
    }
}
