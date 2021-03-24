using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // класс Stopwatch
using System.Threading;
using System.IO;

namespace CrossinformTestWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект для подсчёта времени выполнения программы
            Stopwatch time = new Stopwatch();
            // Запускаем секундомер

            // Получаем путь к файлу из аргументов командной строки
            //if (args.Length < 1)
            //{
            //    Console.WriteLine("Отсутствует путь к файлу!");
            //    return;
            //}
            //string path = args[0];
            string path = "data/big text.txt";

            string text;
            // Получаем весь текст из файла
            // Если не удалось прочитать файл, выводим сообщение об ошибке и завершаем программу
            try
            {
                text = ReadFile(path).ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // Список для хранения результатов запуска алгоритма подсчета триплетов
            List<double> measurements = new List<double>();
            // Число экспериментов
            int measurementsCount = 5;
            // Словарь для хранения частоты встречаемости триплетов
            Dictionary<string, int> triplets = new Dictionary<string, int>();
            // Проводим серию запусков работы алгоритма для подсчёта среднего времени работы
            for (int t = 0; t < measurementsCount; t++)
            {
                time.Start();

                // Создаём словарь, для хранения частоты встречаемсости триплетов
                triplets = TextAnalyzer.FrequencyAnalysis(text);

                // Останавливаем секундомер
                time.Stop();

                // Выводим в консоль время работы программы в миллисекундах
                Console.WriteLine(time.Elapsed.TotalMilliseconds);

                measurements.Add(time.Elapsed.TotalMilliseconds);
                time.Reset();
            }

            // Вывод результата работы программы
            int k = 0;
            foreach (var pair in triplets.OrderByDescending(pair => pair.Value))
            {
                k++;
                if (k == 10)
                {
                    Console.Write("{0}", pair.Key);
                    break;
                }
                else
                {
                    Console.Write("{0}, ", pair.Key);
                }
            }
            Console.WriteLine("");

            double meanTime = 0;
            foreach (var j in measurements)
            {
                meanTime += j;
            }

            Console.WriteLine("Среднее время вычисления после n запусков:");
            Console.WriteLine(meanTime / measurementsCount);

            Console.ReadKey();
        }

        static void Main2(string[] args)
        {
            // Создаем объект для подсчёта времени выполнения программы
            Stopwatch time = new Stopwatch();
            // Запускаем секундомер
            time.Start();

            //Получаем путь к файлу из аргументов командной строки
            if (args.Length < 1)
            {
                Console.WriteLine("Отсутствует путь к файлу!");
                return;
            }
            string path = args[0];

            string text;
            // Получаем весь текст из файла
            // Если не удалось прочитать файл, выводим сообщение об ошибке и завершаем программу
            try
            {
                text = ReadFile(path).ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // Вычисляем частоты встречаемости триплетов
            Dictionary<string, int> triplets = TextAnalyzer.FrequencyAnalysis(text);

            // Выводим 10 самых часто встречаемых триплета
            int k = 0;
            foreach (var pair in triplets.OrderByDescending(pair => pair.Value))
            {
                k++;
                if (k == 10)
                {
                    Console.Write("{0}", pair.Key);
                    break;
                }
                else
                {
                    Console.Write("{0}, ", pair.Key);
                }
            }
            Console.WriteLine("");

            // Останавливаем секундомер
            time.Stop();

            // Выводим в консоль время работы программы в миллисекундах
            Console.WriteLine(time.Elapsed.TotalMilliseconds);

            Console.ReadKey();
        }

        // Прочитать данные из файла
        static string ReadFile(string path)
        {
            // Создаем объект, который будет читать файл
            using (StreamReader sr = new StreamReader(path))
            {
                // Возвращаем все содержимое файла
                return sr.ReadToEnd();
            }
        }
    }
}