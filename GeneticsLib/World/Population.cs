using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    public class Population
    {
        private List<Being> beings = new List<Being>();
        public List<Being> Beings
        {
            set { beings = value; }
            get { return beings; }
        }
        public Population(int Size, Being being)
        {
            for (int i = 0; i < Size; i++)
            {
                Beings.Add(being.Clone());
            }
        }
        public void RandomizeGenomes()
        {
            foreach (Being B in Beings)
            {
                B.RandomizeGenome();
            }
        }
        public void Run()
        {
            foreach (Being B in Beings)
            {
                B.Run();
            }
        }
    }
}
