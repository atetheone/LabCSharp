namespace TrouverNombre;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans le jeu Trouver le nombre!");
        Console.WriteLine("Vous devez deviner un nombre aléatoire entre deux bornes.");
        Console.WriteLine("Vous avez autant de tentatives que de nombres possibles.");
        Console.WriteLine("Bonne chance!");
        Console.WriteLine("---------------------------");
        
        Console.WriteLine("Entrez la borne inférieure : ");
        int min = int.Parse(Console.ReadLine());
        Console.WriteLine("Entrez la borne supérieure : ");
        int max = int.Parse(Console.ReadLine());

        // Générer aléatoirement le nombre à trouver
        Random rnd = new Random();
        int nombreADeviner = rnd.Next(min, max + 1);

        // Liste pour stocker les choix déjà faits
        List<int> choixFaits = new List<int>();
        int nbTentatives = 0;
        bool gagne = false;


        while (!gagne)
        {
            try
            {
                // Étape 1: Demander le choix
                Console.WriteLine($"\nChoisissez un nombre entre {min} et {max}:");
                string input = Console.ReadLine();
                
                // Vérifier si l'entrée est un nombre valide
                if (!int.TryParse(input, out int choix))
                {
                    throw new Exception($"Saisissez un nombre compris entre [{min}, {max}].");
                }

                // Vérifier si le nombre est dans les bornes
                if (choix < min || choix > max)
                {
                    throw new Exception($"Saisissez un nombre compris entre [{min}, {max}].");
                }

                // Ajouter le choix à la liste
                choixFaits.Add(choix);
                nbTentatives++;

                // Vérifier si le joueur a gagné
                if (choix == nombreADeviner)
                {
                    Console.WriteLine("Vous avez gagné!");
                    gagne = true;
                }
                else
                {
                    Console.WriteLine("Vous avez perdu!");
                    
                    // Afficher les choix déjà faits
                    Console.WriteLine("\nVos choix précédents:");
                    foreach (int nb in choixFaits)
                    {
                        Console.Write($"{nb} ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur: {e.Message}");
                continue;
            }
        }

        // Calculer et afficher la note
        int nbPossibilites = max - min + 1;
        double note = (double)nbPossibilites / nbTentatives;
        Console.WriteLine($"\nVotre note: {note:F2} ({nbPossibilites} possibilités / {nbTentatives} tentatives)");
    }
}