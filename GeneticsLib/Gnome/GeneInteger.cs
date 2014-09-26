using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib.Gnome
{
    [Serializable]
    class GeneInteger:IGene
    {

        public object gene { set; get; }

        public GeneInteger()
        {
            gene = new int();
        }

        public void Randomize()
        {
            gene = Globals.Rand.Next(10);
        }

        public void Nullify()
        {
            gene = 0;
        }


        public dynamic ToNumber()
        {
            return Convert.ToInt32(gene);
        }
    }
}
