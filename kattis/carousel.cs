using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // s prvo preberemo začetne podatke posameznega primera
        string prva;
        while ((prva = Console.ReadLine()) != "0 0")
        {
            string[] split = prva.Split();
            //n je število podatkov, ki sledijo, m pa max število vstopnic, ki jih je pripravljen kupiti
            int n = int.Parse(split[0]);
            int m = int.Parse(split[1]);
            //v dveh seznamih a in b si shranimo podatke tega primera
            //v a bodo podatki koliko vstopnic ponuja, v b pa cena vstopnice
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            for (int i = 0; i < n; i++)
            {
                string vrst = Console.ReadLine();
                string[] podatki = vrst.Split();
                //ponudb, kjer ponujajo preveč vstopnic ne rabimo
                if (int.Parse(podatki[0]) <= m)
                {
                    a.Add(int.Parse(podatki[0]));
                    b.Add(int.Parse(podatki[1]));
                }
            }
            //da ni ugodnih ponudb se lahko zgodi le, če so vsi ponujali preveliko število vstopnic- 
            //takrat sta seznama a in b prazna zaradi prejšnjega pogoja
            if (a.Count == 0)
            {
                Console.WriteLine("No suitable tickets offered");
                //continue preskoči trenutno iteracijo - ne rabimo naprej računati
                continue;
            }
            //za najboljšo ponudbo izberemo prvo v seznamih in to primerjamo z ostalimi
            int naj_indeks = 0;
            //primerjali bomo cene na eno vstopnico
            double naj_cena = (double)b[0] / (double)a[0];
            for (int k = 1; k < a.Count; k++)
            {
                double koliko = (double)b[k] / (double)a[k];
                if (koliko < naj_cena)
                {
                    naj_indeks = k;
                    naj_cena = koliko;
                }
                //če je več najugodnejših ponudb izberemo tisto, ki ponuja več vstopnic
                if (koliko == naj_cena)
                {
                    if (a[k] > a[naj_indeks]) naj_indeks = k;
                }
            }
            Console.WriteLine("Buy " + a[naj_indeks] + " tickets for $" + b[naj_indeks]);
        }
    }
}
