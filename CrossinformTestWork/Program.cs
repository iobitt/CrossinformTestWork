using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // подключаем пространство имён, в котором находится класс Stopwatch
using System.Threading;


namespace CrossinformTestWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();

            time.Start();
            
            time.Stop();
            Console.WriteLine("Время работы программы:");
            Console.WriteLine(time.Elapsed);

            Console.ReadKey();
        }
    }
}
