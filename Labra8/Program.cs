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
            //TestFishReg();
            //ShapesAndLists();
            //ArrayCalcs_T5();
            //InvoiceTest();
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
            try
            {
                string input;
                int throws;
                int diceMin = 1;
                int diceMax = 6;
                Dice dice = new Dice(diceMin, diceMax);

                Console.Write("How many times you want to throw a dice ? ");        // ask for throws
                input = Console.ReadLine();

                while (int.TryParse(input, out throws) == false || throws == 0) // check if correct input
                {
                    Console.Write("Incorrect input. Insert again: ");
                    input = Console.ReadLine();
                }

                dice.ThrowDice(throws);

                Console.WriteLine("Dice is now thrown {0} times", throws);
                Console.WriteLine("Average is {0}", dice.DiceAverage().ToString("0.00"));
                Console.WriteLine(dice.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

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
            try
            {
                //Product product1 = new Product("Maito", 2.34f);
                Product product;
                Shoppingcart shoppingcart = new Shoppingcart();
                Console.WriteLine("***OSTOSKÄRRISOVELLUS****");
                do
                {
                    product = new Product("", 0);

                    if (AskInput(product, "Product") == false)
                        break;

                    if (AskInput(product, "Price") == false)
                        break;
                    
                    shoppingcart.AddProduct(product);  // add product to cart
                    Console.WriteLine();

                } while (true);

                Console.WriteLine(shoppingcart.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static bool AskInput(Product product, string property)
        {
            try
            {
                string input;
                float price;
                Console.Write(property + ": ");      // ask for product
                input = Console.ReadLine();

                if (input == "exit")
                    return false;


                if (property == "Product")
                {
                    product.Name = input;
                }
                else if (property == "Price")
                {
                    while (float.TryParse(input, out price) == false || price < 0)  // handle incorrect input
                    {
                        Console.Write("Incorrect input. Insert again: ");
                        input = Console.ReadLine();
                    }
                    product.Price = price;
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                FishRegister register = new FishRegister("JKL register");
                FishingLocation location1 = new FishingLocation { Place = "The Lake of Jyväskylä", Location = "Jyväskylä" };
                FishingLocation location2 = new FishingLocation { Place = "Nilakka", Location = "Pohjois-Savo" };
                Fish fish1 = new Fish { Specie = "salmon", Length = 25, Weigth = 3.382f, FLocation = location1 };
                Fish fish2 = new Fish { Specie = "trout", Length = 65, Weigth = 7.382f, FLocation = location2 };
                Fisher fisher1 = new Fisher { SSN = "190282-102I", Name = "Matti Maila", Phonenumber = "030 388 9203" };
                Fisher fisher2 = new Fisher { SSN = "200282-122K", Name = "Pasi Kiiphli", Phonenumber = "003 328 9213" };

                Console.WriteLine(register.AddFisher(fisher1));
                Console.WriteLine();
                Console.WriteLine(register.AddFish(fisher1, fish1));
                Console.WriteLine();
                Console.WriteLine(register.AddFisher(fisher2));
                Console.WriteLine();
                Console.WriteLine(register.AddFish(fisher2, fish2));
                Console.WriteLine();
                Console.WriteLine(register.AddFish(fisher2, fish1));
                Console.WriteLine();
                Console.WriteLine(register.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

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
            try
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
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

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
            try
            {
                double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
                //double[] array = { };
                Console.WriteLine("Sum = " + Math.Round(ArrayCalcs.Sum(array), 2));
                Console.WriteLine("Ave = " + Math.Round(ArrayCalcs.Average(array), 2));
                Console.WriteLine("Min = " + Math.Round(ArrayCalcs.Min(array), 2));
                Console.WriteLine("Max = " + Math.Round(ArrayCalcs.Max(array), 2));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

/*
Tehtävä 6 - Ostokset ja yksikkötestaus home Kotitehtävä

Toteuta ohjelma, jossa voidaan näyttää lasku ostetuista tavaroista.

Jokaisesta ostetusta tavarasta tulee käsitellä seuraavat tiedot: nimi, hinta ja määrä. Toteutetun
luokan tulee osata palauttaa tieto siitä paljonko ko. ostetut tavarat kokonaisuudessaan maksavat
(hinta*määrä). Toteuta myös ToString()-metodi, joka palauttaa tuotteen nimen, hinnan ja määrät
merkkijonona.


    InvoiceItem
    - Name : String
    - Price : double
    - Quantity : int
    - Total == Price * Quantity : double
    - ToString() : string
    

Toteuta luokka, joka pitää sisällään List-rakenteessa yllä määriteltyjä tuotteita. Luokan tulee
pystyä kertomaan myös asiakkaan nimi, paljonko "laskulla" on yhteensä tuotteita sekä niihin
kuluva rahan määrä kokonaisuudessaan.


    Invoice
    - Customer : string (just a string, no Customer class..)
    - List<InvoiceItem>
    - Total ("sum of InvoiceItem Total's") : string
    - PrintInvoice() ("prints invoice to screen")
    

Toteuta pääohjelma ja määrittele laskulle tavaroita ja ostajan nimi.

Esimerkkitulostus:


    Customer Kirsi Kernel's invoice:
    =================================
    Milk   1,75e 1 pieces 1,75e total
    Beer   5,25e 1 pieces 5,25e total
    Butter 2,50e 2 pieces 5,00e total
    =================================
    Total : 12,00 euros
    

Invoice-luokan kokonaissumman (total) testaaminen

Testaa yksikkötestauksen avulla, että laskulle määritelty kokonaissumma varmasti lasketaan oikein. 
*/
        public static void InvoiceTest()
        {
            try
            {
                InvoiceItem kalja1 = new InvoiceItem("Karhu-olut", 1.1, 24);
                InvoiceItem makkara = new InvoiceItem("Wilhelm", 2.49, 4);
                InvoiceItem hammastahna = new InvoiceItem("Pepsodent", 2.30, 1);
                InvoiceItem kahvi1 = new InvoiceItem("Juhla Mokka", 3.30, 3);

                Invoice invoice = new Invoice();
                invoice.Customer = "Petri Heiskanen";
                invoice.AddItem(kalja1);
                invoice.AddItem(makkara);
                invoice.AddItem(hammastahna);
                invoice.AddItem(kahvi1);

                Console.WriteLine("Olipas rismassa hyvät tarjoukset, tuli ostettua kunnon tavaraa");
                Console.WriteLine("Tämmöinen kuitti tuli ostokista: ");
                Console.WriteLine();
                Console.WriteLine(invoice.PrintInvoice());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
