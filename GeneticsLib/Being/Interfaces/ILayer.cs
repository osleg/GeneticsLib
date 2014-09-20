using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    /// <summary>
    /// layer that contains neurons
    /// </summary>
    public interface ILayer
    {
        /// <summary>
        /// the neuron collection of the layer
        /// </summary>
        List<INeuron> Neurons { set; get; }
        /// <summary>
        /// fires all the neurons in the layer
        /// </summary>
        void Fire();
        /// <summary>
        /// nullifies all the neurons in the layer
        /// </summary>
        void Nullify();
    }
}
