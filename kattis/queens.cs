using System;

public class Program
{
    public static void Main()
    {
        //v dim je velikost šahovnice
        int dim = int.Parse(Console.ReadLine());
        int[] x = new int[dim];
        int[] y = new int[dim];
        //v tabelo x dajemo prvo v y pa drugo koordinato kraljice
        for (int i = 0; i < dim; i++)
        {
            string vrstica = Console.ReadLine();
            string[] sez = vrstica.Split();
            x[i] = int.Parse(sez[0]);
            y[i] = int.Parse(sez[1]);
        }
        //v spremenljivki mogoče bo true ali false (se ne napadejo, se napadejo)
        bool mogoce = preveri(dim, x, y);
        if (mogoce) Console.WriteLine("CORRECT");
        else Console.WriteLine("INCORRECT");
    }

    public static bool preveri(int dim, int[] x, int[] y)
        //prejme tabeli koordinat kraljice in velikost šahovnice in vrne
        //false, če se med sabo lahko napadejo in true če se ne morejo
    {
        for (int i = 0; i < (dim - 1); i++)
        {
            //po vrsti preverjamo, če se napadejo z ostalimi desno od njih v tabelah
            for (int j = i + 1; j < dim; j++)
            {
                //pogledamo ali sta v isti vrstici ali stolpcu - se napadeta
                if ((x[i] == x[j]) || (y[i] == y[j])) return false;
                //preverimo še če sta na istih diagonalah - se napadeta
                if (x[i] - y[i] == x[j] - y[j] || x[i] + y[i] == x[j] + y[j]) return false;
            }
        }
        //če vse v redu vrnemo true
        return true;
    }
}
