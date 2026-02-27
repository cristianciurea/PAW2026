using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2PAW_1045
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicul v1 = new Vehicul();
            Vehicul v2 = new Vehicul("Dacia", 14999.99f, 1.2);
            Vehicul v3 = new Vehicul(v2);
            Vehicul v4 = (Vehicul)v2.Clone();
            v2.Pret = 16000f;
            Console.WriteLine(v4);

            Masina m1 = new Masina("Toyota", 24990.99f, 1.6, "gri", true);
            Motocicleta moto1 = new Motocicleta("Yamaha", 9999.90f, 0.6, "HIBRID", true);

            List<Vehicul> listaVehicule = new List<Vehicul>();
            listaVehicule.Add(v1);
            listaVehicule.Add(v2);
            listaVehicule.Add(v3);
            listaVehicule.Add(v4);
            listaVehicule.Add(m1);
            listaVehicule.Add(moto1);
            listaVehicule.Sort();
            foreach (Vehicul v in listaVehicule)
                Console.WriteLine(v);

            ParcAuto p1 = new ParcAuto();
            p1.Denumire = "Parc auto 1";
            p1.Lista = listaVehicule;
            Console.WriteLine(p1);

            ParcAuto p2 = (ParcAuto)p1.Clone();
            p2.Denumire = "Parc auto 2";
            foreach (Vehicul v in p2.Lista)
                v.Marca += " clona ";

            Masina m2 = new Masina("Mercedes", 80000f, 3.5, "negru", true);
            p2 = p2 + m2;
            p1 = m2 + p1;
            p2 += m2;

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.WriteLine("Pretul mediu al vehiculelor din p2 este {0}", (float)p2);

            p2[2] = v3;
            Console.WriteLine(p2[1]);

            Console.WriteLine(p1.calculeazaPretMediu());

            p2 = p1++;
            p2 = ++p1;

            Console.WriteLine(p2);
        }
    }
}
