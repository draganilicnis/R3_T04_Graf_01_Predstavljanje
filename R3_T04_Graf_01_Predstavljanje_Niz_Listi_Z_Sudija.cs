using System;
using System.Collections.Generic;
class R3_T04_Graf_04_Predstavljanje_Lista_Listi
{
    static void Main()
    {
        // Korak 1: ULAZ
        int C = int.Parse(Console.ReadLine()); C++;                     // C: Broj covorova (korisnika). Nakon ucitavanja dodajemo +1, jer je 1 <= cvor <= C
        int V = int.Parse(Console.ReadLine());                          // V: Broj veza
        var G = new List<int>[C];                                       // G: Niz cvorova, svaki cvor ima listu
        for (int c = 0; c < C; c++) G[c] = new List<int>();             // G: Niz cvorova, svaki cvor ima praznu listu
        for (int v = 0; v < V; v++)                                     // za svaku vezu (par cvorova (OD,DO))
        {
            string[] sOD_DO = Console.ReadLine().Split();               // Ucitava se jedna veza, par cvorova OD DO
            int cvor_OD = int.Parse(sOD_DO[0]);                         // Cvor_OD: Mora  biti 0 <= Cvor_OD < C
            int cvor_DO = int.Parse(sOD_DO[1]);                         // Cvor_DO: Treba biti 0 <= Cvor_DO < C
            if (cvor_OD >= 1 && cvor_OD < C) G[cvor_OD].Add(cvor_DO);   // Dodajemo vezu za Cvor_OD do Cvor_DO
            // if (cvor_DO >= 1 && cvor_DO < C) G[cvor_DO].Add(cvor_OD);   // NE Dodajemo vezu za Cvor_DO do Cvor_OD (jer je USMERENI graf)
        }
        // Korak 2: OBRADA: Stepen ulaz i Stepen izlaz
        var ODL = new int[C];    // Koliko svaki cvor ima odlaznih grana
        var DOL = new int[C];    // Koliko svaki cvor ima dolaznih grana
        for (int c = 0; c < C; c++) ODL[c] = G[c].Count;    // Broj odlaznih je jednak broju elemenata te liste
        for (int c = 0; c < C; c++)
        {
            foreach (int cc in G[c]) DOL[cc]++;
        }
        // Korak 3: Provera (zakomentaristi)
        int Cvor_Rezultat_Sudija = -1;
        for (int c = 0; c < C; c++)
        {
            // Console.WriteLine(c + ": " + ODL[c] + " " + DOL[c]);         // Provera (zakomentaristi)
            if (ODL[c] == 0 && DOL[c] == C - 2) Cvor_Rezultat_Sudija = c;   // C - 2, zato sto indeks c krece od 1, a ne od 0 i zato sto ne postoje veze cvora na isti taj cvor
        }
        Console.WriteLine(Cvor_Rezultat_Sudija);
    }
}
