using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPrivacy
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Bag
    {
        private List<Item> _items;
        public int MaxWeight { get; set; }

        public Bag(int maxWeight)
        {
            _items = new List<Item>();
            MaxWeight = maxWeight;
        }
        public void AddItem(string name, int weight)
        {
            int currentWeight = _items.Sum(item => item.Weight);

            if (currentWeight + weight > MaxWeight)
                throw new InvalidOperationException();

            var targetItem = new Item(weight, name);
            _items.Add(targetItem);
        }
    }

    class Item
    {
        public int Weight { get; private set; }
        public string Name { get; private set; }

        public Item(int weight, string name)
        {
            Weight = weight;
            Name = name;
        }
    }
}
