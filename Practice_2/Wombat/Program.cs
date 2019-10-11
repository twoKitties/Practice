using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wombat
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human(100, 20);
            Wombat wombat = new Wombat(100, 20);

            Console.WriteLine($"human health is {human.Health}");
            Console.WriteLine($"wombat health is {wombat.Health}");

            human.TakeDamage(50);
            wombat.TakeDamage(50);

            Console.WriteLine($"human health is {human.Health}");
            Console.WriteLine($"wombat health is {wombat.Health}");
            Console.ReadLine();
        }
    }

    abstract class Character
    {
        public int Health { get; protected set; }

        public Character(int health)
        {
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            CalculateDamage(damage);

            if (Health <= 0)
            {
                Console.WriteLine("Я умер");
            }
        }

        protected abstract void CalculateDamage(int damage);
    }

    class Wombat : Character
    {
        public int Armor { get; private set; }

        public Wombat(int health, int armor) : base(health)
        {
            Armor = armor;
        }

        protected override void CalculateDamage(int damage)
        {
            Health -= (damage - Armor);
        }
    }

    class Human : Character
    {
        public int Agility { get; private set; }

        public Human(int health, int agility) : base(health)
        {
            Agility = agility;
        }

        protected override void CalculateDamage(int damage)
        {
            Health -= damage / Agility;
        }
    }
}
