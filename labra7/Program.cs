using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace JAMK.IT
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // TiedostoKirjoitus_T1();
            Tiedostoluku_T2();
            // luvutTiedostoihin_T3();
            //oliotLevylle_T4();
        }

        /*
         *
    Tehtävät : Poikkeuksien käsittely ja tiedostot
    Tehtävä 1 - Tiedostoon kirjoittaminen ja lukeminen

    Tee ohjelma, joka kirjoittaa käyttäjän antamat merkkijonot tiedostoon (lopetusehdon voit
    päättää itse) ja sulje tiedosto. Avaa tämän jälkeen tiedosto lukemista varten ja tulosta 
    näyttölaitteelle tiedoston sisältö riveittäin. Huomioi mahdolliset poikkeukset, joita
    tiedoston käsittely voi aiheuttaa.

    Esimerkkitulostus:


    Give a text line (enter ends) : Matti
    Give a text line (enter ends) : Teppo
    Give a text line (enter ends) : Seppo
    Give a text line (enter ends) : Jorma
    Give a text line (enter ends) :
    
    Contents of T1TextLines.txt:
    Matti
    Teppo
    Seppo
    Jorma
    */
        static void TiedostoKirjoitus_T1()
        {
            StreamWriter outputFile = null;
            bool gimmeLines = true;
            string input;
            string fileContent;
            string filename = "teht1";
            try
            {
                outputFile = new StreamWriter(filename);

                do
                {
                    Console.Write("Gimme a text line (enter ends) : ");
                    input = Console.ReadLine();
                    if (input != "")
                    {
                        outputFile.WriteLine(input);

                    }
                    else
                    {
                        gimmeLines = false;
                    }
                } while (gimmeLines);

                outputFile.Close();
                fileContent = File.ReadAllText(filename);
                Console.WriteLine(fileContent);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (outputFile != null)
                    outputFile.Close();
            }
        }

