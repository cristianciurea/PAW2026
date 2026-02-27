using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2PAW_1045
{
    class Vehicul: ICloneable, IComparable
    {
        private string marca;
        private float pret;
        private double capacitateCilindrica;

        public string Marca { get => marca; set => marca = value; }
        public float Pret { get => pret; set => pret = value; }
        public double CapacitateCilindrica { get => capacitateCilindrica; set => capacitateCilindrica = value; }

        public Vehicul()
        {
            marca = "nespecificat";
            pret = 0.0f;
            capacitateCilindrica = 0.0;
        }

        public Vehicul(string m, float p, double cc)
        {
            this.marca = m;
            this.pret = p;
            this.capacitateCilindrica = cc;
        }

        public Vehicul(Vehicul v)
        {
            this.marca = v.marca;
            this.pret = v.pret;
            this.capacitateCilindrica = v.capacitateCilindrica;
        }

        public override string ToString()
        {
            return "Vehiculul " + marca + " cu capacitatea cilindrica " +
                capacitateCilindrica + " are pretul " + pret;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            Vehicul v = (Vehicul)obj;
            if (this.pret > v.pret)
                return -1;
            else
                if (this.pret < v.pret)
                return 1;
            else
                return string.Compare(this.marca, v.marca);
        }
    }
}
