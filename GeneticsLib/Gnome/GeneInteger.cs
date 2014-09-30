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
    class GeneInteger:IGene
    {

        public object gene { set; get; }

        public GeneInteger()
        {
            gene = new int();
        }

        public void Randomize()
        {
            gene = Globals.Rand.Next(10);
        }

        public void Nullify()
        {
            gene = 0;
        }


        public dynamic ToNumber()
        {
            return Convert.ToInt32(gene);
        }


        public void MutateStrong()
        {
            gene = Globals.Rand.Next(10);
        }

        public void MutateWeak()
        {
            gene = ToNumber() + Globals.Rand.Next(3) - 1;
        }


        public IGene Clone()
        {
            GeneInteger temp = new GeneInteger();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            temp = (GeneInteger)formatter.Deserialize(stream);
            stream.Dispose();
            return temp;
        }
    }
}
