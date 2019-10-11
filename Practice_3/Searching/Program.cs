using System;
using System.Collections.Generic;
using System.Linq;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product(01, 13, "water", 5);
            Product p2 = new Product(02, 20, "bread", 14);
            Product p3 = new Product(03, 50, "vodka", 3);

            List<Product> products = new List<Product>() { p1, p2, p3 };
            var result2 = products.Where(items => items.Price < 100 && items.Amount > 5);
        }
    }

    class Product
    {
        public decimal Price { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Amount { get; private set; }

        public Product(int id, decimal price, string name, int amount)
        {
            Price = price;
            Id = id;
            Name = name;
            Amount = amount;
        }
    }
}
