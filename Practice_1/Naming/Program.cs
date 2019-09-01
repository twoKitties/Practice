using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naming
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Masha", 1331, 2000);
            User user2 = new User("Petya", 1831, 3000);
            User user3 = new User("Kolya", 1901, 1500);
            Users users = new Users(user1, user2, user3);

            var allUsers = users.GetAll();

            foreach (var item in allUsers)
                Console.WriteLine(item.Name);

            Console.ReadKey();
        }
    }

    class User
    {
        public string Name { get; }
        public int Id { get; }
        public double Wage { get; }

        public User(string name, int id, double wage)
        {
            Name = name;
            Id = id;
            Wage = wage;
        }
    }

    class Users
    {
        private List<User> _users;

        public Users(params User[] users)
        {
            _users = new List<User>(users);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void AddRange(User[] users)
        {
            _users.AddRange(users);
        }

        public User Get(string name) => _users.Find(item => string.Equals(item.Name, name));

        public User Get(int id) => _users.Find(item => item.Id == id);

        public User[] GetAll() => _users.ToArray();

        public User[] GetAllWithWageHigher(double wage) => _users.FindAll(item => item.Wage > wage).ToArray();

        public User[] GetAllWithWageLess(double wage) => _users.FindAll(item => item.Wage < wage).ToArray();

        public User[] GetAllInRange(double from, double to) => _users.FindAll(item => item.Wage > from && item.Wage < to).ToArray();
    }
}
