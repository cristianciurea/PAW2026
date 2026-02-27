using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2PAW_1047
{
    class Tigru: Animal
    {
        private char sex;
        private bool esteDresat;

        public Tigru(): base()
        {
            sex = 'M';
            esteDresat = true;
        }

        public Tigru(int v, string n, float g, char s, bool este):
            base(v,n,g)
        {
            sex = s;
            esteDresat = este;
        }

        public char Sex { get => sex; set => sex = value; }
        public bool EsteDresat { get => esteDresat; set => esteDresat = value; }

        public override string ToString()
        {
            string rezultat = base.ToString() + " si sexul "+sex;
            if (esteDresat == true)
                rezultat += " si este dresat";
            else
                rezultat += " si nu este dresat";
            return rezultat;
        }
    }
}
