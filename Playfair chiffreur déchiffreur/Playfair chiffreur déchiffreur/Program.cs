﻿/*
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
                    istartIndex = i - 1;                                        //Diviser mes lettres en 2
                    ilength = 2;
                    strsubstring = strMotChiffrer.Substring(istartIndex, ilength);
                }
            }
            int numCase = 0;
            int iX = TrouverX(numCase);
            int iY = TrouverY(numCase);
            numCase = TrouverNumeroCase(iX,iY);
            strfinal = new string(cfinal);
            int iPositonXDeLaCase1 = iX; // de la lettre numéro 1
            int iPositonYDeLaCase1 = iY; // de la lettre numéro 1
            int iPositonXDeLaCase2 = iX;// de la lettre numéro 2
            int iPositonYDeLaCase2 = iY; // de la lettre numéro 2


            if(iPositonYDeLaCase1 / 5 == iPositonYDeLaCase2 / 5) {
                if(iPositonXDeLaCase1 == 4){
                    int iXPosition1 = iPositonXDeLaCase1 - 4;
                    int iYPosition1 = iPositonYDeLaCase1;
               }
                if(iPositonXDeLaCase2 == 4){
                    int iXPosition2 = iPositonXDeLaCase2 - 4;
                    int iYPosition2 = iPositonYDeLaCase2;
               }
            else{
                    int iXPosition1 = iPositonXDeLaCase1 + 1;
                    int iXPosition2 = iPositonXDeLaCase2 + 1;
                    int iYPosition1 = iPositonYDeLaCase2;
                    int iYPosition2 = iPositonYDeLaCase2;
    }
            }

                if(iPositonXDeLaCase1 % 5 == iPositonXDeLaCase2 % 5) {
                if(iPositonYDeLaCase1 == 4){
                    int iYPosition1 = iPositonYDeLaCase1 - 4;
                    int iXPosition1 = iPositonXDeLaCase1;
               }
                if(iPositonYDeLaCase2 == 4){
                    int iYPosition2 = iPositonYDeLaCase2 - 4;
                    int iXPosition2 = iPositonXDeLaCase2;
               }
                    else{
                    int iXPosition1 = iPositonXDeLaCase1;
                    int iXPosition2 = iPositonXDeLaCase1;
                    int iYPosition1 = iPositonYDeLaCase1 + 1;
                    int iYPosition2 = iPositonYDeLaCase1 + 1;
    }
            }

                    else{
                int iXPosition1 = iPositonXDeLaCase2;
                int iXPosition2 = iPositonXDeLaCase1;
                int iYPosition1 = iPositonYDeLaCase1;
                int iYPosition2 = iPositonYDeLaCase2;
}
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

        static int TrouverX(int numCase)
        {
            return numCase % 5;
        }
        static int TrouverY(int numCase)
        {
            return numCase / 5;
        }
        static int TrouverNumeroCase(int x, int y)
        {
            return x % 5 & y / 5;
        }
    }
}

/*TESTS
A b c d e
f g h i j
k l M n o
p q r s t
u v w x y

si on prends 'a' et 'm'
position de la case 0 = 0 + 5 * 0
position de la case 12 = 2 + 5 * 2

iPositonXDeLaCase1=trouverX // de la lettre numéro 1
iPositonYDeLaCase1=trouverY // de la lettre numéro 1
iPositonXDeLaCase2=trouverX // de la lettre numéro 2
iPositonXDeLaCase2=trouverY // de la lettre numéro 2


    1)
si (iPositonYDeLaCase1 / 5 = iPositonYDeLaCase2 / 5) {
si (iPositonXDeLaCase1 = 4){
iXPosition1 = iPositonXDeLaCase1 - 4
iYPosition1 = iPositonYDeLaCase1
}
si (iPositonXDeLaCase2 = 4){
iXPosition2 = iPositonXDeLaCase2 - 4
iYPosition2 = iPositonYDeLaCase2
}
else{
iXPosition1= iPositonXDeLaCase1 + 1
iXPosition2= iPositonXDeLaCase2 + 1
iYPosition1=iPositonYDeLaCase2
iYPosition2=iPositonYDeLaCase2
    }
}

    2)
si (iPositonXDeLaCase1 % 5 = iPositonXDeLaCase2 % 5) {
si (iPositonYDeLaCase1 = 4){
iYPosition1 = iPositonYDeLaCase1 - 4
iXPosition1 = iPositonXDeLaCase1
}
si (iPositonYDeLaCase2 = 4){
iYPosition2 = iPositonYDeLaCase2 - 4
iXPosition2 = iPositonXDeLaCase2
}
else{
iXPosition1= iPositonXDeLaCase1
iXPosition2= iPositonXDeLaCase1
iYPosition1=iPositonYDeLaCase1 + 1
iYPosition2=iPositonYDeLaCase1 + 1
    }
}

    3)
else{
iXPosition1=iPositonXDeLaCase2
iXPosition2=iPositonXDeLaCase1
iYPosition1=iPositonYDeLaCase1
iYPosition2=iPositonYDeLaCase2
}

*/
