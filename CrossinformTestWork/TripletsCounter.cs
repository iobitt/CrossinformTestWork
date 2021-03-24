using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossinformTestWork
{
    // Класс для подсчёта триплетов в массиве слов
    public class TripletsCounter
    {
        private ArraySegment<string> words;
        private Dictionary<string, int> triplets;
        private string name;

        public TripletsCounter(ArraySegment<string> words, Dictionary<string, int> triplets, string name)
        {
            this.words = words;
            this.triplets = new Dictionary<string, int>();
            this.name = name;
        }

        public Dictionary<string, int> GetTriplets()
        {
            return triplets;
        }

        // Посчитать триплеты в массиве слов
        public void Count()
        {
            Console.WriteLine("{0} начал работу", name);

            foreach (var word in words)
            {
                if (word.Length < 3)
                    continue;

                int index = 0;
                while (index <= word.Length - 3)
                {
                    string wordPart = word.Substring(index, 3);

                    if (triplets.ContainsKey(wordPart))
                        triplets[wordPart]++;
                    else
                        triplets[wordPart] = 1;

                    index++;
                }
            }

            Console.WriteLine("{0} завершил работу", name);
        }
    }
}