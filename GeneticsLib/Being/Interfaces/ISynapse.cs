using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    /// <summary>
    /// the connection between the neurons
    /// </summary>
    public interface ISynapse
    {
        int Position { get; set; }
        int Source { set; get; }
        int Destination { get; set; }
        GeneticsLib.Gnome.IGene Gene { set; get; }
        void ChangeGeneType(GeneticsLib.Gnome.GeneType Gen);
    }
}
