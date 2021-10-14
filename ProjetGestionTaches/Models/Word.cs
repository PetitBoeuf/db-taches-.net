using System;
using System.Text;
using System.Threading;

namespace ProjetGestionTaches.Models
{
    class Word:Executable
    {
        public int PID { get; set; }
        public int Progression { get; set; }
        public Word() { }
        public void ExecutionProgramme(int p_PID){
            this.PID = p_PID;
            WinWordExe();
        }
        public void WinWordExe()
        {
            Console.WriteLine("+++++++++++ Démarrage de Word dans le processus " + PID); Progression = 0;

            while (Progression < 50) { 
                Progression++; 
                Console.WriteLine("Le processus Word " + PID + " a le contrôle. Progression = " + Progression);
                Thread.Sleep(100);

            }
            Console.WriteLine("*********** Fin du processus Word " + PID);
        }
    }
}