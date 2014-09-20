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

        public Being()
        {

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

        private void CalculateConnections()
        {
            throw new NotImplementedException();
        }

        public GeneticsLib.Gnome.Genome BreakToGenome()
        {
            throw new NotImplementedException();
        }
    }
}
