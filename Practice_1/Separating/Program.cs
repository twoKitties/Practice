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
            Player player = new Player("Nagibatar", 13);
            Weapon kalash = new Weapon(1f, 10);
            player.CurrentWeapon = kalash;
            MoveHandler moveHandler = new MoveHandler();
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Weapon CurrentWeapon { get; set; }

        public Player(string name, int age)
        {
            Name = name;
            Age = age;
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
        public float MovementDirectionX { get; private set; }
        public float MovementDirectionY { get; private set; }
        public float MovementSpeed { get; private set; }

        public void Move(Player player)
        {
            Console.WriteLine($"Move {player} to {MovementDirectionX} by horizontal and {MovementDirectionY} by vertical");
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
