using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using the IIS hosted service
            //Console.WriteLine("Using the IIS hosted service");
            //using (IISHostedService.SampleServiceClient client = new IISHostedService.SampleServiceClient())
            //{
            //    IISHostedService.Person p = new IISHostedService.Person { Name = "Rahul" };
            //    Console.WriteLine(client.GreetMe(p));
            //}

            //Console.WriteLine();

            // Using the Self hosted service
            Console.WriteLine("Using the Self hosted service");
            using (SelfHostedService.SampleServiceClient client = new SelfHostedService.SampleServiceClient())
            {
                SelfHostedService.Person p = new SelfHostedService.Person { Name = "Rahul" };
                Console.WriteLine(client.GreetMe(p));
            }

            Console.ReadLine();
        }
    }
}
