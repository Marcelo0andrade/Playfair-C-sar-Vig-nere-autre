using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair_chiffreur_déchiffreur
{
    class Program
    {
        string stralpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string strMotclef;
        string strfinal;
        char clettre;
        int istart = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Saisissez: \n ( 1 ) pour chiffrer \n ( 2 ) pour déchiffrer");
                string strsaisie = Console.ReadLine();
                int ichiffreroupas = Convert.ToInt32(strsaisie);
                switch (ichiffreroupas)
                {
                    case 1:
                        chiffrer();
                        break;
                    case 2:
                        déchiffrer();
                        break;
                }
                Console.WriteLine("Voulez vous quitter l'application ? (o/n)");
                char cpartir = Console.ReadKey().KeyChar;
                if (cpartir == 'o'){
                    Console.WriteLine("Merci de la visite");
                }
            } while (true);
        }

        static void chiffrer()
        {
            Console.WriteLine("Chiffrer");

        }
        static void déchiffrer()
        {
            Console.WriteLine("Déchiffrer");
        }
    }
}