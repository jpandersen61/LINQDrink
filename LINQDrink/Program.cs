using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable UnusedParameter.Local

namespace LINQDrink
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create drinks
            List<Drink> drinks = new List<Drink>();
            drinks.Add(new Drink("Cuba Libre", "Rum", 3, "Cola", 20));
            drinks.Add(new Drink("Russia Libre", "Vodka", 3, "Cola", 20));
            drinks.Add(new Drink("The Day After", "None", 0, "Water", 20));
            drinks.Add(new Drink("Red Mule", "Vodka", 3, "Fanta", 20));
            drinks.Add(new Drink("Double Straight", "Whiskey", 6, "None", 0));
            drinks.Add(new Drink("Pearly Temple", "None", 0, "Sprite", 20));
            drinks.Add(new Drink("High Spirit", "Vodka", 6, "Sprite", 20));
            drinks.Add(new Drink("Watered Down", "Whiskey", 3, "Water", 3));
            drinks.Add(new Drink("Caribbean Gold", "Rum", 6, "Fanta", 20));
            drinks.Add(new Drink("Siberian Zone", "Vodka", 6, "None", 0));
            #endregion

            Console.WriteLine(" 1.The names of all drinks.");
            IEnumerable<string> names =
            from d in drinks
            select d.Name; 

            foreach(var n in names)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();
            Console.WriteLine("2.The names of all drinks without alcohol.");
            IEnumerable<string> namesNonAlcoholic =
            from d in drinks
            where d.AlcoholicPartAmount == 0
            select d.Name;

            foreach (var n in namesNonAlcoholic)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();
            Console.WriteLine("3.The name, alcohol part and alcohol amount for all drinks with alcohol.");
            var alcoholicDrinks =
            from d in drinks
            where d.AlcoholicPartAmount > 0
            select new { d.Name, d.AlcoholicPart, d.AlcoholicPartAmount};
            foreach(var a in alcoholicDrinks)
            {
                Console.WriteLine($"Name: {a.Name}, Alcoholic part: {a.AlcoholicPart}, amount: {a.AlcoholicPartAmount}");
            }
            Console.WriteLine();
            Console.WriteLine("4.The names of all drinks in alphabetical order.");
            IEnumerable<string> namesAlphabetical =
            from d in drinks
            orderby d.Name
            select d.Name;

            foreach (var n in namesAlphabetical)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

            Console.WriteLine("5.The total amount of alcoholic parts in the drinks.");
            int totalAmountOfAlcoholic  =
            (from d in drinks
            where d.AlcoholicPartAmount > 0
            select d.AlcoholicPartAmount).Sum();
            Console.WriteLine($"Total amount of alcoholic parts: {totalAmountOfAlcoholic}");
            Console.WriteLine();

            Console.WriteLine("6.The average amount of alcohol in drinks with alcohol.");
            double averageAmountOfAlcohol =
            (from d in drinks
             where d.AlcoholicPartAmount > 0
             select d.AlcoholicPartAmount).Average();
            Console.WriteLine($"Total amount of alcoholic parts: {averageAmountOfAlcohol}");

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
