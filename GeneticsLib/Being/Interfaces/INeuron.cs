using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    interface INeuron
    {
        double Sum { set; get; }
        double Reply { set; get; }
        IFunction Function { set; get; }
        void Fire();
        void Nullify();
    }
}
