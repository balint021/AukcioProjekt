using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AukcioProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Festmeny f = new Festmeny("Asd", "a", "e");
            //f.Licit();
            //f.Licit(10);
            //Console.WriteLine(f.ToString());
            //f.Licit(50);
            //Console.WriteLine(f.ToString());
            //f.Elkelt = true;
            //Console.WriteLine(f.ToString());

            List<Festmeny> lista = new List<Festmeny>();
            Random r = new Random();
            int mertek = 0;

            lista.Add(new Festmeny("Asd", "as", "ad"));
            lista.Add(new Festmeny("Qwe", "qw", "qe"));

            Console.WriteLine("Kérem adja meg hány új festményt akar: ");
            int db = int.Parse(Console.ReadLine());

            for (int i = 0; i < db; i++)
            {
                Console.WriteLine("Cim: ");
                String cim = Console.ReadLine();
                Console.WriteLine("Festo: ");
                String festo = Console.ReadLine();
                Console.WriteLine("stilus: ");
                String stilus = Console.ReadLine();
                lista.Add(new Festmeny(cim, festo, stilus));
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    lista[j].Licit(r.Next(10, 100));
                }
            }

            foreach (var a in lista)
            {
                Console.WriteLine(a.ToString());
            }

            Console.WriteLine("Adja meg hanyadkat akarja modositani: ");
            int valasz = int.Parse(Console.ReadLine());

            while (valasz != 0)
            {
                Console.WriteLine("Milyen mértékkel szeretne licitálni: ");
                mertek = int.Parse(Console.ReadLine());

                lista[valasz-1].Licit(mertek);
                lista[valasz-1].Elkelt = true;


                Console.WriteLine("Adja meg hanyadkat akarja modositani: ");
                valasz = int.Parse(Console.ReadLine());
            }

            foreach (var a in lista)
            {
                Console.WriteLine(a.ToString());
            }

            String s = "";
            int max = lista[0].LegmagasabbLicit;
            Festmeny f = lista[0];

            foreach (var item in lista)
            {
                if (item.LegmagasabbLicit > max)
                {
                    max = item.LegmagasabbLicit;
                    f = item;
                }
                

            }
            
            Console.WriteLine("3.a.: \nFesto: " + f.Festo + " (" + f.Stilus + ")\n"
                + f.Elkelt + "\n"
                + "legmagasabbLicit " + f.LegmagasabbLicit + "$ - "
                + "LegutolsoLicitIdeje " + f.LegutolsoLicitIdeje
                + " (összesen: " + f.LicitekSzama + " db)");



            int asd = 0;
            bool tizLicit = false;
            while (asd < lista.Count && !tizLicit)
            {
                if (lista[asd].LicitekSzama > 10)
                {
                    tizLicit = true;
                }



                asd++;
            }
            Console.WriteLine("3. b.: " + tizLicit);


            int szam = 0;
            foreach (var item in lista)
            {
                if (item.Elkelt == false)
                {
                    szam++;
                }
            }
            Console.WriteLine("3. c.: " + szam);


            lista = lista.OrderByDescending(i => i.LegmagasabbLicit).ToList();

            foreach (var a in lista)
            {
                Console.WriteLine(a.ToString());
            }





            Console.ReadLine();
        }
    }
}
