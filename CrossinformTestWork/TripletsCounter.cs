using System;
using System.Collections.Generic;

namespace CrossinformTestWork
{
    // Класс для подсчёта триплетов в массиве слов
    public class TripletsCounter
    {
        // Границы фрагмента массива слов
        private ArraySegment<string> words;
        // Словарь частоты встречаемости триплетов
        private Dictionary<string, int> triplets;

        public TripletsCounter(ArraySegment<string> words)
        {
            this.words = words;
            this.triplets = new Dictionary<string, int>();
        }

        public Dictionary<string, int> GetTriplets()
        {
            return triplets;
        }

        // Посчитать триплеты в массиве слов
        public void Count()
        {
            // Проходим по массиву слов
            foreach (var word in words)
            {
                // Проходим по всем триплетам слова
                // Для слов, длина которых меньше 3, цикл выполняться не будет
                int index = 0;
                while (index <= word.Length - 3)
                {
                    // Вырезаем триплет из слова
                    string wordPart = word.Substring(index, 3);
                    
                    // Увеличиваем счетчик встречаемости триплета
                    // Если счетчика нет, создаем его
                    if (triplets.ContainsKey(wordPart))
                        triplets[wordPart]++;
                    else
                        triplets[wordPart] = 1;

                    index++;
                }
            }
        }
    }
}