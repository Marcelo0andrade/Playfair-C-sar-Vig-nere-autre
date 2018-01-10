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
        static string strAlphabet = @"♥❥ღ ⋆!#$%&'()*+,-./0123456789:;<=>?'@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~€‚ƒ„…†‡ˆ‰Š‹ŒŽ‘’“”•–—˜™š›œžŸ¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
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
            Console.WriteLine("Inserez ce que vous voulez chiffrer (veuillez écrire tout collé svp !)");
            string strMotChiffrer = Console.ReadLine();

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
            Console.WriteLine("Veuillez me donner votre mot clef ");             //Demande utilisateur des choses 
            string strMotClef = Console.ReadLine();                                           //Demande utilisateur des choses 
            Console.WriteLine("Veuillez me donner une lettre non utilisé");   //Demande utilisateur des choses 
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
            strfinal = strfinal.Substring(1); // Retirer la lettre interdite
            string strChiffre = "";
            for (int i = 0; i < strMotChiffrer.Length; i += 2)
            {
                char cLettre1 = strMotChiffrer[i];
                char cLettre2 = strMotChiffrer[i + 1];

                int numCase1 = strfinal.IndexOf(cLettre1);
                int numCase2 = strfinal.IndexOf(cLettre2);
                int iX1 = TrouverX(numCase1);
                int iY1 = TrouverY(numCase1);
                int iX2 = TrouverX(numCase2);
                int iY2 = TrouverY(numCase2);

                int numCaseChiffree1;
                int numCaseChiffree2;
                if (iX1 == iX2)
                {
                    numCaseChiffree1 = TrouverNumeroCase(iX1, (iY1 + 1) % 15);
                    numCaseChiffree2 = TrouverNumeroCase(iX2, (iY2 + 1) % 15);
                }
                else if (iY1 == iY2)
                {
                    numCaseChiffree1 = TrouverNumeroCase((iX1 + 1) % 15, iY1);
                    numCaseChiffree2 = TrouverNumeroCase((iX2 + 1) % 15, iY2);
                }
                else
                {
                    numCaseChiffree1 = TrouverNumeroCase(iX2, iY1);
                    numCaseChiffree2 = TrouverNumeroCase(iX1, iY2);

                }
                char cLettreChiffree1 = strfinal[numCaseChiffree1];
                char cLettreChiffree2 = strfinal[numCaseChiffree2];
                strChiffre += "" + cLettreChiffree1 + cLettreChiffree2;
            
                
            }
            Console.Clear();
            Console.WriteLine(@"Votre mot clef est : {0}", strMotClef);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(@"Votre Lettre non utilisé est : {0}", cLettre);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(@"Votre mot chiffré est : {0}", strChiffre);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        }
        static void déchiffrer()
        {
            Console.WriteLine("\n Déchiffrer");                                                   //Demande utilisateur des choses 
            Console.WriteLine("Inserez ce que vous voulez Déchiffrer (en majuscule et veuillez écrire tout collé svp !)");
            string strMotChiffrer = Console.ReadLine();

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
            strfinal = strfinal.Substring(1); // Retirer la lettre interdite
            string strChiffre = "";
            for (int i = 0; i < strMotChiffrer.Length; i += 2)
            {
                char cLettre1 = strMotChiffrer[i];
                char cLettre2 = strMotChiffrer[i + 1];

                int numCase1 = strfinal.IndexOf(cLettre1);
                int numCase2 = strfinal.IndexOf(cLettre2);
                int iX1 = TrouverX(numCase1);
                int iY1 = TrouverY(numCase1);
                int iX2 = TrouverX(numCase2);
                int iY2 = TrouverY(numCase2);

                int numCaseChiffree1;
                int numCaseChiffree2;                                                               
                if (iX1 == iX2)
                {
                    numCaseChiffree1 = TrouverNumeroCase(iX1, (iY1 + 14) % 15);
                    numCaseChiffree2 = TrouverNumeroCase(iX2, (iY2 + 14) % 15);
                }
                else if (iY1 == iY2)
                {
                    numCaseChiffree1 = TrouverNumeroCase((iX1 + 14) % 15, iY1);
                    numCaseChiffree2 = TrouverNumeroCase((iX2 + 14) % 15, iY2);
                }
                else
                {
                    numCaseChiffree1 = TrouverNumeroCase(iX2, iY1);
                    numCaseChiffree2 = TrouverNumeroCase(iX1, iY2);

                }
                char cLettreChiffree1 = strfinal[numCaseChiffree1];
                char cLettreChiffree2 = strfinal[numCaseChiffree2];
                strChiffre += "" + cLettreChiffree1 + cLettreChiffree2;


            }
            Console.Clear();
            Console.WriteLine("Votre mot clef est : {0}", strMotClef);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("Votre Lettre non utilisé est : {0}", cLettre);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("Votre mot déchiffré est : {0}",strChiffre);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
        }
        static int TrouverX(int numCase)
        {
            return numCase % 15;
        }
        static int TrouverY(int numCase)
        {
            return numCase / 15;
        }
        static int TrouverNumeroCase(int x, int y)
        {
            return x + 15 * y;
        }
    }
}