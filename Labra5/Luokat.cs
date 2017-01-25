using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    /*
     * Tehtävä 1

Tee Rengas-luokka, jolla on seuraavat ominaisuudet: merkki, tyyppi ja rengaskoko. 
Tee tämän jälkeen Kulkuneuvo-luokka muutamilla kulkuneuvoon kuuluvilla ominaisuuksilla
(nimi, malli) ja käytä tekemääsi Rengas-luokkaa apuna renkaiden käsittelyyn.
Tässä vaiheessa voit koostaa kulkuneuvon renkaat Rengas-olioina esim. taulukkoon tai 
kurssimateriaalissa esitettyy List-rakenteeseen (kokoelmaluokat käsitellään tarkemmin 
seuraavissa demoissa). Tee pääohjelma, jossa luot muutamia kulkuneuvoja (esim. auto ja
moottoripyörä) renkaineen. Tietoja ei tarvitse kysyä käyttäjältä, vaan voit alustaa
niitä suoraan pääohjelman koodissa.

Esimerkkitoiminta: 
*/
    class Rengas
    {
        public string Valmistaja { get; set; }
        public string Malli { get; set; }
        public int Rengaskoko { get; set; }

        public override string ToString()
        {

            return string.Format("Valmistaja: {0}  Malli: {1} Rengaskoko : {2}", Valmistaja, Malli, Rengaskoko);
            
        }
    }
    class Auto
    {
        public string Merkki { get; set; }
        public string Malli { get; set; }
        private int maxRenkaidenLkm = 4;
        private int renkaidenLkm = 0;
        public int RenkaidenLkm { get { return renkaidenLkm; } }

        private bool onkoMaxRengas = false;
        public bool OnkoMaxRengas { get { return onkoMaxRengas; } }
        private List<Rengas> renkaat;
        public List<Rengas> Renkaat
        {
            get { return renkaat; }
        }
        
        public void LisaaRengas(Rengas rengas)
        {
            if (renkaidenLkm < maxRenkaidenLkm)
            {
                renkaat.Add(rengas);
                renkaidenLkm++;
                onkoMaxRengas = false;
            }
            else
                onkoMaxRengas = true;
  
        }
        public override string ToString()
        {
            string s;
            s = "Ajoneuvon Merkki: " + Merkki + "   Malli: " + Malli;
            s += "\nRenkaat: ";
            foreach (Rengas rengas in renkaat)
            {

                s += "\n" + rengas.ToString();
            }
            return s;
        }
        public Auto()
        {
            renkaat = new List<Rengas>();
        }


    }
    /*
     * Tehtävä 2

Pohdi jääkaappia reaalimaailman käsitteenä ja erityisesti sitä mitä sieltä löytyy. 
Tee pienimuotoinen toteutus, joka koostaa jääkaapin sisältöä muutamista eri 
asioista/olioista. 
*/

    public class Jaakaappi
    {
        public string Valmistaja { get; }
        private float maxTilavuus;
        private float tilaaJaljella;
        private List<Elintarvike> elintarvikkeet;
        private float lampotila;
        private float minLampo = 0;
        private float maxLampo = 10;
        private bool onnistuiko;
        

        public float MaxTilavuus
        {
            get { return maxTilavuus; }
        }

        public float TilaaJaljella
        {
            get { return tilaaJaljella; }
        }

        public List<Elintarvike> Elintarvikkeet
        {
            get { return elintarvikkeet; }
        }

        public float Lampotila
        {
            get { return lampotila; }

            set
            {
                lampotila = value;
                if (lampotila < minLampo)
                    lampotila = minLampo;
                if (lampotila < maxLampo)
                    lampotila = maxLampo;
            }
        }

        public bool Onnistuiko
        {
            get { return onnistuiko; }
        }

        public Jaakaappi(string AsetaValmistaja, int AsetaTilavuus)
        {
            Valmistaja = AsetaValmistaja;
            maxTilavuus = AsetaTilavuus;
            if (AsetaTilavuus < 0)
            {
                maxTilavuus = 0;
            }
            tilaaJaljella = maxTilavuus;
            elintarvikkeet = new List<Elintarvike>();
        }

        public void LisaaElintarvike(Elintarvike Elintarvike)
        {
            if (tilaaJaljella - Elintarvike.Tilavuus >= 0 )
            {
                elintarvikkeet.Add(Elintarvike);
                tilaaJaljella -= Elintarvike.Tilavuus;
                onnistuiko = true;
            } else
            {
                onnistuiko = false;
            }
        }

        public void PoistaElintarvike(Elintarvike Elintarvike)
        {
            if (elintarvikkeet.Remove(Elintarvike))
            {
                tilaaJaljella += Elintarvike.Tilavuus;
                onnistuiko = true;
            }
                
            else
                onnistuiko = false;
        }

        public override string ToString()
        {
            string s;
            s = string.Format("Jääkaapin {0} sisältö: \nTilaa käytetty {1} l / {2} l", Valmistaja, maxTilavuus - tilaaJaljella, maxTilavuus);
            foreach (Elintarvike Tarvike in elintarvikkeet)
            {
                s += string.Format("\n[{0}] {1}  {2} l", Tarvike.Tyyppi, Tarvike.Valmistaja, Tarvike.Tilavuus);
            }
            return s;
        }

        public float Tilavuus
        {
            get 
            {
                float sum = 0;
                foreach(Elintarvike Tarvike in elintarvikkeet)
                {
                    sum += Tarvike.Tilavuus;
                }
                return sum;
            }
        }



    }

    public class Elintarvike
    {
        public string Tyyppi { get; }
        public string Valmistaja { get; }
        private float tilavuus;
        
        public float Tilavuus
        {
            get { return tilavuus; }
            set
            {
                tilavuus = value;

                if (value < 0) tilavuus = 0;
            }
        }

        public Elintarvike (string AsetaTyyppi, string AsetaValmistaja, float AsetaTilavuus)
        {
            Tyyppi = AsetaTyyppi;
            Valmistaja = AsetaValmistaja;
            tilavuus = AsetaTilavuus;

            if (tilavuus < 0) tilavuus = 0;

        }



    }
    /*
     * Tehtävä 3

Tehtävässä tulee toteuttaa muutamia luokkia, joiden avulla testataan abstraktien metodien
toimivuutta.

Luo abstrakti luokka Nisakas, jolla on Ika-ominaisuus sekä Liiku-metodi, jonka toteutus
on jätetty toteuttamatta (abstrakti metodi).

Peri Nisakas-luokasta Ihminen-luokka, jolla on ominaisuuksina ihmiseen yleisesti 
liittyviä ominaisuuksia (paino, pituus, nimi). Lisää Ihminen-luokkaan metodit: Liiku 
ja Kasva, joista ensimmäinen tulostaa ruutuun "liikun" ja jälkimmäinen lisää ihmisen 
ikää yhdellä vuodella. Huomioi, että Liiku-metodi ja Ikä-ominaisuus on Nisakas-luokassa

Peri Ihminen-luokasta Vauva- ja Aikuinen-luokat. Ylikirjoita Vauva-luokassa yliluokan 
Liiku-metodi tulostamaan "konttaa". Ylikirjoita Aikuinen-luokassa myös sama metodi ja
laita se tulostamaan "kävelee". Lisää aikuiselle ominaisuus auto (String). Lisää 
vauvalle ominaisuus vaippa (String).

Toteuta pääohjelmassa muutamia ihmisiä, aikuisia ja vauvoja. Tulostele olioiden
tietoja konsolille. 
**/
    abstract class Nisakas //k1647
    {

        public int Ika { get; set; }
        public abstract void Liiku();
    }
    class Ihminen : Nisakas
    {
         
        public string Nimi { get; set; }
        public float Paino { get; set; }
        public float Pituus { get; set; }

        public override string ToString()
        {
            return string.Format("IKÄ: {0}     NIMI: {1}    PAINO: {2}    PITUUS: {3}", Ika, Nimi, Paino, Pituus);
        }
        public override void Liiku()
        {
            Console.WriteLine("Liikun");
        }
        public void Kasva()
        {
            Ika++;
        }
        public Ihminen()
        {
            Ika = 20;
        }

    }
    class Vauva : Ihminen
    {
        public string Vaippa { get; set; }

        public override void Liiku()
        {
            Console.WriteLine("Konttaa");
        }
        public override string ToString()
        {
            return base.ToString() + string.Format("    Vaippa: {0}", Vaippa);
        }
    }
    class Aikuinen: Ihminen
    {
        public string Auto { get; set; }

        public override void Liiku()
        {
            Console.WriteLine("Kävelee");
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("    Auto: {0}", Auto);
        }
    }

    // t4 rami







}
