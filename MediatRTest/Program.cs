using System;

namespace MediatRTest
{
    class MyType
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            InitHelper.Instance.SetupAutofac();

            PingTest.Test();

            Console.ReadLine();
        }
    }
}
