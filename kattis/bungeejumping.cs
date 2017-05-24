using System;

public class Program
{
    public static void Main()
    {
        string vrstica;
        while ((vrstica = Console.ReadLine()) != "0 0 0 0")
        {
            string[] sez = vrstica.Split();
            //podatki so: k - moč vrvi, l - dolžina (neraztegnjene) vrvi
            //s - višina mostu in w - teža Jamesa Bonda
            double k = double.Parse(sez[0]);
            double l = double.Parse(sez[1]);
            double s = double.Parse(sez[2]);
            double w = double.Parse(sez[3]);
            //gravitacijski pospesek
            double g = 9.81;
            //kvadrat končne hitrosti (izražena iz enačb o ohranitvi energije)
            double v_vk = ((2 * w * g * s) - k * ((s - l) * (s - l))) / w;
            //če vrv daljša od mostu samo pogledamo kaj se zgodi pri prostem padu
            if (s <= l)
            {
                //končna hitrost pri prostem padu
                double koncna = (double)Math.Sqrt(2 * g * s);
                if (koncna > 10) Console.WriteLine("Killed by the impact.");
                else Console.WriteLine("James Bond survives.");
            }
            //drugace upostevamo, da se energija ohranja 
            else if (v_vk < 0) Console.WriteLine("Stuck in the air.");
            //če končna hitrost večja od 10 James Bond umre
            else if ((double)Math.Sqrt(v_vk) > 10) Console.WriteLine("Killed by the impact.");
            else Console.WriteLine("James Bond survives.");
        }
    }
}
