using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAMK.IT;

namespace Olio_Labra5
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestaaAuto();
            TestaaJaakaappi();

        }

        static void TestaaAuto()
        {
            Auto auto1 = new Auto();
            Rengas rengas1 = new Rengas();
            rengas1.Valmistaja = "Nokia";
            rengas1.Malli = "Hakkapeliitta";
            rengas1.Rengaskoko = 20;
            auto1.Merkki = "Opel";
            auto1.Malli = "Vectra";
            auto1.LisaaRengas(rengas1);
            auto1.LisaaRengas(rengas1);
            auto1.LisaaRengas(rengas1);
            auto1.LisaaRengas(rengas1);
            auto1.LisaaRengas(rengas1);
            if (auto1.OnkoMaxRengas)
            {
                Console.WriteLine("Maksimimäärä renkaita jo asennettu\n");
            }
            Console.WriteLine(auto1.ToString());
        }
        static void TestaaJaakaappi()
        {
            Jaakaappi Rosenlew = new Jaakaappi("Rosenlew", 75);
            Elintarvike Maito1 = new Elintarvike("Maito", "Valio", 1.5f);
            Elintarvike Liha1 = new Elintarvike("Jauheliha, nauta", "Atria", 0.9f);
            for (int i = 0; i < 20; i++)
            {
                Rosenlew.LisaaElintarvike(Maito1);
            }
            for (int i = 0; i < 20; i++)
            {
                Rosenlew.LisaaElintarvike(Liha1);
            }
            Console.WriteLine(Rosenlew.TilaaJaljella);
            Console.WriteLine(Rosenlew.Tilavuus);
            Console.WriteLine(Rosenlew.ToString());
        }
    }


}
