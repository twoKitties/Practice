using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollback
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                AccountData data = new AccountData(new Accounts());
                Console.WriteLine("Enter command");
                data.GetCommand(Console.ReadLine());
            }
        }
    }

    class AccountData
    {
        private Accounts _accounts;
        private CommandPool _commandPool;

        public AccountData(Accounts accs)
        {
            _accounts = accs;
            _commandPool = new CommandPool();
        }

        public void GetCommand(string command)
        {
            switch (command)
            {
                case "open":
                    Console.WriteLine("Enter id of new account");                   
                    _commandPool.Do(new CreateCommand(_accounts, TryConvertToInt(Console.ReadLine())));
                    break;
                case "close":
                    Console.WriteLine("Enter id of acc to remove");
                    _commandPool.Do(new CloseCommand(_accounts, TryConvertToInt(Console.ReadLine())));
                    break;
                case "transfer":
                    Console.WriteLine("Enter account id to withdraw money");
                    Account from = _accounts.GetById(TryConvertToInt(Console.ReadLine()));
                    Console.WriteLine("Enter account id to transfer money to");
                    Account to = _accounts.GetById(TryConvertToInt(Console.ReadLine()));
                    Console.WriteLine("How much money to transfer?");
                    decimal money = TryConvertToInt(Console.ReadLine());
                    _commandPool.Do(new TransferCommand(from, to, money));
                    break;
                case "undo":
                    _commandPool.Undo();
                    break;
                default:
                    break;
            }
        }

        private int TryConvertToInt(string id)
        {
            if (int.TryParse(id, out int result))
                return result;

            throw new ArgumentException();
        }
    }

    class Accounts
    {
        private List<Account> _accounts;

        public Accounts()
        {
            _accounts = new List<Account>();
        }

        public void Add(Account acc)
        {
            if (_accounts.Contains(acc) == false)
                _accounts.Add(acc);
        }

        public void Remove(Account acc)
        {
            if (_accounts.Contains(acc))
                _accounts.Remove(acc);
        }        

        public Account GetById(int id) => _accounts.Find(item => item.Id == id);
    }

    class Account
    {
        public int Id { get; private set; }
        public decimal Money { get; private set; }
        
        public Account(int id, decimal money = 0)
        {
            Id = id;
            Money = money;
        }

        public void AddMoney(decimal amount)
        {
            Money += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (Money > amount)
                Money -= amount;
            else
                throw new NotImplementedException();
        }
    }

    class CommandPool
    {
        private List<ICommand> _executed = new List<ICommand>();

        public void Do(ICommand command)
        {
            command.Execute();
            _executed.Add(command);
        }

        public void Undo()
        {
            if (_executed.Count <= 0)
                return;

            _executed[_executed.Count - 1].Undo();
            _executed.RemoveAt(_executed.Count - 1);
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class CreateCommand : ICommand
    {
        private Accounts _accounts;
        private Account _acc;

        public CreateCommand(Accounts accounts, int id)
        {
            _accounts = accounts;
            _acc = new Account(id);
        }

        public void Execute()
        {
            _accounts.Add(_acc);
        }

        public void Undo()
        {
            _accounts.Remove(_acc);
        }
    }

    class TransferCommand : ICommand
    {
        private Account _to;
        private Account _from;
        private decimal _amount;

        public TransferCommand(Account from, Account to, decimal amount)
        {
            _to = to;
            _from = from;
            _amount = amount;
        }

        public void Execute()
        {
            _from.WithdrawMoney(_amount);
            _to.AddMoney(_amount);
        }

        public void Undo()
        {
            _to.WithdrawMoney(_amount);
            _from.AddMoney(_amount);
        }
    }

    class CloseCommand : ICommand
    {
        private Accounts _accounts;
        private Account _acc;

        public CloseCommand(Accounts accounts, int id)
        {
            _accounts = accounts;
            _acc = _accounts.GetById(id);
            _accounts.Remove(_acc);
        }

        public void Execute()
        {
            _accounts.Remove(_acc);
        }

        public void Undo()
        {
            _accounts.Add(_acc);
        }
    }
}
