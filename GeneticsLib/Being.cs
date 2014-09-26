using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GeneticsLib
{
    [Serializable]
    public class Being
    {
        public double Score { set; get; }

        private List<ILayer> layers = new List<ILayer>();
        public List<ILayer> Layers
        {
            set { layers = value; }
            get { return layers; }
        }

        private List<ISynapse> connections = new List<ISynapse>();
        public List<ISynapse> Connections
        {
            set { connections = value; }
            get { return connections; }
        }
        /// <summary>
        /// must construct the NN in the constructor
        /// </summary>
        public Being()
        {
            Layers.Add(new LayerInput(2));
            Layers.Add(new LayerHidden(2));
            Layers.Add(new LayerOutput(1));
            CalculateConnections(typeof(double));
        }

        public Being Clone()
        {
            Being temp = new Being();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            temp = (Being)formatter.Deserialize(stream);
            stream.Dispose();
            return temp;
        }
        /// <summary>
        /// calculates the synapses between layers
        /// </summary>
        /// <param name="T">type of value of the synapse</param>
        private void CalculateConnections(Type T)
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                for (int j = 0; j < Layers[i - 1].Neurons.Count; j++)
                {
                    for (int k = 0; k < Layers[i].Neurons.Count; k++)
                    {
                        Connections.Add(new SynapseBasic(i, j, k, T));
                    }
                }
            }
        }

        public GeneticsLib.Gnome.Genome BreakToGenome()
        {
            throw new NotImplementedException();
        }
    }
}
