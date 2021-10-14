using ProjetGestionTaches.Models;
using System;
namespace ProjetGestionTaches
{
    class Program
    {
        static void Main(string[] args)
        {
            GestionTachesContext context = new GestionTachesContext();
            Annuaire AnnuaireUtilisateurs = new Annuaire(context);
            Registre BaseRegistres = new Registre(context);
            GestionnaireTaches GestionnaireTaches = new GestionnaireTaches();

            Utilisateur user;
            ElementRegistre entry;

            user = AnnuaireUtilisateurs.GetUtilisateur(1);
            entry = BaseRegistres.GetElementRegistre(4);
            Tache tache = GestionnaireTaches.AjouterTache(user, entry);

            entry = BaseRegistres.GetElementRegistre(5);
            tache = GestionnaireTaches.AjouterTache(user, entry);

            user = AnnuaireUtilisateurs.GetUtilisateur(2);
            entry = BaseRegistres.GetElementRegistre(5);
            tache = GestionnaireTaches.AjouterTache(user, entry);

            Console.ReadKey();
        }

        static void Mainbisbis(string[] args)
        {
            GestionTachesContext context = new GestionTachesContext();
            Registre registre = new Registre(context);

            /*
            registre.AddElementRegistre("Word", "Traitement de Texte");
            registre.AddElementRegistre("Edge", "Navigateur Web");
            */
            /*
            registre.UpdateElementRegistre(1, "Edgeu", "Navigateureuh");
            registre.UpdateElementRegistre(2, "Word", "Traitemeng de texteu.");
            */
            //registre.RemoveElementRegistre(2);

            foreach (ElementRegistre ER in context.Registre)
            {
                Console.WriteLine(ER);
            }

            Console.WriteLine("Ayé");
            Console.ReadKey();
        }

        static void Mainbis(string[] args)
        {
            GestionTachesContext context = new GestionTachesContext(); Annuaire annuaire = new Annuaire(context);

            String userName, nom, prenom;
            String rep = "";

            do
            {
                Console.Write("Que souhaitez-vous faire (aff pour afficher la liste actuelle, " +
                    "add pour ajouter un utilisateur, " +
                    "maj pour mettre à jour un utilisateur," +
                    "del pour supprimer un utilisateur, stop pour couper le programme) ? ");

                rep = Console.ReadLine();

                switch (rep)
                {
                    case "aff":
                        System.Console.WriteLine("Liste des utilisateurs");

                        foreach (Utilisateur u in context.Annuaire)
                        {
                            System.Console.WriteLine(u.ID + " : " + u.UserName + ", " + u.Nom + ", " + u.Prenom);
                        }
                        break;

                    case "add":
                        Console.WriteLine("Nouvel utilisateur");
                        Console.Write("Son user name : ");
                        userName = Console.ReadLine();
                        Console.Write("Son nom : ");
                        nom = Console.ReadLine();
                        Console.Write("Son prenom : ");
                        prenom = Console.ReadLine();
                        annuaire.AddUtilisateur(userName, nom, prenom);
                        break;

                    case "maj":

                        Utilisateur userToUpdate = annuaire.GetUtilisateur();
                        if (userToUpdate != null){
                            Console.Write("Son user name : ");
                            userToUpdate.UserName = Console.ReadLine();
                            Console.Write("Son nom : ");
                            userToUpdate.Nom = Console.ReadLine();
                            Console.Write("Son prenom : ");
                            userToUpdate.Prenom = Console.ReadLine();
                            Console.WriteLine(annuaire.UpdateUtilisateur(userToUpdate) + "\n");
                        }
                        break;

                    case "del":
                        Utilisateur userToDelete = annuaire.GetUtilisateur();
                        if (userToDelete != null)
                            Console.WriteLine(annuaire.RemoveUtilisateur(userToDelete) + "\n");
                        break;

                    default:
                        Console.WriteLine("Vous avez écrit quelque chose qui me déplaît. " +
                            "Veuillez recommencer.");
                        break;

                }
                
            } while (rep != "stop");

            Console.WriteLine("Arrêt du programme..\n A bientôt..");
            Console.ReadKey();
        }
    }
}