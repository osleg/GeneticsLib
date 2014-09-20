using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib.Gnome
{
    interface IGene
    {
        object gene { set; get; }
        void Randomize();
        void Nullify();
        dynamic ToNumber();
    }
}
