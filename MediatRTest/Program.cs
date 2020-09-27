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
            try
            {
                InitHelper.Instance.SetupAutofac();

                Console.WriteLine("Request/response messages, dispatched to a single handler");
                await RequestTest.Test();
                Console.WriteLine();

                Console.WriteLine("Notification messages, dispatched to multiple handlers");
                await NotificationTest.Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch a exception:");
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
