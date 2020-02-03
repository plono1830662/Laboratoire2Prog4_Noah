using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Laboratoire2
{
    class Tech
    {
        string nom;
        int noClient;
        bool isWorking = false;
        QueueClients queueClients;
        public Tech(string _nom)
        {
            noClient = 0;
            Nom = _nom;
        }
        public string Nom { get { return nom; }set { nom = value; } }
        public void Run()
        {
            while (true)
            {

                if (queueClients.Clients.Count() > 0)
                {
                    Client c = null;
                    isWorking = true;
                    
                    if(queueClients.Clients.TryDequeue(out c))
                    {
                        int tempsService = c.TempsService;
                        noClient = c.no;
                        Thread.Sleep(tempsService);
                    }
                }
                isWorking = false;
            }
        }
        public void SetQueueClient(QueueClients _queueClients)
        {
            queueClients = _queueClients;
        }
        public void Affichage()
        {
            if (isWorking == true)
                Console.WriteLine(nom + " est en cours de travail avec "+noClient);
            else
                Console.WriteLine(nom + " est libre");
        }
    }
}
