using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib.Gnome
{
    [Serializable]
    public class GenePool
    {
        enum CrossType
        {
            /// <summary>
            /// exchanges random genes between the genomes
            /// </summary>
            DoublePoint,
            SinglePointLast,
            SinglePointFirst,
            PassToWeakDoublePoint,
            PassToWeakSinglePointLast,
            PassToWeakSinglePointFirst
        }
        enum MutationType
        {
            Strong,
            Weak
        }
        private List<Genome> genome = new List<Genome>();
        public List<Genome> Pool
        {
            set { genome = value; }
            get { return genome; }
        }
        void GeneCrossBreed(int A, int B, CrossType Type)
        {
            switch (Type)
            {
                case CrossType.DoublePoint:
                    int PointA = Globals.Rand.Next(Pool[A].Genes.Count);
                    int PointB = Globals.Rand.Next(PointA, Pool[B].Genes.Count);
                    for (int i=PointA; PointA <= PointB; PointA++)
                    {
                        IGene G = Pool[A].Genes[i].Clone();
                        Pool[A].Genes[i] = Pool[B].Genes[i].Clone();
                        Pool[B].Genes[i] = G.Clone();
                    }
                    break;
                default:
                    throw new NotImplementedException("such crossType is not defined in the switch case, please add");
            }
        }
        void GeneMutate(int A, MutationType Type,double chance)
        {
            if (chance > 1)
            {
                throw new NotImplementedException("chance must be from 0 to 1");
            }
            if (Globals.Rand.NextDouble() < chance)
            {
                switch (Type)
                {
                    case MutationType.Strong:
                        Pool[A].Genes[Globals.Rand.Next(Pool[A].Genes.Count)].MutateStrong();
                        break;
                    case MutationType.Weak:
                        Pool[A].Genes[Globals.Rand.Next(Pool[A].Genes.Count)].MutateWeak();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
