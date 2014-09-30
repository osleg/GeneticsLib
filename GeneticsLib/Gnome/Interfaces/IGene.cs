using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib.Gnome
{
    /// <summary>
    /// this interface represents various type of genes to be used
    /// </summary>
    public interface IGene
    {
        /// <summary>
        /// this is the gene value
        /// </summary>
        object gene { set; get; }
        /// <summary>
        /// randomizes the value
        /// </summary>
        void Randomize();
        /// <summary>
        /// sets the value to zero
        /// </summary>
        void Nullify();
        /// <summary>
        /// turns the value to number that can be used in math
        /// </summary>
        /// <returns></returns>
        dynamic ToNumber();
        /// <summary>
        /// mutates the gene in a strong way that is totally diffrent from what it was
        /// </summary>
        void MutateStrong();
        /// <summary>
        /// slitely mutates the gene, the new value varies a little from the previous one
        /// </summary>
        void MutateWeak();
        /// <summary>
        /// deep copies the Gene
        /// </summary>
        /// <returns>the copy</returns>
        IGene Clone();
    }
}
