/*
 Projet: Playfair_chiffreur_déchiffreur
 Auteur: Marcelo Andrade
 Date: 08.12.17
 Classe: 1M4I1C
 Version: Microsoft Visual studio pro 2017
 OS: Win 10 Pro
 But: Chiffrer Déchiffrer
*/
using System;
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
                Console.Clear();
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
            Console.WriteLine("\n Chiffrer");                                                   //Demande utilisateur des choses 
            Console.WriteLine("Inserez ce que vous voulez chiffrer svp !(en majuscule)");
            string strMotChiffrer = Console.ReadLine();
           
            for (int i = 0; i < strMotChiffrer.Length - 1; i++)
            {
                Char cDivise = strMotChiffrer[i];
                if (strMotChiffrer[i] == strMotChiffrer[i + 1])
                {
                    strMotChiffrer = strMotChiffrer.Insert(i + 1, "X");
                }
            }
            if(strMotChiffrer.Length % 2 == 1)
            {
                strMotChiffrer += "X";
            }
            Console.WriteLine(strMotChiffrer);

            Console.WriteLine("Veuillez me donner votre mot clef (en majuscule)");             //Demande utilisateur des choses 
            string strMotClef = Console.ReadLine();                                           //Demande utilisateur des choses 
            Console.WriteLine("Veuillez me donner une lettre non utilisé (en majuscule)");   //Demande utilisateur des choses 
            char cLettre = Console.ReadKey().KeyChar;                                       //Demande utilisateur des choses 
            string strfinal = "";
            if (strMotClef.Contains(cLettre))                                            //si le mot clef ne contient pas clettre il l'ajoute
            {
                Console.WriteLine("Erreur désolé Votre mot clef contient la lettre non utilisé");                          //Verfifie si la lettre non utilisé est dans le mot
            }
            else
            {
                for (int i = 0; i < strMotClef.Length; i++)                                   //pour i à longueur strmotclef faire:              
                {
                    if (!(strfinal.Contains(cLettre)))
                    {
                        strfinal += cLettre;
                    }
                    if (!(strfinal.Contains(strMotClef[i])))                              //si strfianl est ne contient pas strmotclef longueur 
                    {
                        
                        strfinal += strMotClef[i];                               // ajouter à strFinal strFinal et strMotClef jusqu'à longeueur de i 
                    }
                    
                }
                for (int i = 0; i < strfinal.Length; i++)
                {
                    while (!(strfinal.Contains(strAlphabet[i])))
                    {
                        strfinal = strfinal+ strAlphabet[i];
                    }
                }
            }
            Console.Clear();

            Console.WriteLine("l'alphabet est le suivant : {0}",strfinal);
            Console.WriteLine("le mot à chiffrer est le suivant : {0}", strMotChiffrer);
            Console.ReadKey();
            int ilength;
            int istartIndex;
            for (int i = 0; i < strMotChiffrer.Length; i++)
            {
                if (!(i % 2 == 0))
                {
                    istartIndex = i -1;
                    ilength = 2;
                    String substring = strMotChiffrer.Substring(istartIndex, ilength);
                    Console.WriteLine(substring);
                   
                }
            }
            Console.ReadKey();


    }
        static void déchiffrer()
        {
            Console.Clear();
            String value = "This is a string.";
            int startIndex = 0;
            int length = 2;
            String substring = value.Substring(startIndex, length);
            Console.WriteLine(substring);

            Console.WriteLine("\n Déchiffrer");
            Console.WriteLine("Veuillez me donner votre mot clef");
            string strMotClef = Console.ReadLine();
            Console.WriteLine("Veuillez me donner une lettre non utilisé");
            char cLettre = Console.ReadKey().KeyChar;

        }
    }
}