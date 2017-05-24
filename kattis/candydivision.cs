using System;

public class Program
{
    public static void Main()
    {
        string vrstica = Console.ReadLine();
        long koliko = long.Parse(vrstica);
        //poiskato moramo vse delitelje števila koliko in jim odšteti 1
        //pokličemo funkcijo, ki že vrne pravilen niz teh števil
        string sezDel = delitelji(koliko);
        Console.WriteLine(sezDel);
    }

    public static string delitelji(long koliko)
    {
        //prejme število in vrne niz deljiteljev tega števila -1
        long i;
        string niz1 = "";
        string niz2 = "";
        //da hitreje poiščemo ta števila, gremo samo do korena(oz. primerjamo s kvadratom i-ja)
        for (i = 1; i * i < koliko; i++)
        {
            //ker števila ne dobivamo po vrsti jih dajemo v dva niza, ki ju na koncu staknemo
            if (koliko % i == 0)
            {
                niz1 += i - 1 + " ";
                niz2 = ((koliko / i) - 1 + " ") + niz2;
            }
        }
        //če je koren števila celo število, ga dodamo posebaj, ker bi ga drugače
        //dobili dvakrat (v niz1 in niz2), če bi v for zanki preverili do <=
        if (i * i == koliko) niz1 += i - 1 + " ";
        string niz = (niz1 + niz2).Trim();
        return niz;
    }
}