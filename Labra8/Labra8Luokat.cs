using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    class Dice
    {
        private int min;
        private int max;
        private int diceValue;
        private Dictionary<int, int> diceValues;
        public Dictionary<int, int> DiceValues { get; }
        Random r;

        public int DiceValue
        {
            get { return diceValue; }
            set {
                diceValue = value;
                if (value < min)
                    diceValue = min;
                if (value > max)
                    diceValue = max;
            }
        }
        private void addValuesToList(int x)
        {
            if (diceValues.ContainsKey(x))
                diceValues[x]++;
            
        }
        private void giveDiceValues(int Min, int Max)
        {
            diceValues = new Dictionary<int, int>();
            for (int i = Min; i <= Max; i++)
            {
                diceValues.Add(i, 0);
            }
        }
        
        public Dice(int Min, int Max)
        {
            min = Min;
            max = Max;
            diceValue = Min;
            r = new Random();
            
            giveDiceValues(Min, Max);
            
        }
        public void ThrowDice()
        {
            diceValue = r.Next(min, max + 1);
            addValuesToList(DiceValue);
        }
        public float DiceAverage()
        {
            int sum = 0;
            int n = 0;
            for (int i = min; i <= max; i++)
            {
                n += diceValues[i];
                sum += (i * diceValues[i]);
            }
            return (float)sum / n;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = min; i <= max ; i++)
            {
                s += string.Format("\n{0} count: {1}", i, diceValues[i]);
            }
            return s;

        }

    }
    class Product
    {
        public string Name { get; set; }
        public float Price{ get; set; }
        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return Name + " " + Price + " e";
        }
    }
    class Shoppingcart
    {
        public List<Product> Products { get; set; }
        public Shoppingcart()
        {
            Products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public override string ToString()
        {
            string s = "Products in Shopping cart:";
            foreach(Product product in Products)
            {
                s += string.Format("\n- product: {0}", product.ToString());
            }
            
            return s;
        }

    }
    class FishingLocation
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
    class Fish
    {
        public string Specie { get; set; }
        public float Length { get; set; }
        public float Weigth { get; set; }
        public FishingLocation FishingLocation { get; set; }
        
    }
    class Fisher
    {
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public List<Fish> Fishes { get; set; }
        public Fisher()
        {
            Fishes = new List<Fish>();
        }
        public void AddFish(Fish fish)
        {
            Fishes.Add(fish);
        }
    }
    class FishRegister
    {
        public string ID { get; set; }
        public List<Fisher> Fishers { get; set; }
        public Fisher()
        {
            Fishes = new List<Fish>();
        }
        public void AddFish(Fish fish)
        {
            Fishes.Add(fish);
        }
    }
}
