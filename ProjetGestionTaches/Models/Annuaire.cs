using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGestionTaches.Models
{
    class Annuaire
    {
        readonly public GestionTachesContext context;
        public Annuaire(GestionTachesContext c) { context = c; }
        public GestionTachesContext GetContext() { return context; }
        public Utilisateur AddUtilisateur(String un, String n, String p)
        {
            Utilisateur newUser = new Utilisateur(){
                UserName = un,
                Nom = n,
                Prenom = p
            };
            context.Annuaire.Add(newUser);
            context.SaveChanges();
            Console.WriteLine("Utilisateur ajouté! Youpi! \n");
            return newUser;
        }
        public Utilisateur GetUtilisateur(){
            String repID;
            try
            {
                do
                {
                    Console.Write("Donnez-nous l'ID de l'utilisateur que vous souhaitez modifier" +
                        " : (stop pour arrêter) ");
                    repID = Console.ReadLine();
                } while (context.Annuaire.Find(Int32.Parse(repID)) == null);
            }
            catch(Exception e){
                return null;
            }
            Console.WriteLine(context.Annuaire.Find(Int32.Parse(repID)));
            return context.Annuaire.Find(Int32.Parse(repID));
        }
        public Utilisateur GetUtilisateur(int ID)
        {
            return context.Annuaire.Find(ID);
        }
        public String RemoveUtilisateur(Utilisateur uX)
        {
            Utilisateur uFound = context.Annuaire.Find(uX.ID);
            try
            {
                context.Annuaire.Remove(uFound);
                context.Attach(uFound).State = EntityState.Deleted;
                context.SaveChanges();
                return "Utilisateur Supprimé";
            }
            catch(Exception e)
            {
                return ("Erreur lors de la suppression : " + e);
            }
        }
        public String UpdateUtilisateur(Utilisateur uX)
        {
            Utilisateur uFound = context.Annuaire.Find(uX.ID);
            
            uFound.UserName = uX.UserName;
            uFound.Nom = uX.Nom;
            uFound.Prenom = uX.Prenom;
            context.Annuaire.Update(uFound);
            context.Attach(uFound).State = EntityState.Modified;
            context.SaveChanges();
            return "Ayé, l'utilisateur est mis à jour!";
            
        }
    }
}
