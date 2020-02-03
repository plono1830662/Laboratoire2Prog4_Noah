using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire2
{
    class QueueClients
    {
        Random rnd = new Random();
        public ConcurrentQueue<Client> Clients;
        public QueueClients()
        {
            Clients = new ConcurrentQueue<Client>();
        }
        public void TrouverDesClients(int tempsMoyen)
        {
            Clients.Enqueue(new Client((int)(-tempsMoyen * Math.Log(1 - rnd.NextDouble()))));
        }
    }
}
