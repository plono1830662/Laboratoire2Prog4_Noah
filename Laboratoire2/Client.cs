using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire2
{
    class Client
    {
        int tempsService;
        public int no;
        public Client(int _tempsService)
        {
            no = GenererNo();
            tempsService = _tempsService;
        }
        public int TempsService { get { return tempsService; } set { tempsService = value; } }
        int GenererNo()
        {
            Random rnd = new Random();
            return rnd.Next(1, 89);
        }
        public void Affichage()
        {
            Console.WriteLine("Client "+no+" est disponible");
        }
    }
}
