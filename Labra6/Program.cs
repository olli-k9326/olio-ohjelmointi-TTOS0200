using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using JAMK.IT;

namespace JAMK.IT.Henkilorekisteri
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TestaaHenkilorekisteri();
            //TestaaCD();
            //TestaaKorttipakka();
            //JypRekisteri();
            PersonListTest();
            PersonDictionaryTest();
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
            for (int arvo = 2; arvo <= 14; arvo++)
            {
                for (int maa = 0; maa < 4; maa++)
                {
                    Kortti kortti = new Kortti((Kortti.KorttiMaa)maa, arvo);
                    pakka.LisaaKortti(kortti);
                }
            }

            Console.WriteLine(pakka.ToString());
            pakka.Sekoitus();

            Console.WriteLine("\nSekoituksen jälkeen: \n" +pakka.ToString());
            
        }
        static void JypRekisteri()
        {
            Pelaaja pelaaja = new Pelaaja();
            
        }
        static void PersonListTest()
        {
            Random r = new Random();
            Person random;
            PersonList persons = new PersonList();
            int personAmount = 10000;
            int personToFind = 1000;
            int start = System.DateTime.Now.Millisecond;

            Stopwatch stopWatch = new Stopwatch();
            

            for (int i = 0; i < personAmount; i++)
            {
                random = new Person();
                random.Randomize(4,10,r);
                persons.AddPerson(random);
            }
            stopWatch.Stop();

            Console.WriteLine("List Collection: ");
            Console.WriteLine("persons count: {0}", persons.Persons.Count);
            Console.WriteLine("Adding time: {0} ms", stopWatch.ElapsedMilliseconds);
            //Console.WriteLine(persons.ToString());
            
            FindRandomPersonList(persons, personToFind, r);
            
        }
        static void FindRandomPersonList(PersonList persons, int personToFind, Random r)
        {
            Person random;
            Person foundPerson;
            int counter = 0;
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("\nFinding persons in collection (by firstname):");
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("| Search | Full Name         |");
            Console.WriteLine("+----------------------------+");

            random = new Person();
            stopWatch.Start();
            for (int i = 0; i < personToFind; i++)
            {
                random.Randomize(4, 10, r);
                foundPerson = persons.FindPersonsByFirstName(random.Firstname);

                if (foundPerson != null)
                {
                    Console.WriteLine("| {0,-6} | {1,-17} |", random.Firstname, foundPerson.ToString());
                    counter++;
                }
            }
            Console.WriteLine("+----------------------------+");
            stopWatch.Stop();

            Console.WriteLine("\nPersons tried to find: {0}", personToFind);
            Console.WriteLine("Persons found {0}", counter);
            Console.WriteLine("Total finding time: {0} ms", stopWatch.ElapsedMilliseconds);
        }

        static void PersonDictionaryTest()
        {
            Random r = new Random();
            Person random;
            PersonDictionary persons = new PersonDictionary();
            int personAmount = 10000;
            int personToFind = 1000;
            int start = System.DateTime.Now.Millisecond;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < personAmount; i++)
            {
                random = new Person();
                random.Randomize(4, 10, r);
                persons.AddPerson(random);
            }
            stopWatch.Stop();

            Console.WriteLine("\nDictionary Collection: ");
            Console.WriteLine("persons count: {0}", persons.Persons.Count);
            Console.WriteLine("Adding time: {0} ms", stopWatch.ElapsedMilliseconds);
            //Console.WriteLine(persons.ToString());

            FindRandomPersonDictionary(persons, personToFind, r);
            
            
        }
        static void FindRandomPersonDictionary(PersonDictionary persons, int personToFind, Random r)
        {
            Person random;
            Person foundPerson;
            int counter = 0;
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("\nFinding persons in collection (by firstname):");
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("| Search | Full Name         |");
            Console.WriteLine("+----------------------------+");

            random = new Person();
            stopWatch.Start();
            for (int i = 0; i < personToFind; i++)
            {
                random.Randomize(4, 10, r);
                foundPerson = persons.FindPersonsByFirstName(random.Firstname);

                if (foundPerson != null)
                {
                    Console.WriteLine("| {0,-6} | {1,-17} |", random.Firstname, foundPerson.ToString());
                    counter++;
                }
            }
            Console.WriteLine("+----------------------------+");
            stopWatch.Stop();

            Console.WriteLine("\nPersons tried to find: {0}", personToFind);
            Console.WriteLine("Persons found {0}", counter);
            Console.WriteLine("Total finding time: {0} ms", stopWatch.ElapsedMilliseconds);
        }



    }
    
}
