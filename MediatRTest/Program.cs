using System;
using System.Threading.Tasks;

namespace MediatRTest
{
    class MyType
    {

    }

    class Program
    {
        static async Task Main(string[] args)
        {
            InitHelper.Instance.SetupAutofac();

            RequestTest.Test();

            await NotificationTest.Test();

            Console.ReadLine();
        }
    }
}
