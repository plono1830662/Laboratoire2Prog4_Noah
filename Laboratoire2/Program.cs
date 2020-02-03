using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Laboratoire2
{
    class Program
    {
        public const int NB_TECHS=5;
        public const int TEMPS_SERVICE_MOYEN_CLIENT=10000;
        public const int PROBA_ARRIVEE_CLIENT=2;
        public const int TEMPS_TOUR=1000;
        public const int PROBA_FAIT = 10;
        static void Main(string[] args)
        {
            HelpDesk helpDesk = new HelpDesk(TEMPS_TOUR,PROBA_ARRIVEE_CLIENT,TEMPS_SERVICE_MOYEN_CLIENT);
            helpDesk.CreerTech(NB_TECHS);

            Thread t = new Thread(new ThreadStart(helpDesk.Run));
            t.Start();
            
            
            
        }
    }
}
