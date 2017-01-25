using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    /// <summary>
    /// This class contains person properties
    /// </summary>
    /*
         Tehtävä 1 - Henkilörekisteri
    Toteutetaan opettajan kanssa yhdessä konsolipohjainen ohjelma, jolla 
    voidaan hallita henkilöitä eli henkilörekisteri.
    */

    public class Henkilo
    {
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Hetu { get; set; }
        public override string ToString()
        {
            return Etunimi + " " + Sukunimi + " " + Hetu;
        }


    }
    /// This class holds person information in a collection
    /// 
    public class Henkilot
    {
        //properties
        private List<Henkilo> henkilot;
        public List<Henkilo> Henkilolista
        {
            get { return henkilot; }
            
        }
        public Henkilot()
        {
            henkilot = new List<Henkilo>();
        }
        public void LisaaHenkilo(Henkilo hlo)
        {
            henkilot.Add(hlo);
        }
        public Henkilo HaeHenkilo(int index)
        {
            if (index < henkilot.Count)
            {
                return henkilot.ElementAt(index);
            }
            else
            {
                return null;
            }
        }
        public Henkilo HaeHenkiloHetulla(string hetu)
        {
            foreach ( Henkilo hlo in henkilot)
            {
                if (hlo.Hetu == hetu)
                {
                    return hlo;
                }
            }

            return null;
        }
        
    }

/*
        * Tehtävä 2 home Kotitehtävä
Aikaisemmissa demoissa tehtiin CD-luokka, joka sisälsi CD:lle yleisesti kuuluvia
ominaisuuksia. Muuta/tee toteutus, jossa CD:n sisällä olevien biisien määrää ei
ole rajattu. Käsittele CD:n osalta ainakin seuraavat tiedot: nimi, artisti ja biisit.

Ohjelmoi suunnittelemasi CD-luokka. Toteuta pääohjelmassa CD-olio. Tiedot voit keksiä
itse, niitä ei tarvitse kysyä käyttäjältä. Tulosta ruudulle CD:n tietoja.

Esimerkkitoiminta:


    CD data:
    - name:Endless Forms Most Beautiful
    - artist: Nightwish
    - songs:
        - Shudder Before the Beautiful, 6:29
        - Weak Fantasy, 5:23
        - Elan, 4:45
        - Yours Is an Empty Hope, 5:34
        - Our Decades in the Sun, 6:37
        - My Walden, 4:38
        - Endless Forms Most Beautiful, 5:07
        - Edema Ruh, 5:15
        - Alpenglow, 4:45
        - The Eyes of Sharbat Gula, 6:03
        - The Greatest Show on Earth, 24:00
*/
    public class Kappale
    {
        public string Nimi { get; }
        public string Kesto { get; }
        public Kappale(string nimi, string kesto)
        {
            Nimi = nimi;
            Kesto = kesto;
        }    
        public override string ToString()
        {
            return Nimi + ", " + Kesto;
        }
    }
    public class CD
    {
        public string Nimi { get; }
        public string Artisti { get; }
        private List<Kappale> kappaleet;
        public CD (string nimi, string artisti)
        {
            Nimi = nimi;
            Artisti = artisti;
            kappaleet = new List<Kappale>();
        }
        
        public void LisaaKappale(Kappale kappale)
        {
            kappaleet.Add(kappale);
        }
        public override string ToString()
        {
            string s = string.Format("CD tiedot \n- Nimi: {0} \n- Artisti: {1} \n- Kappaleet:", Nimi, Artisti);
            
            foreach(Kappale k in kappaleet)
            {
                s += "\n   - " + k.ToString();
            }

            return s;
        }
    }

    /*
     * Tehtävä 3 home Kotitehtävä
Toteuta ohjelma, joka tallentaa kaikki korttipelin kortit (hertta, ruutu, risti ja pata. Numerot 1-52.) 
valitsemaasi tietorakenteeseen ja tulostaa tietorakenteen sisällön. Bonustehtävä: kuinka voisit toteuttaa
korttipakan sekoittamisen?
*/
 
  
    public class Kortti
    {
        public KorttiMaa Maa { get; }
        public int Arvo { get; }

        public Kortti(KorttiMaa maa, int arvo)
        {
            Maa = maa;
            Arvo = arvo;
        }
        public enum KorttiMaa { Pata, Hertta, Risti, Ruutu }
    }

    public class Korttipakka
    {
        private List<Kortti> pakka;

        public List<Kortti> Pakka
        {
            get { return pakka; }
        }

        public void LisaaKortti(Kortti kortti)
        {
            pakka.Add(kortti);
        }


    }
    
    

}
