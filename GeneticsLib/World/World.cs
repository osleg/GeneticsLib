using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticsLib
{
    public class World
    {
        private List<Population> populations = new List<Population>();
        public List<Population> Populations
        {
            get { return populations; }
            set { populations = value; }
        }
    }
}
