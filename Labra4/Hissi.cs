using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    class Hissi
    {
        /*
         * Tehtävänäsi on ohjelmoida Dynamon hissin kerroksen ohjaukseen liittyvä säädin. Toteutetun ohjelman tulee pystyä kysymään käyttäjältä haluttu kerros ja siirtämään hissi haluttuun kerrokseen (tässä tapauksessa ohjelma kertoo käyttäjälle missä kerroksessa hissi on). Muista, että Dynamon hissi voi olla vain kerroksissa 1-5. Käytä Hissi-luokassa get- ja set-aksessoreita suojamaan olion tila.

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

        public string ID { get;}
        public bool OnkoPaalla { get; set; }
        private int nykyinenKerros = 1; 
        private int uusiKerros;
        private const int minKerros = 1;
        private const int maxKerros = 5;
        private bool onkoValidiKerros = false;

        public void SyotaUusiKerros(int UusiKerros)
        {
            if ( UusiKerros >= minKerros && UusiKerros <= maxKerros )
            { 
                uusiKerros = UusiKerros;
                VaihdaKerros();
                onkoValidiKerros = true;
            }
            else
            {
                onkoValidiKerros = false;
            }
        }
        public bool OnkoValidiKerros()
        {
            return onkoValidiKerros;
        }
        private void VaihdaKerros()
        {
            nykyinenKerros = uusiKerros;
        }
        public int NykyinenKerros()
        {
            return nykyinenKerros;
        }
        public Hissi(string sID, int NykyinenKerros)
        {
            ID = sID;
            nykyinenKerros = NykyinenKerros;
        }

    }
    public class Amplifier
    {
        public string ID { get;}
        public bool IsItOn { get; set; }
        private int currentVolume = 1;
        private int setVolume;
        private const int minVolume = 0;
        private const int maxVolume = 100;
        private bool isValidVolume = false;

        public void SetVolume(int setNewVolume)
        {
            if (setNewVolume >= minVolume && setNewVolume <= maxVolume)
            {
                setVolume = setNewVolume;
                ChangeVolume();
                isValidVolume = true;
            }
            else
            {
                isValidVolume = false;
            }
        }
        public bool IsValidVolume()
        {
            return isValidVolume;
        }
        private void ChangeVolume()
        {
            currentVolume = setVolume;
        }
        public int CurrentVolume()
        {
            return currentVolume;
        }
        public Amplifier(string sID, int CurrentVolume)
        {
            ID = sID;
            currentVolume = CurrentVolume;
        }
        /*
         * Tehtävä 2
Tehtävänäsi on ohjelmoida yksinkertaisen vahvistimen toiminta, jolla voidaan kontrolloida äänenvoimakkuutta välillä 0-100. Toteuta Vahvistin-luokka ja tee pääohjelma, jolla luot olion Vahvistin-luokasta. Säädä ja kokeile vahvistinta eri äänenvoimakkuuksilla. Käytä Vahvistin-luokassa get- ja set-aksessoreita. get-aksessori palauttaa äänenvoimakkuuden ja set-aksessori rajaa äänenvoimakkuuden arvoa.

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



    }
    public class Employee
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public int Salary { get; set; }

        /*
    {
        get { return Salary; }
        set
        {
            Salary = value;

            if (value < 0)
                Salary = 0;

        }
    }
    */
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
        public Boss(string setName, string setProfession, int setSalary, s) : base(setName, setProfession, setSalary)
        {
            Car =
        }
    }

}
