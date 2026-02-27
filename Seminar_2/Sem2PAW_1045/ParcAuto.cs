using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2PAW_1045
{
    class ParcAuto: ICloneable, IMedia
    {
        private string denumire;
        private List<Vehicul> lista;

        public ParcAuto()
        {
            denumire = "Bucuresti";
            lista = new List<Vehicul>();
        }

        public string Denumire { get => denumire; set => denumire = value; }
        internal List<Vehicul> Lista { get => lista; set => lista = value; }

        public object Clone()
        {
            ParcAuto clona = (ParcAuto)this.MemberwiseClone();
            List<Vehicul> listaClona = new List<Vehicul>();
            foreach (Vehicul v in lista)
                listaClona.Add((Vehicul)v.Clone());
            clona.lista = listaClona;
            return clona;
        }

        public override string ToString()
        {
            string rezultat = "Parcul auto " + denumire + " are urmatoarele vehicule " +
                Environment.NewLine;
            foreach (Vehicul v in lista)
                rezultat += v.ToString() + Environment.NewLine;
            return rezultat;
        }

        public float calculeazaPretMediu()
        {
            return (float)this;
        }

        public static ParcAuto operator+(ParcAuto p, Vehicul v)
        {
            p.lista.Add(v);
            return p;
        }

        public static ParcAuto operator+(Vehicul v, ParcAuto p)
        {
            return p + v;
        }

        public static explicit operator float(ParcAuto p)
        {
            float suma = 0.0f;
            foreach (Vehicul v in p.lista)
                suma += v.Pret;
            return suma / p.lista.Count;
        }

        public Vehicul this[int index]
        {
            get
            {
                if (lista != null && index >= 0 && index < lista.Count)
                    return lista[index];
                else
                    return null;
            }
            set
            {
                if (lista != null && index >= 0 && index < lista.Count && value != null)
                    lista[index] = value;
            }
        }

        public static ParcAuto operator++(ParcAuto p)
        {
            foreach (Vehicul v in p.lista)
                v.Pret += 1;
            return p;
        }
    }
}
