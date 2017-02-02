﻿using System;
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
        public string Place { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            string s = "";
            s += string.Format("- place: {0}", Place);
            s += string.Format("\n- location: {0}", Location);
            return s;
        }
    }
    class Fish
    {
        public string Specie { get; set; }
        public float Length { get; set; }
        public float Weigth { get; set; }
        public FishingLocation FLocation { get; set; }
        public override string ToString()
        {
            string s = "";
            
            s += string.Format("- specie: {0} {1} cm {2} kg", Specie, Length, Weigth);
            s += "\n" + FLocation.ToString();
            return s;

        }

    }
    class Fisher
    {
        public string SSN { get; set; }
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
        public override string ToString()
        {
            string s;
            s = string.Format("- Fisherman: {0} ({1}) Phone: {2}", Name, SSN, Phonenumber);
            return s;

        }

    }
    class FishRegister
    {
        public string ID { get; set; }
        public Dictionary<string, Fisher> Fishers { get; set; }
        public FishRegister(string ID)
        {
            this.ID = ID;
            Fishers = new Dictionary<string, Fisher>();
        }
        public string AddFish(Fisher fisher, Fish fish)
        {
            if (Fishers.ContainsKey(fisher.SSN))
                Fishers[fisher.SSN].Fishes.Add(fish);

            string s = string.Format("Fisher : {0} got a new fish", fisher.Name);

            s += "\n" + fish.ToString();

            return s;
        }
        public string AddFisher(Fisher fisher)
        {
            Fishers.Add(fisher.SSN, fisher);
             string s = "A new fisherman added to register:";

             s += "\n" + fisher.ToString();

             return s;
            
        }
       
        

        public override string ToString()
        {
            string s = "All fishes in register:";
            if (Fishers.Count > 0)
            {
                foreach (string SSN in Fishers.Keys)
                {
                    s += string.Format("\n\nFisherman {0} has following fishes: ", Fishers[SSN].Name );
                    foreach(Fish fish in Fishers[SSN].Fishes)
                    {
                        s += "\n\n" + fish.ToString();
                    }

                }
                
            }
            else
            {
                s += "\nThis dude has no fish.";
            }
            return s;
             
        }
        
    }
    abstract class Shape
    {
        public string Name { get; set; }
        public abstract float Area();
        public abstract float Circumference();

    }
    class Circle : Shape
    {
        public float Radius { get; set; }
        public override float Area()
        {
            return (float)Math.PI * Radius * Radius;
        }
        public override float Circumference()
        {
            return 2 * (float)Math.PI * Radius;
        }
        public override string ToString()
        {
            string s;
            s = string.Format("Circle Radius={0} Area={1} Circumference={2}", Radius, Math.Round(Area(), 2), Math.Round(Circumference(), 2));
            return s;
        }
    }
    class Rectangle : Shape
    {
        public float Width { get; set; }
        public float Heigth { get; set; }
        public override float Area()
        {
            return Width * Heigth;
        }
        public override float Circumference()
        {
            return 2 * (Width + Heigth);
        }
        public override string ToString()
        {
            string s;
            s = string.Format("Rectangle Width={0} Heigth={1} Area={2} Circumference={3}", Width, Heigth, Math.Round(Area(), 2), Math.Round(Circumference(), 2));
            return s;
        }
    }
    class Shapes
    {
        public List<Shape> ShapeList { get; set; }
        public Shapes()
        {
            ShapeList = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            ShapeList.Add(shape);
        }
        public override string ToString()
        {
            string s = "Shapes in shape collection:";
            foreach (Shape shape in ShapeList)
            {
                s += "\n\n" + shape.ToString();
            }
            return s;
        }
    }
    public class ArrayCalcs
    {
        public static double Sum(double[] numTable)
        {
            return numTable.Sum();
        }

        public static double Average(double[] numTable)
        {
            if (numTable.Length > 0)
                return numTable.Average();
            else
                return 0;
        }

        public static double Min(double[] numTable)
        {
            return numTable.Min();
        }

        public static double Max(double[] numTable)
        {
            return numTable.Max();
        }
    }

}