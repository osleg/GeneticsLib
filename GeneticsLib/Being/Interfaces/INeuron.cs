using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    /// <summary>
    /// this is the neuron type
    /// </summary>
    public interface INeuron
    {
        /// <summary>
        /// the sum is the input of all the values of the previous layer
        /// </summary>
        double Sum { set; get; }
        /// <summary>
        /// this is the output after the firing of the neuron
        /// </summary>
        double Reply { set; get; }
        /// <summary>
        /// the function to be used for calculating the reply
        /// </summary>
        IFunction Function { set; get; }
        /// <summary>
        /// calculates the reply
        /// </summary>
        void Fire();
        /// <summary>
        /// sets all the values to zero
        /// </summary>
        void Nullify();
    }
}
