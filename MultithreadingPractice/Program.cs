using System.Threading;
using System;

namespace MultithredingPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread;
            t.Name = "Main Thread";
            Console.WriteLine("Current Executing Thread Name :" + t.Name);
            Console.WriteLine("Current Executing Thread Name :" + Thread.CurrentThread.Name);

            Console.WriteLine("Main Thread Started");
            //Creating Threads
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(Method2)
            {
                Name = "Thread2"
            };
            Thread t3 = new Thread(Method3)
            {
                Name = "Thread3"
            };
            //Executing the methods
            t1.Start();
            t2.Start();
            t3.Start();

            Thread displayNumbers = new Thread(() => { DisplayNumbersTill(100); });

            displayNumbers.Start();

            Console.WriteLine("Main Thread Ended");

            Console.Read();
        }

        static void Method1()
        {
            Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
            Console.WriteLine("Method1 Ended using " + Thread.CurrentThread.Name);
        }
        static void Method2()
        {
            Console.WriteLine("Method2 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method2 :" + i);
                if (i == 3)
                {
                    Console.WriteLine("Performing the Database Operation Started");
                    //Sleep for 10 seconds
                    Thread.Sleep(10000);
                    Console.WriteLine("Performing the Database Operation Completed");
                }
            }
            Console.WriteLine("Method2 Ended using " + Thread.CurrentThread.Name);
        }
        static void Method3()
        {
            Console.WriteLine("Method3 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method3 :" + i);
            }
            Console.WriteLine("Method3 Ended using " + Thread.CurrentThread.Name);
        }

        static void DisplayNumbersTill(int num)
        {
            Console.WriteLine($"Displaying numbers from 0 to {num}");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Displaying number: {i}");
            }
        }
    }
}