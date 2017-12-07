﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Playfair_chiffreur_déchiffreur
{
    class Program
    {
        static string strAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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
                char cPartir = Console.ReadKey().KeyChar;
                if (cPartir == 'o')
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
            Console.WriteLine("Veuillez me donner votre mot clef (en majuscule)");
            string strMotClef = Console.ReadLine();
            Console.WriteLine("Veuillez me donner une lettre non utilisé (en majuscule)");
            char cLettre = Console.ReadKey().KeyChar;
            string strfinal = "";
            for (int i = 0; i <= strMotClef.Length;)
            {
                if (!(strMotClef.Contains(cLettre)))
                {
                    strfinal += cLettre + strMotClef;
                }
            }
            Console.WriteLine("\n {0}",strfinal);
            
        }
        static void déchiffrer()
        {
            Console.WriteLine("\n Déchiffrer");
            Console.WriteLine("Veuillez me donner votre mot clef");
            string strMotClef = Console.ReadLine();
            Console.WriteLine("Veuillez me donner une lettre non utilisé");
            char cLettre = Console.ReadKey().KeyChar;

        }
    }
}