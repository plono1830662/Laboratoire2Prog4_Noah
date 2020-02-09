using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace Laboratoire2
{
    class HelpDesk
    {
        List<Tech> techs;
        QueueClients queueClients;
        Random rnd;
        private int tempsTour;
        private int probaClient;
        private int tempsServMoyen;
        private static IWebProxy _webproxy;
        private string fait;
        public HelpDesk(int _tempsTour,int _probaClient, int _tempsServMoyen)
        {
            techs = new List<Tech>();
            queueClients = new QueueClients();
            rnd = new Random();
            tempsTour = _tempsTour;
            probaClient = _probaClient;
            tempsServMoyen = _tempsServMoyen;
            fait = "";
        }
        public void Run()
        {

            Thread tClient = new Thread(new ThreadStart(TrouverClient));
            tClient.Start();

            foreach (Tech tech in techs)
            {
                tech.SetQueueClient(queueClients);
                Thread t = new Thread(new ThreadStart(tech.Run));
                t.Start();
            }
        }
        public void TrouverClient()
        {
            while (true)
            {
                if (rnd.Next(1, Program.PROBA_FAIT) == 4)
                    HttpGetAsync(@"http://numbersapi.com");
                if (rnd.Next(1, probaClient) == 1)
                    queueClients.TrouverDesClients(tempsServMoyen);
                Console.WriteLine("-------------Tech---------------");

                foreach (Tech tech in techs)
                    tech.Affichage();
                Console.WriteLine("------------Client--------------");
                foreach (Client client in queueClients.Clients)
                    client.Affichage();

                Console.WriteLine("-------------Fait---------------");
                Console.WriteLine(fait);
                Thread.Sleep(tempsTour);
                Console.Clear();
                
            }
        }
        public void CreerTech(int nbTech)
        {
            string[] nom = {"Joe", "Bob","Richard","Tanaso Gardis","Michel","Jean"};
            for (int i = 0; i < nbTech; i++)
            {
                techs.Add(new Tech(nom[rnd.Next(0,nom.Length)]));
                Console.WriteLine(techs[i].Nom);
            }
               
        }
        public async Task HttpGetAsync(string url, Encoding encoding = null)
        {
            int nbFait = rnd.Next(1,150);
            var wc = new System.Net.WebClient

            {
                Proxy = _webproxy,

                Encoding = encoding ?? Encoding.UTF8
            };
            fait= await wc.DownloadStringTaskAsync(url+"/"+nbFait);
        }
    }
}
