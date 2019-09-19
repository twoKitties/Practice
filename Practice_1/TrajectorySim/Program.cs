using System;
using System.Collections.Generic;

namespace TrajectorySim
{
    class Program
    {
        public static void Main(string[] args)
        {
            Projectile proj1 = new Projectile(5, 5, "1");
            Projectile proj2 = new Projectile(10, 10, "2");
            Projectile proj3 = new Projectile(15, 15, "3");
            Projectiles projectiles = new Projectiles(proj1, proj2, proj3);
            Random random = new Random();

            while (true)
            {
                Projectiles.CheckCollistion(proj1, proj2);
                Projectiles.CheckCollistion(proj1, proj3);
                Projectiles.CheckCollistion(proj2, proj3);

                for (int i = 0; i < projectiles.Count; i++)
                {
                    var p = projectiles.Get(i);
                    p.Move(random.Next(-1, 1), random.Next(-1, 1));

                    if (p.IsAlive)
                        p.ShowInfo();
                }
            }
        }
    }


    class Projectiles
    {
        private List<Projectile> _projectiles;
        public int Count => _projectiles.Count;
        public Projectiles(params Projectile[] projectiles)
        {
            _projectiles = new List<Projectile>();
            _projectiles.AddRange(projectiles);
        }

        public static void CheckCollistion(Projectile p1, Projectile p2)
        {
            if(p1.X == p2.X && p1.Y == p2.Y)
            {
                p1.IsAlive = false;
                p2.IsAlive = false;
            }
        }

        public Projectile Get(string id) => _projectiles.Find(item => string.Equals(item.Id, id));
        public Projectile Get(int index) => _projectiles[index];
        public Projectile[] GetAll() => _projectiles.ToArray();
    }
    class Projectile
    {
        private int _x;
        private int _y;

        public int X
        {
            get
            {
                return _x;
            }
            private set
            {
                _x = value;
                if (_x < 0)
                    _x = 0;
            }
        }
        public int Y
        {
            get
            {
                return _y;
            }
            private set
            {
                _y = value;
                if (_y < 0)
                    _y = 0;
            }
        }
        public bool IsAlive { get; set; }
        public string Id { get; private set; }

        public Projectile(int x, int y, string id)
        {
            Id = id;
            X = x;
            Y = y;
            IsAlive = true;
        }

        public void Move(int directionX, int directionY)
        {
            X += directionX;
            Y += directionY;
        }        

        public void ShowInfo()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Id);
        }
    }
}