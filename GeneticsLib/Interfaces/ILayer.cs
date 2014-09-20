using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    interface ILayer
    {
        List<INeuron> Neurons { set; get; }
        void Fire();
        void Nullify();
    }
}
