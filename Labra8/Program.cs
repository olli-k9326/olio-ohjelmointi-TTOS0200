﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestaaNoppa();  Kesken !!!!!!!
            //Ostoskarry();
            //TestFishReg();
            //ShapesAndLists();
            ArrayCalcs_T5();
    }

        /*
         Tehtävä 1 - Noppa home Kotitehtävä
Toteuta Noppa-luokka siten, että noppaa voidaan heittää. Nopan tulee palauttaa
satunnainen luku jokaisella heittokerralla. Toteuta pääohjelmassa nopan heittäminen.
Kokeile ensin heittää noppaa kerran ja tulosta nopan luku. Toteuta tämän jälkeen
ohjelma siten, että kysyt käyttäjältä heittojen määrän. Heitä noppaa ja tulosta
heittojen lukujen keskiarvo.

Esimerkkitulostus:


    Dice, one test throw value is 4
    

    How many times you want to throw a dice :  10000
    Dice is now thrown 10000 times, average is 3,4853
    
+tehtävä. Tulosta lopuksi kaikkien heitettyjen lukujen esiintymismäärät.


    How many times you want to throw a dice :  10000

    Dice is now thrown 10000 times
    - average is 3,4853
    - 1 count is 1726
    - 2 count is 1610
    - 3 count is 1705
    - 4 count is 1691
    - 5 count is 1580
    - 6 count is 1688

    Press enter key to continue...
    */
        public static void TestaaNoppa()
        {
            string input;
            float x = (float)3 / 2;
            Console.WriteLine(x);
            int throws;
            int diceMin = 1;
            int diceMax = 6;
            int[] diceValues = new int[diceMax];
            Dice dice = new Dice(diceMin, diceMax);
            dice.ThrowDice();
            Console.Write("How many times you want to throw a dice ? ");

            input = Console.ReadLine();
            while (int.TryParse(input, out throws) == false || throws == 0)
            {
                Console.Write("Incorrect input. Insert again: ");
                input = Console.ReadLine();
            }
            for (int i = 0; i < throws; i++)
            {
                dice.ThrowDice();
            }

            Console.WriteLine("Dice is now thrown {0} times", throws);
            Console.WriteLine("Average is 3", dice.DiceAverage());
            Console.WriteLine(dice.ToString());




        }
        /*
         Tehtävä 2 - Ostokset home Kotitehtävä
        Toteuta sovellus, jolla voit hallita ostoskärryn sisältöä. Ostettavalta tuotteelta
        riittää käsitellä nimi ja hinta. Toteuta Product-luokka ja lisää pääohjelmassa 
        esimerkiksi List-tietorakenteeseen muutamia Product-luokan oliota. Tulosta lopuksi
        kokoelman sisältö.

        Esimerkkitulostus:


    All products in collection:
    - product : Milk 1,4 e
    - product : Beer 2,2 e
    - product : Butter 3,2 e
    - product : Cheese 4,2 e
    
    Press enter key to continue...
    */
        public static void Ostoskarry()
        {
            string input;
            float price;
            //Product product1 = new Product("Maito", 2.34f);
            Product product;
            Shoppingcart shoppingcart = new Shoppingcart();
            Console.WriteLine("***OSTOSKÄRRISOVELLUS****");
            do
            {
                product = new Product("", 0);
                Console.Write("Insert product: ");
                input = Console.ReadLine();
                if (input == "exit") continue;

                product.Name = input;
                Console.Write("Price : ");
                input = Console.ReadLine();
                if (input == "exit") continue;

                while (float.TryParse(input, out price) == false || price < 0)
                {
                    Console.Write("Incorrect input. Insert again: ");
                    input = Console.ReadLine();
                }
                product.Price = price;
                shoppingcart.AddProduct(product);
                Console.WriteLine();
            } while (input != "exit");
            
            Console.WriteLine(shoppingcart.ToString());
        }
        /*
         Tehtävä 3 - Kalat home Kotitehtävä
Toteuta sovellus, jossa voit hallita kalastukseen liittyviä tietoja. Ohjelman pitää 
pystyä käsittelemään: saadun kalan perustiedot (laji, pituus ja paino), kalastajan
perustiedot (nimi, puhelinnumero) sekä saadun kalapaikan perustiedot (nimi ja paikka). 
Pohdi tarvittava luokkarakenne UML-kaaviona. Toteuta pääohjelmassa kalastaja ja muutamia kaloja.
Tulosta lopuksi kalarekisterin sisältö.

Esimerkkitulostus:


    A new fisherman added to register:
     - Fisherman: Kirsi Kernel Phone: 020-12345678

    Fisher : Kirsi Kernel got a new fish
     - specie : pike 120 cm 4,5 kg
     - place: The Lake of Jyväskylä
     - location: Jyväskylä

    Fisher : Kirsi Kernel got a new fish
     - specie: salmon 190 cm 13,2 kg
     - place: River Teno
     - location: The Northern edge of Finland

    All fishes in register:

    Fisherman Kirsi Kernel has got following fishes:

     - specie: pike 120 cm 4,5 kg
     - place: The Lake of Jyväskylä
     - location: Jyväskylä

     - specie: salmon 190 cm 13,2 kg
     - place: River Teno
     - location: The Northern edge of Finland

    Press enter key to continue...   
    
+tehtävä: tulosta kalarekisteri siten, että kalat ovat suuruusjärjestykessä (painavin ensin).


    Sorted register

    All fishes in register:

    Fisherman Kirsi Kernel has got following fishes:

     - specie: salmon 190 cm 13,2 kg
     - place: River Teno
     - location: The Northern edge of Finland

     - specie: pike 120 cm 4,5 kg
     - place: The Lake of Jyväskylä
     - location: Jyväskylä 
     
    Press enter key to continue...   
    */
        public static void TestFishReg()
        {
            FishRegister register = new FishRegister("JKL register");
            FishingLocation location1 = new FishingLocation { Place = "The Lake of Jyväskylä", Location = "Jyväskylä" };
            FishingLocation location2 = new FishingLocation { Place = "Nilakka", Location = "Pohjois-Savo" };
            Fish fish1 = new Fish { Specie = "salmon", Length = 25, Weigth = 3.382f, FLocation = location1 };
            Fish fish2 = new Fish { Specie = "trout", Length = 65, Weigth = 7.382f, FLocation = location2 };
            Fisher fisher1 = new Fisher { SSN = "190282-102I", Name = "Matti Maila", Phonenumber = "030 388 9203" };
            Fisher fisher2 = new Fisher { SSN = "200282-122K", Name = "Pasi Kiisseli", Phonenumber = "003 328 9213" };

            Console.WriteLine( register.AddFisher(fisher1) );
            Console.WriteLine();
            Console.WriteLine( register.AddFish(fisher1, fish1) );
            Console.WriteLine();
            Console.WriteLine(register.AddFisher(fisher2));
            Console.WriteLine();
            Console.WriteLine(register.AddFish(fisher2, fish2));
            Console.WriteLine();
            Console.WriteLine(register.AddFish(fisher2, fish1));
            Console.WriteLine();
            Console.WriteLine(register.ToString());
            
        }

        /*
         Tehtävä 4 - Kuviot home Kotitehtävä

Toteuta sovellus, jolla voidaan käsitellä erilaisia kuviota (esim. Circle ja Rectangle). 
Laadi erillinen abstrakti Shape-luokka, josta muut kuviot peryityvät. Määrittele Shape-luokan
ominaisuutena kuvion nimi (Name) ja abstraktit Area- ja Circumference-metodit (pinta-ala ja 
ympärysmitta). Peri Circle- ja Rectangle-luokat Shape-luokasta ja toteuta Area- ja 
Circumference-metodit. Luo Shapes-luokka ja sen sisälle List-tietorakenne, jonne voit aina 
lisätä kuvioita. Toteuta pääohjelma, jossa käytät Shapes-luokkaa, luo muutamia eri kuviota ja 
lisää ne Shapes-luokassa olevaan List-tietorakenteeseen. Käy pääohjelmassa lopuksi läpi 
Shapes-luokan List-tietorakenne ja tulosta kaikki sen sisältämät kuviot.

Esimerkkitulostus:


    Circle Radius=1 Area=3,14 Circumference=7,28
    Circle Radius=2 Area=12,57 Circumference=12,56
    Circle Radius=3 Area=28,27 Circumference=18,84
    Rectangle Width=10 Height=20 Area=200,00 Circumference=60,00
    Rectangle Width=20 Height=30 Area=600,00 Circumference=100,00
    Rectangle Width=40 Height=50 Area=2000,00 Circumference=180,00

    Press enter key to continue...
    */
        public static void ShapesAndLists()
        {
            Circle circle1 = new Circle { Radius = 3.245f };
            Circle circle2 = new Circle { Radius = 7.745f };
            Circle circle3 = new Circle { Radius = 5.245f };
            Rectangle rectangle1 = new Rectangle { Width = 2.34f, Heigth = 4.623f };
            Rectangle rectangle2 = new Rectangle { Width = 10.34f, Heigth = 2.34f };
            Rectangle rectangle3 = new Rectangle { Width = 5.23f, Heigth = 7.23f };
            Shapes shapes = new Shapes();
            shapes.AddShape(circle1);
            shapes.AddShape(circle2);
            shapes.AddShape(circle3);
            shapes.AddShape(rectangle1);
            shapes.AddShape(rectangle2);
            shapes.AddShape(rectangle3);

            
            Console.WriteLine(shapes.ToString());

        }
        /*
Tehtävä 5 - Laskutoimituksia ja yksikkötestaus home Kotitehtävä

Toteuta ArrayCalcs-niminen luokka ja sen sisälle seuraavat staattiset-metodit: Sum, Average, Min
ja Max. Metodit ottavat parametriksi double[]-taulukon ja laskevat nimensä mukaisen 
laskutoimintuksen taulukon alkioille ja palauttavat tuloksen kutsuvalle ohjelmalle.

Toteuta pääohjelma ja esimerkiksi seuraavaa dataa sisältävä taulukko:
double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 }; Kutsu pääohjelmasta
ArrayCalcs-luokan staattisia laskutoimituksia tekeviä metodeja annetun taulukon 
arvoilla ja tulosta tulokset näyttölaitteelle.

Esimerkkitulostus:


    Sum = 25,60
    Ave = 3,66
    Min = -4,50
    Max = 12,00

    Press enter key to continue...    
    

ArrayCalcs-luokan metodien testaaminen

Toteuta solutioniin uusi yksikkötestaukseen liittyvä projekti ja testaa ArrayCalcs-luokan
kaikki metodit.
Kuinka ArrayCalcs-luokan metodit toimivat, jos välität parametrina tyhjän
double[]-taulukon: double[] array = { }; 
*/
        public static void ArrayCalcs_T5()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            //double[] array = { };
            Console.WriteLine("Sum = " + Math.Round(ArrayCalcs.Sum(array),2));
            Console.WriteLine("Ave = " + Math.Round(ArrayCalcs.Average(array),2));
            Console.WriteLine("Min = " + Math.Round(ArrayCalcs.Min(array),2));
            Console.WriteLine("Max = " + Math.Round(ArrayCalcs.Max(array),2));
        }
    }
}
