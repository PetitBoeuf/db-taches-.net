using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ProjetGestionTaches.Models
{
    class Registre
    {
        readonly public GestionTachesContext context;
        public Registre(GestionTachesContext c) { context = c; }
        public GestionTachesContext GetContext() { return context; }
        public ElementRegistre GetElementRegistre(int idER){
            return context.Registre.Find(idER);
        }

        public ElementRegistre AddElementRegistre(String nce, String desc){
            ElementRegistre newRegistre = new ElementRegistre()
            {
                NomClasseExecutable = nce,
                Description = desc
            };
            context.Registre.Add(newRegistre);
            context.SaveChanges();
            Console.WriteLine("Nouveau registre ajouté ! Youpi!");

            return newRegistre;
        }

        public String RemoveElementRegistre(int erID){
            ElementRegistre erFound = context.Registre.Find(erID);

            context.Registre.Remove(erFound);
            context.Attach(erFound).State = EntityState.Deleted;
            context.SaveChanges();

            return "Element Registre supprimé !";
        }

        public String UpdateElementRegistre(int erID, string nce, string desc){
            
            ElementRegistre erFound = context.Registre.Find(erID);
            
            erFound.NomClasseExecutable = nce;
            erFound.Description = desc;

            context.Registre.Update(erFound);
            context.Attach(erFound).State = EntityState.Modified;
            context.SaveChanges();

            return "Ayé, l'élément registre a été actualisé avec succès!";
        }
    }
}
