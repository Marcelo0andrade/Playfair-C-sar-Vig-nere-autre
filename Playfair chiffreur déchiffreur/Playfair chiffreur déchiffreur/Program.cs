using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Playfair_chiffreur_déchiffreur
{
    class Program
    {
        string stralpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string strMotclef;
        string strfinal;
        char clettre;
        const int istart = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n Saisissez: \n ( c ) pour chiffrer \n ( d ) pour déchiffrer");
                char csaisie = Console.ReadKey().KeyChar;
                switch (csaisie)
                {
                    case 'c':
                        chiffrer();
                        break;
                    case 'd':
                        déchiffrer();
                        break;
                }
                Console.WriteLine("\n Voulez vous quitter l'application ? ( o / n )");
                char cpartir = Console.ReadKey().KeyChar;
                if (cpartir == 'o')
                {
                    Console.WriteLine("\nMerci de la visite");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }

            } while (istart == 0);
        }

        static void chiffrer()
        {
            Console.WriteLine("\n Chiffrer");

        }
        static void déchiffrer()
        {
            Console.WriteLine("\n Déchiffrer");
        }
    }
}