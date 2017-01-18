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
            //TestaaKiuas();
            //TestaaPesukone();
            //TestaaTelevisio();
            //TestCar();
            TestaaOpiskelija();
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
        static void TestaaPesukone()
        {
            Pesukone pesukone = new Pesukone("Rosenlew x3902 r3423402-sr9dde");
            Pesukone pesukone2 = new Pesukone("hepokatti xxx", Pesuohjelma.Villapesu);
            Pesukone pesukone3 = new Pesukone("Eletrolux oiioioi", Pesuohjelma.Valkopesu, true);
            pesukone.OnkoPesemässä = true;
            PesukoneKysely(pesukone);

            pesukone.Linkous = true;
            pesukone.Pikapesu = true;
            PesukoneKysely(pesukone);

            pesukone.OnkoPesemässä = false;
            PesukoneKysely(pesukone);

            PesukoneKysely(pesukone2);
            PesukoneKysely(pesukone3);

        }
        static void PesukoneKysely(Pesukone pesukone)
        {
            if (pesukone.OnkoPesemässä)
            {
                Console.WriteLine("Malli: " + pesukone.Malli);
                Console.WriteLine("Pesuohjelma: " + pesukone.PesuOhjelma);
                if (pesukone.Pikapesu)
                    Console.WriteLine("Pikapesu on kytketty päälle ");
                if (pesukone.Linkous)
                    Console.WriteLine("Linkous on käytössä");
            }
            else
            {
                Console.WriteLine("Pesukone {0} ei ole käynnissä",pesukone.Malli);
            }
            Console.WriteLine();
        }
        
        static void TestaaTelevisio()
        {
            Televisio televisio1 = new Televisio("Siemens 330", 19, "1920x1080");

            televisio1.ÄänenVoimakkuus =565;
            televisio1.Kanava = -1004;
           if (televisio1.OnkoPäällä)
            { 
                Console.WriteLine("Malli: {0}", televisio1.Malli);
                Console.WriteLine("Koko: {0}", televisio1.Koko);
                Console.WriteLine("Reso: {0}", televisio1.MaxResoluutio);
                Console.WriteLine("Äänenvoimakkuus: {0}", televisio1.ÄänenVoimakkuus);
                Console.WriteLine("Kananva: {0}", televisio1.Kanava);
            }
            else
            {
                Console.WriteLine("Hupsis! Ei ollutkaan TV päällä.\n");
            }

            televisio1.OnkoPäällä = true;

            if (televisio1.OnkoPäällä)
            {
                Console.WriteLine("Malli: {0}", televisio1.Malli);
                Console.WriteLine("Koko: {0}", televisio1.Koko);
                Console.WriteLine("Reso: {0}", televisio1.MaxResoluutio);
                Console.WriteLine("Äänenvoimakkuus: {0}", televisio1.ÄänenVoimakkuus);
                Console.WriteLine("Kananva: {0}", televisio1.Kanava);
            }

        }
        public static void TestCar()
        {
            Vehicle car = new Vehicle("Fiat 813", 220, 185);
            Vehicle car2 = new Vehicle("Alfa Romeo 330", 280, 225);
            Vehicle car3 = new Vehicle("Bugatti Veyron Supersport", 431, 300);
            car.Speed = 100;
            car2.Speed = 150;
            car3.Speed = 430;
            car.PrintData();
            car2.PrintData();
            car3.PrintData();
            Console.WriteLine(car.ToString()); 
        }
        public static void TestaaOpiskelija()
        {
            Opiskelija[] opiskelijat = new Opiskelija[5];
            opiskelijat[0] = new Opiskelija("Jesse", "Jaskanen", "181292-238V", "Insinööri, Tieto- ja viestintätekniikka");
            opiskelijat[1] = new Opiskelija("Petri", "Putin", "180292-228C", "Fysioterapeutti");
            opiskelijat[2] = new Opiskelija("Petri", "Putin", "180292-228C", "Fysioterapeutti");
            opiskelijat[3] = new Opiskelija("Simo", "Heiskanen", "180262-128C", "Insinööri, Tieto- ja viestintätekniikka");
            opiskelijat[4] = new Opiskelija("Xiao", "Bebe", "180292-228C", "Insinööri, Tieto- ja viestintätekniikka");

            opiskelijat[0].Opiskelijatunnus = "H8983";
            opiskelijat[0].Ryhmätunnus = "TTV15S2";

            for (int i = 0; i < opiskelijat.Length; i++)
            {
                Console.WriteLine(opiskelijat[i].ToString());
                Console.WriteLine();
            }


           
        }
    }
}
