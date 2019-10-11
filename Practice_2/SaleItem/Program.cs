using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleItem
{
    class Program
    {
        static void Main(string[] args)
        {
            IGood flower = new Good(100);
            IGood saleFlower = new SaleGood(flower, 15);

            Console.WriteLine($"flower price {flower}, delivery: {flower.IsDeliverable()}");
            Console.WriteLine($"flower price {saleFlower}, delivery: {saleFlower.IsDeliverable()}");
        }
    }

    class Good : IGood
    {
        private int _price;

        public Good(int price)
        {
            _price = price;
        }

        public int GetPrice() => _price;

        public bool IsDeliverable() => true;
    }

    class SaleGood : IGood
    {
        private IGood _good;
        private int _sale;

        public SaleGood(IGood good, int sale)
        {
            _good = good;
            _sale = sale;
        }

        public int GetPrice() => _good.GetPrice() - _sale;

        public bool IsDeliverable() => false;
    }
}
