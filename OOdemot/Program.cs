using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAMK.IT; // helpottaa meidän luokkien löytämistä

namespace OOdemot
{
    class Program
    {
        static void Main(string[] args)
        {
            TestaaKiuas();
        }
        // tehtävän 1 Kiuas-luokan testaus
        static void TestaaKiuas()
        {
            // luodaan kiuas olio
            Kiuas kiuas = new JAMK.IT.Kiuas();
            //pistetääs kiuas lämpenemään ja asetetaan lämpöä & kosteutta
            kiuas.OnkoPäällä = true;
            kiuas.Lämpötila = 90;
            kiuas.Kosteus = 50;
            // näytetään konsolilla
            Console.WriteLine("Kiuas on päällä {0}", kiuas.OnkoPäällä);
            Console.WriteLine("Kiukaan lämpötila on {0}", kiuas.Lämpötila);
            Console.WriteLine("Kiukaan kosteus {0}", kiuas.Kosteus);
            // jos yli rajojen, mitä tapahtuu?
            kiuas.Kosteus = 103;
            Console.WriteLine("Kiukaan kosteus {0}", kiuas.Kosteus);

        }
    }
}
