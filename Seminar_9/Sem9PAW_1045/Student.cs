using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem9PAW_1045
{
    [Serializable]
    class Student
    {
        private int varsta;
        private string nume;
        private float medie;

        public Student(int v, string n, float m)
        {
            varsta = v;
            nume = n;
            medie = m;
        }

        public string Nume { get => nume; set => nume = value; }
        public int Varsta { get => varsta; set => varsta = value; }
        public float Medie { get => medie; set => medie = value; }

        public override string ToString()
        {
            return "Studentul " + nume + " cu varsta " + varsta + " are media " + medie;
        }
    }
}
