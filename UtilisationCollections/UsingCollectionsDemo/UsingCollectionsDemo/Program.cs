using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static SortedList listEtudiants = new SortedList();

        static void Main(string[] args)
        {
            bool continuer = true;

            while (continuer)
            {
                try
                {
                    Console.WriteLine("\nMenu :");
                    Console.WriteLine("1 - Ajouter un étudiant");
                    Console.WriteLine("2 - Afficher les informations de chaque étudiant");
                    Console.WriteLine("3 - Afficher la moyenne générale de la classe");
                    Console.WriteLine("9 - Quitter le programme");
                    Console.Write("Votre choix : ");
                    string choix = Console.ReadLine();

                    switch (choix)
                    {
                        case "1":
                            AjouterEtudiant();
                            break;
                        case "2":
                            AfficherEtudiants();
                            break;
                        case "3":
                            AfficherMoyenneClasse();
                            break;
                        case "9":
                            continuer = false;
                            Console.WriteLine("Programme terminé.");
                            break;
                        default:
                            Console.WriteLine("Choix invalide, veuillez entrer un nombre entre 1 et 4.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Une erreur inattendue s'est produite : {ex.Message}");
                }
            }
        }

        // Ajouter un étudiant dans la collection
        static void AjouterEtudiant()
        {
            try
            {
                Console.WriteLine("\nAjout d'un nouvel étudiant :");

                string nom;
                do
                {
                    Console.Write("Entrez le nom de l'étudiant : ");
                    nom = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nom))
                    {
                        Console.WriteLine("Le nom ne peut pas être vide ou contenir uniquement des espaces. Veuillez réessayer.");
                    }
                } while (string.IsNullOrWhiteSpace(nom));

                double noteCC = LireNote("Entrez la note de contrôle continu : ");
                double noteDevoir = LireNote("Entrez la note de devoir : ");

                if (!lstEtudiants.ContainsKey(nom))
                {
                    listEtudiants.Add(nom, new Etudiant
                    {
                        Nom = nom,
                        NoteCC = noteCC,
                        NoteDevoir = noteDevoir
                    });
                    Console.WriteLine("Étudiant ajouté avec succès !");
                }
                else
                {
                    Console.WriteLine("Un étudiant avec ce nom existe déjà !");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout de l'étudiant : {ex.Message}");
            }
        }

        // Afficher les informations de chaque étudiant
        static void AfficherEtudiants()
        {
            try
            {
                if (listEtudiants.Count == 0)
                {
                    Console.WriteLine("Aucun étudiant enregistré.");
                    return;
                }

                Console.WriteLine("\nListe des étudiants :");
                foreach (DictionaryEntry entry in lstEtudiants)
                {
                    Etudiant etudiant = (Etudiant)entry.Value;
                    Console.WriteLine($"Nom : {etudiant.Nom}, Note CC : {etudiant.NoteCC}, Note Devoir : {etudiant.NoteDevoir}, Moyenne : {etudiant.Moyenne:F2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'affichage des étudiants : {ex.Message}");
            }
        }

        // Afficher la moyenne générale de la classe
        static void AfficherMoyenneClasse()
        {
            try
            {
                if (listEtudiants.Count == 0)
                {
                    Console.WriteLine("Aucun étudiant enregistré.");
                    return;
                }

                double sommeMoyennes = 0;
                foreach (DictionaryEntry entry in listEtudiants)
                {
                    Etudiant etudiant = (Etudiant)entry.Value;
                    sommeMoyennes += etudiant.Moyenne;
                }

                double moyenneClasse = sommeMoyennes / lstEtudiants.Count;
                Console.WriteLine($"\nMoyenne générale de la classe : {moyenneClasse:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du calcul de la moyenne de la classe : {ex.Message}");
            }
        }

        // Méthode pour lire une note valide
        static double LireNote(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out double note) && note >= 0 && note <= 20)
                    {
                        return note;
                    }
                    else
                    {
                        throw new ArgumentException("Veuillez entrer une note valide entre 0 et 20.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur inattendue lors de la saisie de la note : {ex.Message}");
                }
            }
        }
    }
}
