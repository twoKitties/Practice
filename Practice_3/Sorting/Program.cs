using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("cup", 10, 1);
            Product product2 = new Product("wine", 100, 2);
            Product product3 = new Product("tv", 1000, 3);

            Products productList = new Products(product1, product2, product3);
            
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

    class Products
    {
        private List<Product> _products;

        public Products(params Product[] products)
        {
            _products = new List<Product>(products);
        }

        public Product[] GetAll() => _products.ToArray();

        public Product[] GetSortedByName() => _products.OrderBy(item => item.Name).ToArray();

        public Product[] GetSortedByPrice() => _products.OrderBy(item => item.Price).ToArray();

        public Product[] GetSortedByLevel() => _products.OrderBy(item => item.Level).ToArray();
    }
}
