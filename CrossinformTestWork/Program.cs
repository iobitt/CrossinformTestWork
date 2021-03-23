using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // класс Stopwatch
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;


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
            string path = "data/avidreaders.ru__prestuplenie-i-nakazanie-dr-izd.txt";

            string text;
            try
            {
                // Получаем весь текст из файла
                text = ReadFile(path).ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            time.Start();

            Regex regex = new Regex(@"[а-я]{3}");
            MatchCollection words = regex.Matches(text);

            //string[] words = matches.Cast<Match>().ToArray();
            //string[] words = matches.Cast<Match>().Select(m => m.Value).ToArray();

            // Отчищаем текст от лишних символов
            //text = ClearText(text);

            //// Разбиваем текст на слова
            //string[] words = text.Split(' ');

            //// Удаляем слова, длина которых меньше 3х букв
            //List<string> wordsList = new List<string>();
            //for (int i = 0; i < words.Length; i++)
            //{
            //    if (words[i].Length >= 3)
            //        wordsList.Add(words[i]);
            //}

            //// Преобразуем список обратно в массив
            //words = wordsList.ToArray();
            //wordsList = null;

            //string[] words = text.Split(' ');

            // Создаём словарь, для хранения частоты встречаемсости триплетов
            Dictionary<string, int> triplets = new Dictionary<string, int>();

            // Подсчёт частоты встречаемости триплетов
            foreach (var word in words)
            {
                int index = 0;
                string word2 = word.ToString();
                while (index <= word2.Length - 3)
                {
                    string wordPart = word2.Substring(index, 3);

                    // Увеличение счетчика
                    if (triplets.ContainsKey(wordPart))
                    {
                        triplets[wordPart]++;
                    } 
                    else
                    {
                        triplets[wordPart] = 1;
                    }
                    index++;
                }
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

        // Отчистить текст от символов перевода строки и символов пунктуации
        static string ClearText(string text)
        {
            
            text = text.ToLower();
            text = text.Replace("-", " ");

            // Удаление всех знаков препинания
            text = Regex.Replace(text, @"[\.\,\:\;\!\?«»*–…\[\]()\d\n\r]", "");

            text = text.Replace(" - ", "");

            return text;
        }
    }
}