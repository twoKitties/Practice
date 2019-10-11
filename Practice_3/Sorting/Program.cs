using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("cup", 200, 2);
            Product product2 = new Product("wine", 100, 1);
            Product product3 = new Product("tv", 150, 3);
            List<Product> products = new List<Product>() { product1, product2, product3 };

            while (true)
            {
                Console.WriteLine("Sorting option: 1 - by name, 2 - by level, 3 - by price");
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        products.Sort((item1, item2) => item1.Name.CompareTo(item2.Name));
                        break;
                    case ConsoleKey.D2:
                        products.Sort((item1, item2) => item1.Level.CompareTo(item2.Level));
                        break;
                    case ConsoleKey.D3:
                        products.Sort((item1, item2) => item1.Price.CompareTo(item2.Price));
                        break;
                    default:
                        Console.WriteLine("Enter valid key");
                        break;
                }
                Console.Clear();
                foreach (var item in products)
                    Console.WriteLine($"item {item.Name}, {item.Level}, {item.Price}");
            }          
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Level { get; private set; }

        public Product(string name, decimal price, int level)
        {
            Name = name;
            Price = price;
            Level = level;
        }
    }
}
