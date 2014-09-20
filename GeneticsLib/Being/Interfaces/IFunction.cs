using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    /// <summary>
    /// the various functions to be used when the neuron is firing
    /// </summary>
    public interface IFunction
    {
        /// <summary>
        /// this method calculates the value by the defined function
        /// </summary>
        /// <param name="Sum">the input of the calculation</param>
        /// <returns>the output after the function</returns>
        double Calculate(double Sum);
    }
}
