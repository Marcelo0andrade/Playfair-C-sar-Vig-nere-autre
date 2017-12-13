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
                Console.WriteLine("\n Saisissez: \n ( C ) pour chiffrer \n ( D ) pour déchiffrer (en majuscule)");
                char csaisie = Console.ReadKey().KeyChar;
                switch (csaisie)
                {
                    case 'c':
                    case 'C':
                        chiffrer();
                        break;
                    case 'D':
                    case 'd':
                        déchiffrer();
                        break;
                }
                Console.WriteLine("\n Voulez vous quitter l'application ? ( O / N ) toujours en majuscule");
                char cPartir = Console.ReadKey().KeyChar;
                if (cPartir == 'O')
                {
                    Console.WriteLine("\nMerci de la visite");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
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
            Console.WriteLine("Inserez ce que vous voulez chiffrer (en majuscule,pas de caratère spéciaux et veuillez écrire tout collé svp !)");
            string strMotChiffrer = Console.ReadLine();
            char[] CNoEspace = {' ', '!', '?', '^', '"', '@', '#', '(',')','´','~','.',','};
            strMotChiffrer = strMotChiffrer.TrimEnd(CNoEspace);
            Console.WriteLine(strMotChiffrer);


            for (int i = 0; i < strMotChiffrer.Length - 1; i++)
            {
                Char cDivise = strMotChiffrer[i];
                if (strMotChiffrer[i] == strMotChiffrer[i + 1])
                {
                    strMotChiffrer = strMotChiffrer.Insert(i + 1, "X");
                }
            }
            if (strMotChiffrer.Length % 2 == 1)
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
                if (!(strfinal.Contains(cLettre)))
                {
                    strfinal += cLettre;
                }
                for (int i = 0; i < strMotClef.Length; i++)                                   //pour i à longueur strmotclef faire:              
                {
                    if (!(strfinal.Contains(strMotClef[i])))                              //si strfianl est ne contient pas strmotclef longueur 
                    {

                        strfinal += strMotClef[i];                               // ajouter à strFinal strFinal et strMotClef jusqu'à longeueur de i 
                    }

                }
                for (int i = 0; i < strAlphabet.Length; i++)
                {
                    if (!(strfinal.Contains(strAlphabet[i])))
                    {
                        strfinal += strAlphabet[i];
                    }
                }
            }
            Console.Clear();

            Console.WriteLine("l'alphabet est le suivant : {0}", strfinal);
            Console.WriteLine("le mot à chiffrer est le suivant : {0}", strMotChiffrer);
            int ilength;
            int istartIndex;
            char[] cfinal = strfinal.ToCharArray(1, 25);
            string strsubstring;
            Console.WriteLine(cfinal);
            for (int i = 0; i < strMotChiffrer.Length; i++)
            {
                if (!(i % 2 == 0))
                {
                    istartIndex = i - 1;
                    ilength = 2;
                    strsubstring = strMotChiffrer.Substring(istartIndex, ilength);
                    Console.WriteLine(strsubstring);
                }
            }
            strfinal = new string(cfinal);
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

        static int trouverX(int numCase)
        {
            return numCase % 5;
        }
        static int trouverY(int numCase)
        {
            return numCase / 5;
        }
        static int trouverNumeroCase(int x, int y)
        {
            return x % 5 & y / 5;
        }
    }
}