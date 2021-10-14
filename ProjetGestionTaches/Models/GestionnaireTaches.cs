using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGestionTaches.Models
{

    class GestionnaireTaches
    {
        private Dictionary<int, Tache> listeTaches = new Dictionary<int, Tache>();

        public Tache AjouterTache(Utilisateur p_user, ElementRegistre p_ER){
            
            Tache newTache = new Tache(p_user, p_ER); 

            listeTaches.Add(newTache.PID, newTache);
            newTache.Start();

            return newTache;
        }

        public Tache GetTache(int p_PID) {
            return listeTaches[p_PID];
        }

        public int NbTaches(){
            return listeTaches.Count();
        }

    }
}
