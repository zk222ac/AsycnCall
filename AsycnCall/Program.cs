using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsycnCall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Download.......");

            // call Main Thread 
            
            Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("Main thread is....... : " + i);
                    Thread.Sleep(500);
                }
            });
            Task.Run(() =>
            {
               DownloadFile();
            });

            // call worker thread 1.................
            Thread thread1 = new Thread(WorkerThreadMethod1);
            thread1.Start();

            // call worker thread 2..................
            Thread thread2 = new Thread(WorkerThreadMethod2);
            thread2.Start();

            Console.ReadKey();
        }

        static void WorkerThreadMethod1()
        {
            for (int i = 0; i < 50; i++)
            {
               Console.WriteLine("Worker Thread 1........ : " + i);
                Thread.Sleep(500);
            }
        }
        static void WorkerThreadMethod2()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Worker Thread 2......... : " + i);
            }
        }

        static async void DownloadFile()
        {
            HttpClient client  = new HttpClient();
            var data = await client.GetStringAsync("http://www.gmail.com");
            Console.WriteLine("Download is complete Now:" + data);
        }


    }
}
