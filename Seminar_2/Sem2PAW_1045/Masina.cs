using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2PAW_1045
{
    class Masina: Vehicul
    {
        private string culoare;
        private bool esteOmologata;

        public Masina(): base()
        {
            culoare = "nedefinit";
            esteOmologata = true;
        }

        public Masina(string m, float p, double cc, string c, bool este):
            base(m,p,cc)
        {
            culoare = c;
            esteOmologata = este;
        }

        public string Culoare { get => culoare; set => culoare = value; }
        public bool EsteOmologata { get => esteOmologata; set => esteOmologata = value; }

        public override string ToString()
        {
            string rezultat = base.ToString()+" si are culoarea "+culoare;
            if (esteOmologata == true)
                rezultat += " si este omologata";
            else
                rezultat += " si nu este omologata";
            return rezultat;
        } 
    }
}
