using System;
using System.Collections.Generic;

namespace ConversionHexadecimale
{
    class Program
    {
        static void Main(string[] args)
        {
            // Liste pour stocker les conversions (entier -> hexadécimal)
            List<(int entier, string hex)> conversions = new List<(int, string)>();
            bool continuer = true;

            Console.WriteLine("Programme de conversion d'entiers en hexadécimal.");

            while (continuer)
            {
                try
                {
                    // Demander à l'utilisateur d'entrer un entier
                    Console.Write("Entrez un entier à convertir en hexadécimal : ");
                    string input = Console.ReadLine();

                    // Vérification de la validité de l'entrée
                    if (int.TryParse(input, out int entier))
                    {
                        // Effectuer la conversion
                        string hexadécimal = ConvertirEnHex(entier);
                        Console.WriteLine($"L'entier {entier} converti en hexadécimal est : {hexadécimal}");

                        // Stocker la conversion
                        conversions.Add((entier, hexadécimal));
                    }
                    else
                    {
                        Console.WriteLine("Erreur : veuillez entrer un entier valide.");
                        continue;
                    }

                    // Demander si l'utilisateur souhaite continuer
                    Console.Write("Voulez-vous convertir un autre entier ? (o/n) : ");
                    string reponse = Console.ReadLine().ToLower();

                    if (reponse == "n")
                    {
                        continuer = false;
                        Console.WriteLine("\nFin de la conversion.");
                    }
                    else if (reponse != "o")
                    {
                        Console.WriteLine("Réponse invalide. Arrêt du programme.");
                        continuer = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Une erreur inattendue s'est produite : {ex.Message}");
                }
            }

            // Afficher toutes les conversions effectuées
            Console.WriteLine("\nListe des conversions effectuées :");
            foreach (var conversion in conversions)
            {
                Console.WriteLine($"{conversion.entier} -> {conversion.hex}");
            }

            Console.WriteLine("\nMerci d'avoir utilisé ce programme !");
        }

        // Fonction pour convertir un entier en une chaîne hexadécimale
        static string ConvertirEnHex(int entier)
        {
            if (entier == 0)
                return "0";

            string hex = "";
            string hexChars = "0123456789ABCDEF";

            // Répéter jusqu'à ce que l'entier devienne 0
            while (entier > 0)
            {
                int reste = entier % 16; // Obtenir le reste
                hex = hexChars[reste] + hex; // Ajouter le caractère correspondant à la chaîne
                entier /= 16; // Réduire l'entier en divisant par 16
            }

            return hex;
        }
    }
}
