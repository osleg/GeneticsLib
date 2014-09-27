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
    /// <summary>
    /// this is the NN construction class (must be inherited!!!)
    /// </summary>
    [Serializable]
    public class Being
    {
        /// <summary>
        /// the fitness score
        /// </summary>
        public double Score { set; get; }

        private List<ILayer> layers = new List<ILayer>();
        /// <summary>
        /// the layers of the NN
        /// </summary>
        public List<ILayer> Layers
        {
            set { layers = value; }
            get { return layers; }
        }

        private List<ISynapse> connections = new List<ISynapse>();
        /// <summary>
        /// the connections (synapses)
        /// </summary>
        public List<ISynapse> Connections
        {
            set { connections = value; }
            get { return connections; }
        }
        /// <summary>
        /// #@$%T
        /// </summary>
        public Being()
        {

        }
        /// <summary>
        /// clones the Being
        /// </summary>
        /// <returns>returtns deep copying Being</returns>
        public virtual dynamic Clone()
        {
#warning Cloning might not work, you better override the method.
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
        public void CalculateConnections()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                for (int j = 0; j < Layers[i - 1].Neurons.Count; j++)
                {
                    for (int k = 0; k < Layers[i].Neurons.Count; k++)
                    {
                        Connections.Add(new SynapseBasic(i, j, k));
                    }
                }
            }
        }
        /// <summary>
        /// runs the calculations for the score
        /// </summary>
        public virtual void Run()
        {
            // here you must run the being and set the score
            throw new NotImplementedException("You must override the Run() method to calculate Score");
        }
        /// <summary>
        /// brings in the parameters for the calculation
        /// </summary>
        /// <param name="parms">the parameters</param>
        public virtual void Fetch(dynamic parms)
        {
            // here you must put in data for the calculation
            throw new NotImplementedException("You must override the Fetch() method to calculate Score");
        }
        /// <summary>
        /// changes all the genes to single type
        /// </summary>
        /// <param name="Gen">the gene type</param>
        public void ChangeConnectionType(GeneticsLib.Gnome.GeneType Gen)
        {
            foreach (ISynapse s in Connections)
            {
                s.ChangeGeneType(Gen);
            }
            foreach (ILayer L in Layers)
            {
                if (L is LayerOutput)
                {
                    for (int i = 0; i < L.Neurons.Count; i++)
                    {
                        NeuronOutput temp = L.Neurons[i] as NeuronOutput;
                        switch (Gen)
                        {
                            case Gnome.GeneType.Integer:
                                temp.Gene = new GeneticsLib.Gnome.GeneInteger();
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// changes the gene type of a specific synapse
        /// </summary>
        /// <param name="s">the target synapse</param>
        /// <param name="Gen">the gene type</param>
        public void ChangeConnectionType(ISynapse s, GeneticsLib.Gnome.GeneType Gen)
        {
            s.ChangeGeneType(Gen);
        }
        /// <summary>
        /// changes the gene type for a specific gene
        /// </summary>
        /// <param name="Gene">the target gene</param>
        /// <param name="Gen">the gene type</param>
        public void ChangeConnectionType(GeneticsLib.Gnome.IGene Gene, GeneticsLib.Gnome.GeneType Gen)
        {
            switch (Gen)
            {
                case Gnome.GeneType.Integer:
                    Gene = new GeneticsLib.Gnome.GeneInteger();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        /// <summary>
        /// adds new layer
        /// </summary>
        /// <param name="size">amount of neurons in the layer</param>
        /// <param name="Layer">layer type</param>
        public void AddLayer(int size,LayerType Layer)
        {
            switch (Layer)
            {
                case LayerType.Input:
                    Layers.Add(new LayerInput(size));
                    break;
                case LayerType.Hidden:
                    Layers.Add(new LayerHidden(size));
                    break;
                case LayerType.Output:
                    Layers.Add(new LayerOutput(size));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        /// <summary>
        /// extracts the genome from the Being class
        /// </summary>
        /// <returns>Genome type</returns>
        public GeneticsLib.Gnome.Genome BreakToGenome()
        {
            GeneticsLib.Gnome.Genome Gnome = new Gnome.Genome();
            foreach (ISynapse s in Connections)
            {
                Gnome.Genes.Add(s.Gene);
            }
            foreach (ILayer L in Layers)
            {
                if (L is LayerOutput)
                {
                    for (int i = 0; i < L.Neurons.Count; i++)
                    {
                        NeuronOutput temp = L.Neurons[i] as NeuronOutput;
                        Gnome.Genes.Add(temp.Gene);
                    }
                }
            }
            Gnome.Score = Score;
            return Gnome.Clone();
        }
        /// <summary>
        /// inserts the Genome into the Being
        /// </summary>
        /// <param name="Gnome">the Genome to be inserted</param>
        public void InsertGenome(GeneticsLib.Gnome.Genome Gnome)
        {
            GeneticsLib.Gnome.Genome temp = Gnome.Clone();
            int i = 0;
            foreach (ISynapse S in Connections)
            {
                S.Gene = temp.Genes[i];
                i++;
            }
            foreach (ILayer L in Layers)
            {
                if (L is LayerOutput)
                {
                    for (int j = i; j < L.Neurons.Count; j++)
                    {
                        NeuronOutput temp1 = L.Neurons[j] as NeuronOutput;
                        temp1.Gene = temp.Genes[j];
                    }
                }
            }
        }
        /// <summary>
        /// randomizes the genome
        /// </summary>
        public void RandomizeGenome()
        {
            GeneticsLib.Gnome.Genome G = new Gnome.Genome();
            G = BreakToGenome();
            foreach (GeneticsLib.Gnome.IGene g in G.Genes)
            {
                g.Randomize();
            }
            InsertGenome(G);
        }
    }
}
