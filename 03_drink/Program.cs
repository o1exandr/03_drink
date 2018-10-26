﻿/*
 Завдання 3.
Визначити клас Напій з полями 
	назва напою,
	тип напою(власного перелічувального типу)	
	виробник
	кількість ккал
	ціна

Створити необхідні конструктори
Перевизначити метод ToString()

Реалізувати інтерфейс  IComparable(як метод класу int CompareTo(object)) : порівнювати напої за типом, потім за назвою

Реалізувати інтерфейс  IComparable< >(як метод класу int CompareTo(Drink)) : порівнювати за назвою напою

/////////////////////////////////////////////////////////////////
Визначити 3 класи   компараторів(реалізують інтерфейс ICompare: тобто int Compare(object, object)) для 
	порівняння за ціною(за зростанням)
	порівняння за ккал(спаданням)
	порівняння за  виробником(зростанням)

Визначити 3 класи   компараторів(реалізують інтерфейс ICompare<Drink>: тобто int Compare(Drink, Drink)) для 
	порівняння за ціною(за спаданням)
	порівняння за ккал(зростанням)
	порівняння за  виробником(зростання)

Реалізувати інтерфейс  IEquatable<>


Перевірити роботу класу.
Підготувати 2 колекції
	ArrayList
	List<Drink>
Перевірити роботу реалізованих інтерфейсів за допомогою сортування колекцій(Sort), пошуку(IndexOf)
  

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _03_drink
{
    public class Drink : IComparable
    {

        public string name;
        public Kind type;
        public string manufacturer;
        public int energy;
        public double price;
        
        public enum Kind { Unknown, Alcohol, Coffee, CreamSoda, MineralWater, Tea};

        public Drink(string n = "drink", Kind t = 0, string m = "-", int e = 0, double p = 0)
        {
            name = n;
            type = t;
            manufacturer = m;
            energy = e;
            price = p;
            
        }

        public override string ToString()
        {
            return $"{name}\t{type, 15}\t{manufacturer, 15}\t{energy, 10}\t{price}$";
        }

        // Реалізувати інтерфейс  IComparable(як метод класу int CompareTo(object)) : порівнювати напої за типом, потім за назвою
        public int CompareTo(object obj)
        {

            if (obj == null)
                throw new ArgumentNullException(null, "You should give a value to method CompareTo");

            if (!(obj is Drink))
                throw new FormatException("CompareTo(obj)-->obj should be Product type");

            Drink drink = (Drink)obj;
            //return this.type.CompareTo(drink.type);
            if (this.type == drink.type)
            {
                return this.name.CompareTo(drink.name);
            }
            else
                return this.type.CompareTo(drink.type);

        }

        // Реалізувати інтерфейс  IComparable< >(як метод класу int CompareTo(Drink)) : порівнювати за назвою напою
        public int CompareTo(Drink drink)
        {
            return this.name.CompareTo(drink.name);
        }

    };


    // порівняння за ккал(спаданням)
    class MyComparerEnergy : IComparer
    {
        public int Compare(object one, object two)
        {
            if (one == null || two == null)
                throw new ArgumentNullException("", "You should give 2 value to method Compare(object, object)");
            if (!(one is Drink) || !(two is Drink))
                throw new FormatException("Compare(object,object) should take object of Drink type");
            Drink o = (Drink)one,
                t = (Drink)two;
            return -o.energy.CompareTo(t.energy);

        }
    }

    // порівняння за ціною(за зростанням)
    class MyComparerPrice : IComparer
    {
        public int Compare(object one, object two)
        {
            if (one == null || two == null)
                throw new ArgumentNullException("", "You should give 2 value to method Compare(object, object)");
            if (!(one is Drink) || !(two is Drink))
                throw new FormatException("Compare(object,object) should take object of  Drink type");
            Drink o = (Drink)one,
                t = (Drink)two;
            return o.price.CompareTo(t.price);

        }
    }

    //порівняння за  виробником(зростанням)
    class MyComparerManufacturer : IComparer
    {
        public int Compare(object one, object two)
        {
            if (one == null || two == null)
                throw new ArgumentNullException("", "You should give 2 value to method Compare(object, object)");
            if (!(one is Drink) || !(two is Drink))
                throw new FormatException("Compare(object,object) should take object of Drink type");
            Drink o = (Drink)one,
                t = (Drink)two;
            return o.manufacturer.CompareTo(t.manufacturer);

        }
    }

    
    class Program
    {
        static public void PrintArr(ArrayList list, string message = "")
        {
            Console.WriteLine("\n\t{0}", message);
            foreach (Drink dr in list)
                Console.WriteLine(dr);
        }

        static public void PrintList(List<Drink> list, string message = "")
        {
            Console.WriteLine("\n\t{0}", message);
            foreach (Drink dr in list)
                Console.WriteLine(dr);
        }

        static void Main(string[] args)
        {
            Drink d = new Drink("IceTea", Drink.Kind.Tea, "Lipton", 25, 0.99);
            List<Drink> drinks = new List<Drink>
            { d,
                new Drink("Coffee", Drink.Kind.Coffee, "Nescafe", 50, 1.99),
                new Drink("Beer", Drink.Kind.Alcohol, "Leff", 100, 2.5),
                new Drink("Water", Drink.Kind.MineralWater, "Borjomi", 5, 1.20),
                new Drink("Cola", Drink.Kind.CreamSoda, "Coca-cola", 220, 0.5),
                new Drink("1 Water", Drink.Kind.MineralWater, "Chervona Kalyna", 7, 0.3),
                new Drink("0 Water", Drink.Kind.MineralWater, "Chervona Kalyna", 15, 0.4),
                new Drink("Pepsi", Drink.Kind.CreamSoda, "Pepsiko", 250, 1.15),
                new Drink("Wiski", Drink.Kind.Alcohol, "Jack Daniel's", 120, 50)};
            //foreach (Drink dr in drinks)
                //Console.WriteLine(dr);

            ArrayList list = new ArrayList();
            list.Add(new Drink("Coffee", Drink.Kind.Coffee, "Nescafe", 50, 1.99));
            list.Add(new Drink("Beer", Drink.Kind.Alcohol, "Leff", 100, 2.5));
            list.Add(new Drink("Water", Drink.Kind.MineralWater, "Borjomi", 5, 1.20));
            list.Add(new Drink("Cola", Drink.Kind.CreamSoda, "Coca-cola", 220, 0.5));
            list.Add(new Drink("1 Water", Drink.Kind.MineralWater, "Chervona Kalyna", 7, 0.3));
            list.Add(new Drink("0 Water", Drink.Kind.MineralWater, "Chervona Kalyna", 15, 0.4));
            list.Add(new Drink("Pepsi", Drink.Kind.CreamSoda, "Pepsiko", 250, 1.15));
            list.Add(new Drink("Wiski", Drink.Kind.Alcohol, "Jack Daniel's", 120, 50));
            list.Add(d);

            /*
            Console.WriteLine("\n\t- Sort by energy -");
            drinks.Sort((x, y) => x.energy.CompareTo(y.energy));
            foreach (Drink dr in drinks)
                Console.WriteLine(dr);
                */
            PrintArr(list, "- All drinks -");

            
            drinks.Sort((x, y) => { if (x.type == y.type) { return x.name.CompareTo(y.name); } else return x.type.CompareTo(y.type); });
            PrintList(drinks, "\n\t- Sort by type/name -");
            
            list.Sort();
            PrintArr(list, "- Sort by name -");

            // порівняння за ккал(спаданням)
            list.Sort(new MyComparerEnergy());
            PrintArr(list, "- Sort by energy -");

            // порівняння за ціною(за зростанням)
            list.Sort(new MyComparerPrice());
            PrintArr(list, "- Sort by price -");

            // порівняння за  виробником(зростанням)
            list.Sort(new MyComparerManufacturer());
            PrintArr(list, "- Sort by manufacturer -");

            Console.ReadKey();

        }
    }
}
