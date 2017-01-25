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
            //TestaaJaakaappi();
            TestaaNisakas();

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
            Jaakaappi rosenlew = new Jaakaappi("Rosenlew", 75);
            Elintarvike maito1 = new Elintarvike("Maito", "Valio", 1.5f);
            Elintarvike liha1 = new Elintarvike("Jauheliha, nauta", "Atria", 0.9f);
            Elintarvike pepsi = new Elintarvike("Juoma", "Pepsi", 1.5f);
            for (int i = 0; i < 20; i++)
            {
                rosenlew.LisaaElintarvike(maito1);
            }
            for (int i = 0; i < 20; i++)
            {
                rosenlew.LisaaElintarvike(liha1);
            }
            for (int i = 0; i < 50; i++)
            {
                rosenlew.LisaaElintarvike(pepsi);
                if (rosenlew.Onnistuiko == false)
                {
                    Console.WriteLine("Eipäs taida mahtua enempää tavaraa jääkaappiin. Voihan voi.");
                    break;
                }
            }
            Console.WriteLine(rosenlew.TilaaJaljella);
            Console.WriteLine(rosenlew.Tilavuus);
            Console.WriteLine(rosenlew.ToString());
        }
        static void TestaaNisakas()
        {
            Ihminen homoSapiens1 = new Ihminen();
            Aikuinen hemmo = new Aikuinen();
            Vauva vauva1 = new Vauva();
            Aikuinen hemmo2 = new Aikuinen();

            hemmo.Ika = 23;
            hemmo.Nimi = "Jeesus";
            hemmo.Paino = 80;
            hemmo.Pituus = 180;
            hemmo.Auto = "BMW 520";
            
            vauva1.Ika = 1;
            vauva1.Nimi = "Mooses Pessi";
            vauva1.Paino = 80;
            vauva1.Pituus = 180;
            vauva1.Vaippa = "Pampers 47";

            Console.WriteLine(hemmo.ToString());
            Console.WriteLine(vauva1.ToString());
            

            hemmo.Liiku();
            vauva1.Liiku();
            homoSapiens1.Liiku();
            Console.WriteLine(vauva1.Ika);
            vauva1.Kasva();
            vauva1.Kasva();
            vauva1.Kasva();
            Console.WriteLine(vauva1.Ika);



        }


    }


}
