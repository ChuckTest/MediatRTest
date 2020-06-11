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

            RequestTest.Test();

            Console.ReadLine();
        }
    }
}
