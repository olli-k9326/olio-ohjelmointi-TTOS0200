﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    /*
        * Tehtävänäsi on ohjelmoida Dynamon hissin kerroksen ohjaukseen liittyvä säädin. Toteutetun ohjelman tulee pystyä kysymään käyttäjältä
        *  haluttu kerros ja siirtämään hissi haluttuun kerrokseen (tässä tapauksessa ohjelma kertoo käyttäjälle missä kerroksessa hissi on). 
        *  Muista, että Dynamon hissi voi olla vain kerroksissa 1-5. Käytä Hissi-luokassa get- ja set-aksessoreita suojamaan olion tila.

Esimerkkitoiminta:


   Elevator is now in floor : 1
   Give a new floor number (1-5) > 2
   Elevator is now in floor : 2
   Give a new floor number (1-5) > 3
   Elevator is now in floor : 3
   Give a new floor number (1-5) > 5
   Elevator is now in floor : 5
   Give a new floor number (1-5) > -1
   Floor is too small!
   Elevator is now in floor : 5
   Give a new floor number (1-5) > 6
   Floor is too big!
   Elevator is now in floor : 5
   Give a new floor number (1-5) > 2
   Elevator is now in floor : 2
   */
    class Hissi
    {
       

        public string ID { get; }
        public bool OnkoPaalla { get; set; }
        private int nykyinenKerros = 1;
        private int uusiKerros;
        private const int minKerros = 1;
        private const int maxKerros = 5;
        private bool onkoValidiKerros = false;

        public int NykyinenKerros
        {
            get { return nykyinenKerros; }
            set 
            {
                if (value >= minKerros && value <= maxKerros)
                {
                    uusiKerros = value;
                    VaihdaKerros();
                    onkoValidiKerros = true;
                }
                else
                {
                    onkoValidiKerros = false;
                }
            }   
        }
        public bool OnkoValidiKerros
        {
            get { return onkoValidiKerros; }
        }
        
        private void VaihdaKerros()
        {
            nykyinenKerros = uusiKerros;
        }

        public Hissi(string sID, int NykyinenKerros)
        {
            ID = sID;
            nykyinenKerros = NykyinenKerros;
        }

    }
    /*
     * Tehtävä 2
Tehtävänäsi on ohjelmoida yksinkertaisen vahvistimen toiminta, jolla voidaan kontrolloida äänenvoimakkuutta 
välillä 0-100. Toteuta Vahvistin-luokka ja tee pääohjelma, jolla luot olion Vahvistin-luokasta. Säädä ja 
kokeile vahvistinta eri äänenvoimakkuuksilla. Käytä Vahvistin-luokassa get- ja set-aksessoreita. get-aksessori palauttaa
äänenvoimakkuuden ja set-aksessori rajaa äänenvoimakkuuden arvoa.

Esimerkkitoiminta:


Give a new volume value (0-100) > 100
-> Amplifier volume is set to : 100
Give a new volume value (0-100) > 40
-> Amplifier volume is set to : 40
Give a new volume value (0-100) > 0
-> Amplifier volume is set to : 0
Give a new volume value (0-100) > -10
-> Too low volume - Amplifier volume is set to minimum : 0
Give a new volume value (0-100) > 200
-> Too much volume -  Amplifier volume is set to maximum : 100
Give a new volume value (0-100) > 35
-> Amplifier volume is set to : 35
*/

    public class Amplifier
    {
        public string ID { get; }
        public bool IsItOn { get; set; }
        private int currentVolume = 1;
        private int setVolume;
        private const int minVolume = 0;
        private const int maxVolume = 100;
        private bool isValidVolume = false;

        public int CurrentVolume
        {
            get { return currentVolume; }
            set
            {
                if (value >= minVolume && value <= maxVolume)
                {
                    setVolume = value;
                    ChangeVolume();
                    isValidVolume = true;
                }
                else
                {
                    isValidVolume = false;
                }
            }
        }
        public bool IsValidVolume
        {
            get { return isValidVolume; }
        }

        private void ChangeVolume()
        {
            currentVolume = setVolume;
        }
        public Amplifier(string sID, int CurrentVolume)
        {
            ID = sID;
            currentVolume = CurrentVolume;
        }
    


    }

    /*
     * Tehtävä 3

Ohjelmassa tulee pystyä käsittelemään työntekijöiden tietoja (Employee). Työntekijöiden osalta seuraavia tietoa
pitää pystyä käsittelemään: työntekijän nimi (Name), työntekijän ammatti (Profession) ja palkka (Salary). Samassa 
ohjelmassa pitää pystyä käsittelemään myös johtajien tietoja (Boss), heillä on edellisten lisäksi myös auto (Car) ja palkkabonus (Bonus).

Tutki tehtävän tavoitetta/kerrontaa ja toteuta tarvittavat UML-luokkakaaviot. Toteuta tämän jälkeen vaaditut luokat,
luo ja käytä olioita pääohjelmasta. Tulosta vaadittujen luokkien olioiden tietoja output-ikkunaan. Tietoja ei tarvitse
kysyä sovelluksen käyttäjältä, vaan voit alustaa ne suoraan pääohjelmassa.

Esimerkkitoiminta: (huomaa, että Kirsi Kernelin tietoja on muutettu ohjelman suorituksessa)

    Employee:
    - Name:Kirsi Kernel Profession:Teacher Salary:1200
    
    Boss:
    - Name:Jussi Jurkka Profession:Head of Institute Salary:9000 Car:Audi Bonus:5000
    
    Employee:
    - Name:Kirsi Kernel Profession:Principal Teacher Salary:2200

    */

    public class Employee
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                salary = value;

                if (value < 0)
                    salary = 0;

            }
        }

        public override string ToString()
        {
            return
                "Nimi: " + Name +
                "\nAmmatti: " + Profession +
                "\nPalkka: " + Salary;

        }
        public Employee(string setName, string setProfession, int setSalary)
        {
            Name = setName;
            Profession = setProfession;
            Salary = setSalary;
        }



    }
    public class Boss : Employee
    {
        public string Car;
        public int Bonus;

        public override string ToString()
        {
            return
                base.ToString() +
                "\nAuto: " + Car +
                "\nBonus: " + Bonus;
        }
        public Boss(string setName, string setProfession, int setSalary, string setCar, int setBonus) : base(setName, setProfession, setSalary)
        {
            Car = setCar;
            Bonus = setBonus;
        }
    }
    /*
     * Tehtävä 4

Toteutettavassa sovelluksessa tulisi pysyä käsittelemään erilaisia kulkuneuvoja. 
Kaikilla kulkuneuvoilla on löydettävissä yhteisinä ominaisuuksina: nimi, malli,
vuosimalli ja väri. Erikoistapauksina pitää pystyä käsittelemään polkupyöriä ja veneitä.
Polkupyörän osalta pitää pystyä erottelemaan se, että onko kyseessä vaihdepyörä 
vai ei sekä mahdollisen vaihteiston mallinimi. Veneiden osalta tietoina pitää 
ainakin olla veneen tyyppi (soutuvene, moottorivene, kajakki, ...) ja kuinka monta
istuinpaikkaa veneestä löytyy.

Tutki tehtävän tavoitetta/kerrontaa ja toteuta 
tarvittavat UML-luokkakaaviot. Toteuta tämän jälkeen vaaditut 
luokat, luo ja käytä olioita pääohjelmasta. Tulosta vaadittujen 
luokkien olioiden tietoja output-ikkunaan. Tietoja ei tarvitse kysyä
sovelluksen käyttäjältä, vaan voit alustaa ne suoraan pääohjelmassa.

Esimerkkitoiminta:


    Bike info 
    - Name:Jopo Model:Street ModelYear:2016 Color:Blue GearWheels:False Gear Name:
    
    Bike2 info 
    - Name:Tunturi Model:StreetPower ModelYear:2010 Color:Black GearWheels:True Gear Name:Shimano
    
    Boat info 
    - Name:Suvi Model:S900 ModelYear:1990 Color:White SeatCount:3 BoatType:Rowboat
    
    Boat2 info 
    - Name:Yamaha Model:Model 1000 ModelYear:2010 Color:Yellow SeatCount:5 BoatType:Motorboat
    */
    public class Vehicle
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public Vehicle(string sName, string sModel, int sModelYear, string sColor)
        {
            Name = sName;
            Model = sModel;
            ModelYear = sModelYear;
            Color = sColor;
        }
        public override string ToString()
        {
            return
                "Name: " + Name +
                "\nModel: " + Model +
                "\nModelYear: " + ModelYear +
                "\nColor: " + Color;
        }
    }
    public class Bicycle : Vehicle
    {
        private bool hasGears;
        public bool HasGears
        {
            get { return hasGears; }
            set
            {
                hasGears = value;
                if (hasGears == false)
                    gearModelName = "";
            }
        }

        private string gearModelName;
        public string GearModelName
        {
            get { return gearModelName; }
            set
            {
                gearModelName = value;
                HasGears = true;
            }
        }
        public override string ToString()
        {
            string GearWheels;

            if (HasGears)
                GearWheels = "Yes";
            else
                GearWheels = "No";

            return base.ToString()
                + "\nGearwheels: " + GearWheels
                + "\nGear model: " + gearModelName;
        }

        public Bicycle(string sName, string sModel, int sModelYear, string sColor) : base(sName, sModel, sModelYear, sColor)
        {

        }
        public Bicycle(string sName, string sModel, int sModelYear, string sColor, string SGearModelName) : base(sName, sModel, sModelYear, sColor)
        {
            gearModelName = SGearModelName;
            HasGears = true;
        }



    }
    public class Boat : Vehicle
    {
        public string Type { get; set; }
        public int Seats { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                "\nBoat type: " + Type +
                "\nSeats: " + Seats;
        }

        public Boat(string sName, string sModel, int sModelYear, string sColor) : base(sName, sModel, sModelYear, sColor)
        {

        }
        public Boat(string sName, string sModel, int sModelYear, string sColor, string sType, int sSeats) : base(sName, sModel, sModelYear, sColor)
        {
            Type = sType;
            Seats = sSeats;
        }

    }
    /*
     * Tehtävä 5 home Kotitehtävä

Tehtävässä tulee toteuttaa C#-ohjelma radion perustoimintojen testaamiseen.

Kannettavassa radiossa on vain kolme säädintä: päälle/pois-kytkin, äänen voimakkuuden
säädin (arvot 0, 1, 2,..., 9) ja kuunneltavan kanavan taajuusvalinta (2000.0 - 26000.0).
Laadi luokka kannettavan radion toteutukseksi. Käytä tekemääsi luokkaa pääohjelmasta
käsin, eli testaile radion toimivuutta erilaisilla voimakkuuden ja taajuuden arvoilla.
Jätä asetus- ja tulostuslauseet näkyville pääohjelmaan, jotta radio-olion käyttö voidaan
todentaa. 
*/
    public class Radio
    {
        public string Model { get; }
        public bool IsOn { get; set; }
        public float MinFreq = 2000;
        public float MaxFreq = 26000;
        public int MinVol = 0;
        public int MaxVol = 9;

        private int volume;

        public int Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                if (value < MinVol)
                    volume = MinVol;
                if (value > MaxVol)
                    volume = MaxVol;
            }
        }
        private float frequency;

        public float Frequency
        {
            get { return frequency; }
            set
            {
                frequency = value;
                if (value < MinFreq)
                    frequency = MinFreq;
                if (value > MaxFreq)
                    frequency = MaxFreq;
            }
        }
        public override string ToString()
        {
            return "Äänenvoimakkuus = " + Volume + ",  Taajuus = " + Frequency;
        }
        public Radio(string sModel)
        {
            Model = sModel;
        }

    }

    /*
     * Tehtävä 6 home Kotitehtävä

ICT-opiskelijan kirjahyllystä löytyy vaikka mitä erilaisia tavaroita: 
kirjoja, lehtiä, cd-levyjä, dvd-levyjä, bluray-levyjä, puhelimia, 
tabletteja, läppäreitä, ... jne. Pohdi UML-kaaviota käyttäen millaisia
luokkarakenteita (ainakin luokkien ja ominaisuuksien osalta) esiintyy
ja käytä apua perintää, jos tavaroille löytyy yhteisiä ominaisuuksia.
Toteuta tämän jälkeen muutamia luokkia, joissa perintää esiintyy. Tee
myös pääohjelma, jossa käytät tekemiäsi luokkia ja luot olioita. 
*/
    public class Huonekalu
    {
        public string Valmistaja { get; }
        public string Malli { get; set; }
        public int Valmistusvuosi { get; }
        
        public string Mitat { get; }
        public string Väri { get; set; }
        private float paino;

        public float Paino
        {
            get { return paino; }
            set
            {
                paino = value;

                if (value < 0)
                    paino = 0;
            }
        }
        public override string ToString()
        {
            return
            "Valmistaja: " + Valmistaja +
            "\nMalli: " + Malli +
            "\nValmistusvuosi: " + Valmistusvuosi +
            "\nMitat: " + Mitat;
        }
        public Huonekalu(int sValmistusvuosi, string sValmistaja, string sMitat)
        {
            Valmistusvuosi = sValmistusvuosi;
            Valmistaja = sValmistaja;
            Mitat = sMitat;
        }
        

    }
    public class Poyta : Huonekalu
    {
        public string TasoMateriaali { get; set; }
        private int jalkojenLkm;

        public int Jalkojenlkm
        {
            get { return jalkojenLkm; }
            set
            {
                jalkojenLkm = value;

                if (value < 0)
                    jalkojenLkm = 0;
            }
        }
        public override string ToString()
        {
            return base.ToString()
                + "\nTason materiaali: " + TasoMateriaali
                + "\nJalkojen lukumäärä: " + jalkojenLkm;

        }
        public Poyta(int sValmistusvuosi, string sValmistaja, string sMitat) : base(sValmistusvuosi, sValmistaja, sMitat)
        {

        }
    }

    public class Tuoli : Huonekalu
    {
        public string IstuinMateriaali { get; set; }
        private int jalkojenLkm;

        public int Jalkojenlkm
        {
            get { return jalkojenLkm; }
            set
            {
                jalkojenLkm = value;

                if (value < 0)
                    jalkojenLkm = 0;
            }
        }
        public override string ToString()
        {
            return base.ToString()
                + "\nIstuimen materiaali: " + IstuinMateriaali
                + "\nJalkojen lukumäärä: " + jalkojenLkm;

        }
        public Tuoli(int sValmistusvuosi, string sValmistaja, string sMitat) : base(sValmistusvuosi, sValmistaja, sMitat)
        {

        }
    }
    public class Hylly : Huonekalu
    {
        private int lokeroidenLkm;

        public int LokeroidenLkm
        {
            get { return lokeroidenLkm; }
            set
            {
                lokeroidenLkm = value;

                if (value < 0)
                    lokeroidenLkm = 0;
            }
        }
        public override string ToString()
        {
            return base.ToString()
                + "\nLokeroiden lukumäärä: " + LokeroidenLkm;

        }
        public Hylly(int sValmistusvuosi, string sValmistaja, string sMitat) : base(sValmistusvuosi, sValmistaja, sMitat)
        {

        }
    }

}
