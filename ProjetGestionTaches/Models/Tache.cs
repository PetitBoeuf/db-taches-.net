using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetGestionTaches.Models
{
    class Tache
    {
        public int PID { get; set; }
        public Utilisateur Proprietaire { get; set; }
        public ElementRegistre Entry { get; set; }

        private List<int> PIDList = new List<int>();

        public Tache()
        {
        }
        public Tache(Utilisateur p_Proprio, ElementRegistre p_Entry)
        {
            int temp_PID = new Random().Next();

            while (PIDList.Contains(temp_PID)) { temp_PID = new Random().Next(); }

            this.PID = temp_PID;

            this.Proprietaire = p_Proprio;
            this.Entry = p_Entry;
        }
        public void Start(){

            var classe = this.Entry.NomClasseExecutable;
            if (classe != null)
            {
                Type[] lesTypes = Assembly.GetCallingAssembly().GetTypes();
                foreach (Type t in lesTypes)
                {
                    if (classe == t.Name)
                    {
                        var exec = (Executable)Activator.CreateInstance(t);

                        Thread newThread = new Thread(exec.ExecutionProgramme);

                        newThread.Start(this.PID);
                    }

                    /*
                    Type[] lesTypes = Assembly.GetCallingAssembly().GetTypes();
                    foreach(Type t in lesTypes) { 
                        if(classe == t.Name) {
                            switch (classe)
                            {
                                case "Word":
                                    var newWordProcess = (Word)Activator.CreateInstance(t);
                                    newWordProcess.WinWordExe();
                                    break;

                                case "Edge":
                                    var newEdgeProcess = (Edge)Activator.CreateInstance(t);
                                    newEdgeProcess.EdgeExe();
                                    break;

                                default:
                                    Console.WriteLine("Loupé..");
                                    break;

                            } 
                        }
                    }
                    */
                }
            }
        }
    }
}
