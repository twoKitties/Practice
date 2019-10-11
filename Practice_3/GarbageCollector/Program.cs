using System;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeGlobalClass SGC = new SomeGlobalClass();
            BigData d = new BigData();
            BigData d2 = new BigData();
            d.Dispose();
            d2.Dispose();
            d = null;
            d2 = null;

            GC.Collect();

            while (true)
            {
                using (d = new BigData())
                using (d2 = new BigData()) ;
            }
        }
    }

    class SomeGlobalClass
    {
        public static SomeGlobalClass Instance;
        public event Action OnSomething;

        public SomeGlobalClass()
        {
            Instance = this;
        }

        public void DoSomething()
        {
            if (OnSomething != null)
            {
                OnSomething();
            }
        }
    }

    class BigData : IDisposable
    {
        public int[] Data;

        public BigData()
        {
            Data = new int[100000];
            SomeGlobalClass.Instance.OnSomething += EventHandler;
        }

        public void Dispose()
        {
            SomeGlobalClass.Instance.OnSomething -= EventHandler;
        }

        ~BigData()
        {
            Console.WriteLine("Disposed");
        }

        public void EventHandler()
        {

        }
    }
}
