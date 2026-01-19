// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/liste_povezanosti
using System;
using System.Collections.Generic;
class R3_T04_Graf_01_Predstavljanje_Niz_Listi
{
    static void Main()
    {
        // Korak 1: ULAZ
        int C = int.Parse(Console.ReadLine());                          // C: Broj covorova (korisnika)
        int V = int.Parse(Console.ReadLine());                          // V: Broj veza
        var G = new List<int>[C];                                       // G: Niz cvorova, svaki cvor ima listu
        for (int c = 0; c < C; c++) G[c] = new List<int>();             // G: Niz cvorova, svaki cvor ima praznu listu
        for (int v = 0; v < V; v++)                                     // za svaku vezu (par cvorova (OD,DO))
        {
            string[] sOD_DO = Console.ReadLine().Split();               // Ucitava se jedna veza, par cvorova OD DO
            int cvor_OD = int.Parse(sOD_DO[0]);                         // Cvor_OD: Mora  biti 0 <= Cvor_OD < C
            int cvor_DO = int.Parse(sOD_DO[1]);                         // Cvor_DO: Treba biti 0 <= Cvor_DO < C
            if (cvor_OD >= 0 && cvor_OD < C) G[cvor_OD].Add(cvor_DO);   // Dodajemo vezu za Cvor_OD do Cvor_DO
            if (cvor_DO >= 0 && cvor_DO < C) G[cvor_DO].Add(cvor_OD);   // Dodajemo vezu za Cvor_DO do Cvor_OD (jer je NEUSMERENI graf)
        }

        // Korak 2: IZLAZ
        for (int c = 0; c < C; c++)
        {
            G[c].Sort();                                                // Sortiramo listu veza za cvor c
            foreach (int c_sused in G[c]) Console.Write(c_sused + " "); // Za svaki susedni cvor tekuceg cvora c
            Console.WriteLine();
        }
    }
}
