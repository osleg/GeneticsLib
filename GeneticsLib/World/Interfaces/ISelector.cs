using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    /// <summary>
    /// selects the most fitting genomes by specific criteria and crosses and mutates them
    /// </summary>
    interface ISelector
    {
        GeneticsLib.Gnome.GenePool Pool { set; get; }
        void Select();

    }
}
