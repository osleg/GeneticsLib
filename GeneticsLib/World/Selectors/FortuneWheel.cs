using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    public class FortuneWheel:ISelector
    {
        private Gnome.GenePool pool = new Gnome.GenePool();
        public Gnome.GenePool Pool
        {
            get
            {
                return pool;
            }
            set
            {
                pool = value;
            }
        }

        public FortuneWheel(Gnome.GenePool P)
        {
            Pool = P;
        }

        public void Select()
        {
            throw new NotImplementedException("must choose two most fit by score and cross and mutate them");
        }
    }
}
