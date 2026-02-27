using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2PAW_1047
{
    class Pinguin: Animal
    {
        private int nrPui;
        private bool areIgloo;

        public Pinguin():base()
        {
            nrPui = 0;
            areIgloo = false;
        }

        public Pinguin(int v, string n, float g, int nr, bool are):
            base(v,n,g)
        {
            nrPui = nr;
            areIgloo = are;
        }

        public int NrPui { get => nrPui; set => nrPui = value; }
        public bool AreIgloo { get => areIgloo; set => areIgloo = value; }

        public override string ToString()
        {
            return base.ToString() + " si are "+nrPui+" pui si are igloo "+areIgloo;
        }
    }
}
