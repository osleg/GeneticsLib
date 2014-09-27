using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GeneticsLib.Gnome
{
    [Serializable]
    public class Genome
    {
        public double Score { set; get; }
        private List<IGene> genes = new List<IGene>();
        public List<IGene> Genes
        {
            get { return genes; }
            set { genes = value; }
        }
        public Genome Clone()
        {
            Genome temp = new Genome();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            temp = (Genome)formatter.Deserialize(stream);
            stream.Dispose();
            return temp;
        }
    }
}
