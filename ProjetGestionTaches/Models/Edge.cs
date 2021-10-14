﻿using System;
using System.Collections.Generic;
using System.Text;
namespace ProjetGestionTaches.Models {
    class Edge:Executable { 
        public int Progression { get; set; }
        public int PID { get; set; } 
        public Edge() { } 
        public void ExecutionProgramme()
        {
            EdgeExe();
        }
        public void EdgeExe() {
            Console.WriteLine("+++++++++++ Démarrage de Edge dans le processus " + PID);
            Progression = 0; 
            while (Progression < 50) {
                Progression++;
                Console.WriteLine("Le processus Edge " + PID + " a le contrôle. Progression = " + Progression);
            }
            Console.WriteLine("********** Fin du processus Edge " + PID);
        }
    }
}