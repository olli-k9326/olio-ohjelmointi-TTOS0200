using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace JAMK.IT
{
    class Program
    {
        static void Main(string[] args)
        {
            //TiedostoKirjoitus_T1();
            Tiedostoluku_T2();
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
            bool gimmeLines = true;
            string input;
            string fileContent;
            string filename = "teht1";
            try
            {
                StreamWriter outputFile = new StreamWriter(filename);

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
        static void Tiedostoluku_T2()
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
                    Directory.CreateDirectory(fileFolder);
                    File.Create(filepath);
                    
                    return;
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

                Console.WriteLine("Löytyi {0} riviä ja {1} nimeä", fileContent.Length, hlot.Count);
                foreach (string hlo in hlot.Keys)
                {
                    Console.WriteLine("Nimi: {0}   lkm: {1}", hlo, hlot[hlo]);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        static void randomNames()
        {

            

        }
        
    }
}
