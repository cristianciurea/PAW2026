using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem9PAW_1047
{
    [Serializable]
    class Student
    {
        private int varsta;
        private string nume;
        private float medie;

        public int Varsta { get => varsta; set => varsta = value; }
        public string Nume { get => nume; set => nume = value; }
        public float Medie { get => medie; set => medie = value; }

        public Student(int v, string n, float m)
        {
            varsta = v;
            nume = n;
            medie = m;
        }

        public override string ToString()
        {
            return "Studentul " + nume + " are varsta " + varsta + " si media " + medie;
        }
    }
}
