using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAMK.IT;

namespace JAMK.IT.Henkilorekisteri
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TestaaHenkilorekisteri();
            //TestaaCD();
            TestaaKorttipakka();
        }

        static void TestaaHenkilorekisteri()
        {
            // luodaan muutama testi henkilö
            Henkilot poppoo = new Henkilot();
            Henkilo hlo = new Henkilo { Etunimi = "Jack", Sukunimi = "Russell", Hetu = "291298-124A" };
            Henkilo hlo1 = new Henkilo { Etunimi = "Pete", Sukunimi = "Jackson", Hetu = "190890-120A" };
            Henkilo hlo2 = new Henkilo { Etunimi = "Neil", Sukunimi = "Joke", Hetu = "291245-121B" };
            // lisätään henkilöt poppooseen
            poppoo.LisaaHenkilo(hlo);
            poppoo.LisaaHenkilo(hlo1);
            poppoo.LisaaHenkilo(hlo2);
            foreach (Henkilo h in poppoo.Henkilolista)
            {
                Console.WriteLine("Henkilö {0}", h.ToString());
            }
            //TODO kysy käyttäjältä hetu ja haetaan sitä vastaava henkilö näytölle
            Console.WriteLine("\n Syötä henkilötunnus: ");
            string hetu = Console.ReadLine();
            Henkilo haettu = poppoo.HaeHenkiloHetulla(hetu);
            Console.WriteLine();
            if (haettu != null)
            {
                Console.WriteLine(haettu.ToString()); 
            }
            else
            {
                Console.WriteLine("Ei löytynyt. Better luck next time");
            }

        }
        static void TestaaCD()
        {
            CD cdlevy = new CD("JokuNimi", "Nightwish");
            Kappale kp0 = new Kappale ("biisi1", 4, 15);
            Kappale kp1 = new Kappale ("Stargazers ", 3, 15);
            Kappale kp2 = new Kappale ("Gethsemane ", 2, 15);
            Kappale kp3 = new Kappale ("Devil & the Deep", 3, 5);
            Kappale kp4 = new Kappale ("Devil & the Deep", 4,19);
            Kappale kp5 = new Kappale ("Moondance ", 4, 55);
            Kappale kp6 = new Kappale ("Riddler ", 3, 25);
            Kappale kp7 = new Kappale ("Sleeping ", 3, 21);
            cdlevy.LisaaKappale(kp0);
            cdlevy.LisaaKappale(kp1);
            cdlevy.LisaaKappale(kp2);
            cdlevy.LisaaKappale(kp3);
            cdlevy.LisaaKappale(kp4);
            cdlevy.LisaaKappale(kp5);
            cdlevy.LisaaKappale(kp6);
            cdlevy.LisaaKappale(kp7);
            Console.WriteLine(cdlevy.ToString());
        }
        static void TestaaKorttipakka()
        {
            Korttipakka pakka = new Korttipakka();
            for (int i = 2; i <= 14; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Kortti kortti = new Kortti((Kortti.KorttiMaa)j, i);
                    pakka.LisaaKortti(kortti);
                }
            }

            Console.WriteLine(pakka.ToString());
            pakka.Sekoitus();
            Console.WriteLine(pakka.ToString());
            
        }
    }
    
}
