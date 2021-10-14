using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGestionTaches.Models
{
    class ElementRegistre
    {   
        public int ID { get; set; }
        [Required] public String NomClasseExecutable { get; set; }
        public String Description { get; set; }
        public override string ToString()
        {
            return ID + " : " + NomClasseExecutable + " ==> " + Description + ".";
        }
    }
}
