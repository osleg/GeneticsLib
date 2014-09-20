using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    class LayerHidden:ILayer
    {
        private List<INeuron> neurons = new List<INeuron>();
        public List<INeuron> Neurons
        {
            get
            {
                return neurons;
            }
            set
            {
                neurons = value;
            }
        }

        public void Fire()
        {
            foreach (INeuron n in Neurons)
            {
                n.Fire();
            }
        }

        public void Nullify()
        {
            foreach (INeuron n in Neurons)
            {
                n.Nullify();
            }
        }
    }
}
