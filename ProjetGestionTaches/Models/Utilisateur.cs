using System;
using System.ComponentModel.DataAnnotations;
namespace ProjetGestionTaches.Models { 
    class Utilisateur {
        public int ID { get; set; }
        [Required] public String UserName { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public static bool operator ==(Utilisateur u1, Utilisateur u2) {
            if (u2 is null)
                return false;
            if (u1.UserName == u2.UserName && u1.Nom == u2.Nom && u1.Prenom == u2.Prenom)
                return true;
            return false;
        }
        public static bool operator !=(Utilisateur u1, Utilisateur u2) {
            if (u2 is null)
                return true;
            return (u1.UserName != u2.UserName || u1.Nom != u2.Nom || u1.Prenom != u2.Prenom);                
        }
        public override string ToString() {
            return ID + " : " + UserName + " ( " + Nom + " , " + Prenom + " )"; 
        } 

    } 
}