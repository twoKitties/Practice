using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Separating
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Nagibatar", 13, new Weapon(1f, 10));
            MoveHandler moveHandler = new MoveHandler();
            moveHandler.Move(player);
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Weapon CurrentWeapon { get; private set; }

        public Player(string name, int age, Weapon weapon)
        {
            Name = name;
            Age = age;
            CurrentWeapon = weapon;
        }

        public void Attack()
        {
            //attack
            if (CurrentWeapon.IsReloading() == false)
                CurrentWeapon.Shoot();
        }
    }

    class MoveHandler
    {
        public float DirectionX { get; private set; }
        public float DirectionY { get; private set; }
        public float Speed { get; private set; }

        public void Move(Player player)
        {
            Console.WriteLine($"Move {player} to {DirectionX} by horizontal and {DirectionY} by vertical");
        }
    }

    class Weapon
    {
        public float Cooldown { get; private set; }
        public int Damage { get; private set; }

        public Weapon(float cooldown, int damage)
        {
            Cooldown = cooldown;
            Damage = damage;
        }
        public bool IsReloading()
        {
            throw new NotImplementedException();
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
