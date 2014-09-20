using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticsLib;
using GeneticsLib.Gnome;

namespace Tester
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Being a = new Being();
            Being b = new Being();
            b = a.Clone();
            Console.ReadKey();
        }
    }
}
