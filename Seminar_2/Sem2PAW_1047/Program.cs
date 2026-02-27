using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2PAW_1047
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a1 = new Animal();
            Animal a2 = new Animal(5, "Grivei", 4.5f);
            Animal a3 = new Animal(a2);
            Animal a4 = (Animal)a2.Clone();
            a2.Nume = "Azorel";
            a2.Varsta = 3;
            a3.Varsta = 4;
            //Console.WriteLine(a4);

            Tigru t1 = new Tigru(10, "Sherkan", 80, 'M', false);
            Pinguin p1 = new Pinguin(3, "Apolodor", 7.5f, 2, true);

            List<Animal> listaAnimale = new List<Animal>();
            listaAnimale.Add(a1);
            listaAnimale.Add(a2);
            listaAnimale.Add(a3);
            listaAnimale.Add(a4);
            listaAnimale.Add(t1);
            listaAnimale.Add(p1);
            listaAnimale.Sort();
            foreach (Animal a in listaAnimale)
                Console.WriteLine(a);

            Zoo z1 = new Zoo();
            z1.Denumire = "Baneasa";
            z1.Lista = listaAnimale;
            Console.WriteLine(z1);

            Zoo z2 = (Zoo)z1.Clone();
            z2.Denumire = "Targoviste";
            foreach (Animal a in z2.Lista)
                a.Nume += " copie";
            Console.WriteLine(z1);
            Console.WriteLine(z2);

            Pinguin p2 = new Pinguin(6, "Pinguin", 5.9f, 1, true);
            z2 = z2 + p2;
            z1 = p2 + z1;
            z2 += p2;
            z2 = z2++;
            z2 = ++z2;
            Console.WriteLine(z1);
            Console.WriteLine(z2);

            Console.WriteLine("Greutatea medie a animalelor din z2 este {0}", (float)z2);

            z2[1] = p2;
            Console.WriteLine(z2[2]);
        }
    }
}
