using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticsLib;
using GeneticsLib.Gnome;
using System.Collections;
namespace Tester
{
    class Program
    {
		static char[] CharArray(string s)
		{
			int i = 0;
			char[] temp = new char[s.Length];
			foreach (char C in s)
			{
				temp[i] = C;
				i++;
			}
			return temp;
		}

        static void Main(string[] args)
        {
            Console.WriteLine("write numbers sequence");
            string seq = Console.ReadLine();
            Sequence test = new Sequence();
			char[] letters = CharArray(seq);
            test.AddLayer(letters.Length, LayerType.Output);
            test.ChangeConnectionType(GeneType.Integer);
            Population p = new Population(15, test);
            p.RandomizeGenomes();
            try
            {
                foreach (Being B in p.Beings)
                {
                    B.Fetch(letters);
                }
                int j = 0;
                foreach (IGene i in p.Beings[5].BreakToGenome().Genes)
                {
                    Console.Write(p.Beings[5].BreakToGenome().Genes[j].ToNumber());
                    j++;
                }
                p.Run();
                Console.WriteLine("\n" + p.Beings[5].Score);
            }
            catch (FormatException e)
            {
                Console.WriteLine("next time write numbers");
            }
            Console.ReadKey();
        }
    }
    [Serializable]
    public class Sequence : Being
    {
        public List<int> sequenss = new List<int>();
        public override void Run()
        {
            Score = 0;
            for (int i = 0; i < sequenss.Count; i++)
            {
                Score += Math.Abs(sequenss[i] - BreakToGenome().Genes[i].ToNumber());
            }
        }
        public override void Fetch(dynamic parms)
        {
            foreach (char C in parms)
            {
                sequenss.Add(int.Parse(C.ToString()));
            }
        }
    }
}
