using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2PAW_1045
{
    class Motocicleta: Vehicul
    {
        private string motorizare;
        private bool esteHibrid;

        public Motocicleta():base()
        {
            motorizare = "BENZINA";
            esteHibrid = true;
        }

        public Motocicleta(string m, float p, double cc, string moto, bool este):
            base(m, p, cc)
        {
            motorizare = moto;
            esteHibrid = este;
        }

        public string Motorizare { get => motorizare; set => motorizare = value; }
        public bool EsteHibrid { get => esteHibrid; set => esteHibrid = value; }

        public override string ToString()
        {
            return base.ToString() + " si are motorizare " + motorizare +
                " si este hibrid " + esteHibrid;
        }
    }
}
