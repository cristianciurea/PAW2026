using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2PAW_1047
{
    class Zoo: ICloneable
    {
        private string denumire;
        private List<Animal> lista;

        public Zoo()
        {
            denumire = "nespecificat";
            lista = new List<Animal>();
        }

        public string Denumire { get => denumire; set => denumire = value; }
        internal List<Animal> Lista { get => lista; set => lista = value; }

        public object Clone()
        {
            Zoo clona = (Zoo)this.MemberwiseClone();
            List<Animal> listaClona = new List<Animal>();
            foreach (Animal a in lista)
                listaClona.Add((Animal)a.Clone());
            clona.lista = listaClona;
            return clona;
        }

        public override string ToString()
        {
            string rezultat = "Zoo " + denumire + " are urmatoarele animale: " + Environment.NewLine;
            foreach (Animal a in lista)
                rezultat += a.ToString() + Environment.NewLine;
            return rezultat;
        }

        public static Zoo operator+(Zoo z, Animal a)
        {
            z.lista.Add(a);
            return z;
        }

        public static Zoo operator+(Animal a, Zoo z)
        {
            return z + a;
        }

        public static Zoo operator++(Zoo z)
        {
            foreach (Animal a in z.lista)
                a.Varsta += 1;
            return z;
        }

        public static explicit operator float(Zoo z)
        {
            float suma = 0.0f;
            foreach (Animal a in z.lista)
                suma += a.Greutate;
            return suma / z.lista.Count;
        }

        public Animal this[int index]
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
    }
}