/*
 * Tehtävä 2 - Tiedoston lukeminen ja tietojen lajittelu home Kotitehtävä

Tee ohjelma, joka lukee yksinkertaisesta tekstitiedosto nimet.txt henkilöitten nimiä ja kertoo
montako nimeä löytyy ja montako kertaa kukin nimi esiintyy. Kopioi (tai luo itse vastaava
tiedosto) D:\Temp -kansioon ja ohjelmoi koodisi tarkistamaan onko em.hakemistossa tiedostoa.
Käytä File.Exist-metodia.	Huomioi myös muut mahdolliset poikkeukset, joita tiedoston käsittely 
voi aiheuttaa.

Esimerkkitulostus:


	Löytyi 20 riviä, ja 9 nimeä.
	Nimi Aappo esiintyy 4 kertaa
	Nimi Benkku esiintyy 2 kertaa
	Nimi Jaakko esiintyy 3 kertaa
	Nimi Wille esiintyy 4 kertaa
	Nimi Sebastian esiintyy 1 kertaa
	Nimi Cecilia esiintyy 2 kertaa
	Nimi Netta esiintyy 2 kertaa
	Nimi Matias esiintyy 1 kertaa
	Nimi Otto esiintyy 1 kertaa
	Press any key to continue . . .
    

Bonustehtävä: Lajittele nimet aakkosjärjestykseen ennen tulostusta.


	Löytyi 20 riviä, ja 9 nimeä sortattuna:
	Nimi Aappo esiintyy 4 kertaa
	Nimi Benkku esiintyy 2 kertaa
	Nimi Cecilia esiintyy 2 kertaa
	Nimi Jaakko esiintyy 3 kertaa
	Nimi Matias esiintyy 1 kertaa
	Nimi Netta esiintyy 2 kertaa
	Nimi Otto esiintyy 1 kertaa
	Nimi Sebastian esiintyy 1 kertaa
	Nimi Wille esiintyy 4 kertaa
	Press any key to continue . . .
    */
        static void Tiedostoluku_T2() //YauSollerS
        {
            string filename = "nimet.txt";
            string fileFolder = @"C:\Temp\";
            string filepath = fileFolder + filename;
            Console.WriteLine(filepath);
            string[] fileContent;

            try
            {
                Dictionary<string, int> hlot = new Dictionary<string, int>();

                if (File.Exists(filepath) == false)
                {
                    Directory.CreateDirectory(fileFolder);  //luodaan kansio
                   
                    randomNames(filepath, 100);         // täytetään nimet.txt nimillä
                    
                }

                fileContent = File.ReadAllLines(filepath);

                foreach (string line in fileContent)
                {
                    if (hlot.ContainsKey(line))
                    {
                        hlot[line]++;
                    }
                    else
                    {
                        hlot.Add(line, 1);
                    }
                }
                var hlotList = hlot.Keys.ToList();
                hlotList.Sort();
                Console.WriteLine("Löytyi {0} riviä ja {1} nimeä", fileContent.Length, hlot.Count);
                foreach (string hlo in hlotList)
                {
                    Console.WriteLine("Nimi: {0,-10}   lkm: {1}", hlo, hlot[hlo]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("jokin meni pieleen");
                Console.WriteLine(ex.Message);
            }

        }
        static void randomNames(string filepath, int amount)
        {
            try
            {
                StreamWriter outputFile = new StreamWriter(filepath);

                string[] randNames = File.ReadAllLines("randNames.txt");
                Random r = new Random();
                for (int i = 0; i < amount; i++)
                {
                    outputFile.WriteLine(randNames[r.Next(0, randNames.Length)]);
                }
                outputFile.Close();

                return;
            }
            catch (Exception)
            {
                throw;
            }

        }
    /*
     *Tehtävä 3 - luvut tiedostoihinhome Kotitehtävä

    Tee ohjelma, joka kysyy käyttäjältä lukuja (joko kokonaisluku tai reaaliluku) ja tallenna
    kokonaisluvut eri tiedostoon kuin reaaliluvut. Sovellus tulee lopettaa, jos käyttäjä ei 
    syötä kokonais- tai reaalilukua. Tarkista tiedostojen sisältö jollain tekstieditorilla.

    Esimerkkitulostus:


    Give a number (enter or not a number ends) : 1,0
    Give a number (enter or not a number ends) : 2,0
    Give a number (enter or not a number ends) : 3,0
    Give a number (enter or not a number ends) : 4
    Give a number (enter or not a number ends) : 5
    Give a number (enter or not a number ends) : 6
    Give a number (enter or not a number ends) :
    
    Contents of T2Integers.txt:
    4
    5
    6

    Contents of T2Doubles.txt:
    1,0
    2,0
    3,0
    */   
    
        static void luvutTiedostoihin_T3()
        {
            StreamWriter outputFile1 = null;
            StreamWriter outputFile2 = null;
            bool inputIsNumber = true;
            string input;
            string fileContent1;
            string fileContent2;
            string filename1 = "kokonais.txt";
            string filename2 = "reaali.txt";
            int temp1;
            float temp2;
            try
            {

                 outputFile1 = new StreamWriter(filename1);
                 outputFile2 = new StreamWriter(filename2);
                do
                {
                    Console.Write("Give me a number (Enter or not number ends) : ");
                    input = Console.ReadLine();

                    if (Int32.TryParse(input, out temp1) == true)
                    {
                        outputFile1.WriteLine(input);
                    }
                    else if (float.TryParse(input, out temp2) == true)
                    {
                        outputFile2.WriteLine(input);
                    }
                    else
                    {
                        inputIsNumber = false;
                    }

                } while (inputIsNumber);

                outputFile1.Close();
                outputFile2.Close();

                // printing filecontents to screen

                fileContent1 = File.ReadAllText(filename1);
                fileContent2 = File.ReadAllText(filename2);

                Console.WriteLine("Contents of {0}", filename1);
                Console.WriteLine(fileContent1);
                Console.WriteLine("\nContents of {0}", filename2);
                Console.WriteLine(fileContent2);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (outputFile1 != null)
                    outputFile1.Close();

                if (outputFile2 != null)
                    outputFile2.Close();
            }
        }
        /*
        Tehtävä 4 - oliot levyllehome Kotitehtävä

        Tee ohjelma, jossa voidaan käsitellä TV-ohjelmia. TV-ohjelman tietoina tulee käsitellä: 
        ohjelman nimi, kanava (jolta ohjelma tulee), alku- ja loppuaika sekä pienimuotoinen 
        infoteksti ohjelmasta. Luo pääohjelmassa muutamia TV-ohjelmaolioita (tiedot voit alustaa
        suoraan koodista, ei tarvitse kysyä käyttäjältä) ja tallenna ne levylle. Mieti käytätkö 
        jotain tietorakennetta apunasi. Toteuta ohjelmaan myös tiedostonlukeminen ja tulosta
        TV-oliot näkyville. 
        */    
        static void oliotLevylle_T4()
        {
            try
            {
                //LuoTVohjelmat
                // Hakee TVohjelmat

                // creating programs
                TvOhjelma ohjelma1 = new TvOhjelma("Pikkukakkonen", "TV1", "11:00", "11:30", "Pikkukakkosessa ransulla on taas vauhti päällä");
                TvOhjelma ohjelma2 = new TvOhjelma("Uutiset", "TV1", "18:00", "18:30", "Klo 18 uutiset. Tsekataan mitä maailmalla on tapahtunu");
                TvOhjelma ohjelma3 = new TvOhjelma("Vain Elämää", "Nelonen", "18:00", "19:30", "Nyt on Cheekin päivä.");
                TvOhjelma ohjelma4 = new TvOhjelma("Ennätystehdas", "Mtv3", "19:00", "19:30", "Kokiksen juonti mahdollisimman nopeasti, kuinka käy?");
                List<TvOhjelma> TvOhjelmat = new List<TvOhjelma>();
                List<TvOhjelma> LueTvOhjelmat = new List<TvOhjelma>();
                TvOhjelmat.Add(ohjelma1);
                TvOhjelmat.Add(ohjelma2);
                TvOhjelmat.Add(ohjelma3);
                TvOhjelmat.Add(ohjelma4);

                // writing to file
                Stream writeStream = new FileStream("TvOhjelmat.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(writeStream, TvOhjelmat);
                writeStream.Close();

                // reading frome file
                Stream readStream = new FileStream("TvOhjelmat.bin", FileMode.Open, FileAccess.Read, FileShare.None);
                TvOhjelmat = (List<TvOhjelma>)formatter.Deserialize(readStream);

                // printing to screen
                foreach (TvOhjelma ohjelma in TvOhjelmat)
                {
                    Console.WriteLine(ohjelma.ToString());
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
         
    }
}
