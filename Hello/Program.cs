using System;

/*
 Ollin esimmmäinen testiohjelma
 9.1.2017
 */
 //ollin demoa tehty
 // xtoinen muutos kommentiin asd le lessss.
namespace Hello2
{
    class Henkilo {
        public string Nimi { get; set; }
        public int Ika { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //SayHello();
            //ShowNames();
            LottoKone();
        }
        static void ShowNames()
        {
            string[] nimet = new string[5];
            // Ohjelma joka kysyy 5 käyttäjänimeä ja tallentaa ne. Ohjelma tulostaa annetut nimet aakkosjärjestyksessä.
            // kysytään nimet
            for (int i=0 ; i < nimet.Length; i++)
            {
                Console.WriteLine("Anna nimi:");
                nimet[i] = Console.ReadLine();
            }

            //näytetään nimet
            Console.WriteLine();
            Console.WriteLine("Annetut nimet olivat");
            for (int i = 0; i < nimet.Length; i++)
            {
                Console.WriteLine(nimet[i]);
            }

            //sortataan ja näytetään
            Array.Sort(nimet);
            Console.WriteLine();
            Console.WriteLine("Annetut nimet aakkosjärjestyksessä ovat:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(nimet[i]);
            }

            Console.WriteLine("Ohjelma suoritettu onnistuneesti!");
        }
        static void SayHello()
        {
            //määritellään muuttuja
            string nimi = "Jack Russell";
            //luodaan olio Henkilo-luokasta
            Henkilo hlo = new Henkilo();
            hlo.Ika = 42;
            hlo.Nimi = "Max Mickelson";
            // Konsolille
            Console.WriteLine("Terve: {0} ikäsi on: {1}", hlo.Nimi, hlo.Ika);
        }
        static void LottoKone()
        {
            int rowsTotal = 0;
            int lotteryMax = 40;
            bool differentRow = false;
            Random r = new Random();
            Console.WriteLine("LOTTORIVI -SOVELLUS!!!!!!");
            Console.WriteLine("Kuinka monta riviä arvotaan?");
            //kysytään riven määrä
            rowsTotal = Convert.ToInt32(Console.ReadLine());
            int[,] lotteryRows = new int[rowsTotal, 7];
            //arvotaan rivit
            for (int i = 0; i < rowsTotal; i++)
            {
                //do
               // {

                    for (int j = 0; j < 7; j++)
                    {
                    r = new Random();
                    int temp = r.Next(1, lotteryMax);
                    lotteryRows[i, j] = temp;
                    
                    }
                for (int j = 0; j < rowsTotal; j++)
                {
                    for (int y = j+1; y < 7; y++)
                    {
                        while(lotteryRows[i,j] == lotteryRows[i,y])
                        {
                            r = new Random();
                            lotteryRows[i, y] = r.Next(1, lotteryMax);
                        }

                    }

                }
                    /*
                    for (int k = 0; k < i; k++)
                    {
                        differentRow = false;
                        for (int m = 0; m < 7; m++)
                        {
                            if (lotteryRows[i, m] != (lotteryRows[k, m]))
                            {
                                differentRow = true;
                                break;
                            }
                        }
                        if (!differentRow)
                        {
                            break;
                        }
                    }
                    */
                //} while (!differentRow || i == 0);
            }
            for (int i = 0; i < rowsTotal; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(lotteryRows[i, j] + " ");
                 
                }
                Console.WriteLine();
            }

        }
        
    }
}
