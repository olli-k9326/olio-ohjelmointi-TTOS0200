using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class Kiuas
    {
        public bool OnkoPäällä { get; set; }
        public float Lämpötila { get; set; }
        // kosteus voi olla välillä 0-100
        float kosteus;
        public float Kosteus
        {
            get { return kosteus; }

            set
            {
                kosteus = value;
                if (kosteus < 0 || kosteus > 100)
                    kosteus = 0;
            }
        }


    }

    public enum Pesuohjelma { Hienopesu, Villapesu, Kirjopesu, Valkopesu };

    public class Pesukone
    {
        /*
         * Tehtävä 2

Tehtävänäsi on ohjelmoida pesukoneen toiminta. Samoin kuin edellinen tehtävä: mitä ominaisuuksia ja toimintoja tekisit Pesukone-luokkaan?
UML

Suunnittele Pesukone-luokan ominaisuudet ja toiminnot UML-luokkakaaviona.
Ohjelmointi

Toteuta Pesukone-luokan ohjelmointi sekä pääohjelma, jolla luot olion Pesukone-luokasta. Säädä pesukone-oliota erilaisilla arvoilla, jätä Console.WriteLine()-tulostuslauseet ohjelmaasi, jotta pesukone-olion käyttäminen jää näkyville. Toteuta Pesukone-luokkaan muutamia erilaisia konstruktoreita ja alusta niitä käyttämällä oliota pääohjelmasta käsin. 
*/
        public readonly string Malli;
        public bool Pikapesu = false;
        public bool Linkous = false;
        public Pesuohjelma PesuOhjelma = Pesuohjelma.Kirjopesu;

        public bool OnkoPesemässä { get; set; }



        public Pesukone(string x)
        {
            Malli = x;
        }
        public Pesukone(string x, Pesuohjelma y)
        {
            Malli = x;
            PesuOhjelma = y;
        }
        public Pesukone(string x, Pesuohjelma y, bool z)
        {
            Malli = x;
            PesuOhjelma = y;
            OnkoPesemässä = z;
        }

    }

    public class Televisio
    {
        /*
         * Tehtävä 3

Tehtävänäsi on ohjelmoida television toiminta. Samoin kuin edellinen tehtävä: mitä ominaisuuksia ja toimintoja tekisit Televisio-luokkaan?
UML

Suunnittele Televisio-luokan ominaisuudet ja toiminnot UML-luokkakaaviona.
Ohjelmointi

Toteuta Televisio-luokan ohjelmointi sekä pääohjelma, jolla luot olion Televisio-luokasta. Säädä luomaasi Televsio-oliota erilaisilla arvoilla, jätä Console.WriteLine()-tulostuslauseet ohjelmaasi, jotta televisio-olion käyttäminen jää näkyville. 
*/

        public readonly string Malli;
        public readonly int Koko;
        public readonly string MaxResoluutio;
        public bool OnkoPäällä { get; set; }
        int äänenvoimakkuus;
        int kanava;
        public int ÄänenVoimakkuus
        {
            get { return äänenvoimakkuus; }
            set
            {
                äänenvoimakkuus = value;

                if (value < 0)
                    äänenvoimakkuus = 0;

                if (value > 100)
                    äänenvoimakkuus = 100;

            }
        }
        public int Kanava
        {
            get { return kanava; }
            set
            {
                kanava = value;

                if (value < 0)
                    kanava = 0;

            }
        }

        public Televisio(string m, int k, string max)
        {
            Malli = m;
            Koko = k;
            MaxResoluutio = max;
        }
    }

    public class Vehicle
    {
        /*
        Tehtävä 4 home Kotitehtävä

Luo Vehicle-luokka seuraavien tietojen mukaisesti:

    ominaisuudet
    Name:string
    Speed:int
    Tyres:int

    toiminnot
    PrintData(), tulostaa Vehiclen ominaisuudet näytölle
    ToString():string, palauttaa kaikki Vehiclen ominaisuudet yhtenä merkkijonona

Toteuta Vehicle-luokan ohjelmointi sekä pääohjelma, jolla luot olion Vehicle-luokasta.Muuta olion arvoja ja tulosta olion arvoja konsolille.
        */
        public string Name { get; }
        private int speed;
        private int tyres;

        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                if (value < 0)
                    speed = 0;

            }
        }
        public int Tyres
        {
            get { return tyres; }
            set
            {
                tyres = value;
                if (value < 0)
                    tyres = 150;
                if (value > 300)
                    tyres = 300;
            }
        }
        public void PrintData()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Speed: {0}", speed);
            Console.WriteLine("Tyres: {0}", tyres);
        }
        public override string ToString()
        {
            return
                  "Name: " + Name
                + "\nSpeed: " + speed
                + "\nTyres: " + tyres;
            
        }
        public Vehicle(string name, int Speed, int Tyres)
        {
            Name = name;
            speed = Speed;
            tyres = Tyres;
            if (Tyres < 0)
                tyres = 150;
            if (Tyres > 300)
                tyres = 300;
        }
        
    }
    public class Opiskelija
    {
        /*
             Tehtävä 5 home Kotitehtävä
Suunnittele UML-editorilla Opiskelija-luokka, joka sisältää opiskelijalle tyypillisiä tietoja ja toimintoja.
Tee uusi projekti. Ohjelmoi Opiskelija-luokka sekä toteuta pääohjelma, joka luo muutamia opiskelijoita ja tallentaa
opiskelijat taulukkoon (esim. 5 opiskelijaa). Tulosta taulukossa olevien opiskelijoiden tiedot käyttämällä toistorakennetta.
*/
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string HTunnus { get; }
        public string Opintosuuntaus { get; set; }
        public string Ryhmätunnus { get; set; }
        public string Opiskelijatunnus { get; set; }

        public override string ToString()
        {
            string s;

            s = "Nimi: " + Etunimi + " " + Sukunimi
                + "\nHenkilötunnus: " + HTunnus
                + "\nOpintosuuntaus: " + Opintosuuntaus
                + "\nRyhmätunnus: " + Ryhmätunnus
                + "\nOpiskelijatunnus: " + Opiskelijatunnus;

            return s;
        }
        public Opiskelija(string sEtunimi, string sSukunimi, string sHTunnus, string sOpintosuuntaus)
        {
           Etunimi = sEtunimi;
           Sukunimi = sSukunimi;
           HTunnus = sHTunnus;
           Opintosuuntaus = sOpintosuuntaus;
        }


    }

}

//
//
// Okxa 