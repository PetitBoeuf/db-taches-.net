using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGestionTaches.Models
{
    class UniqueIds
    {
        protected static int id = 0;

        public static int GetId()
        {
            id++;
            return id;
        }
    }
}
