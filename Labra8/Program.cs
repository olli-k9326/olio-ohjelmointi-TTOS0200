using System;
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
            //TestaaNoppa();
            Ostoskarry();

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

    }
}
