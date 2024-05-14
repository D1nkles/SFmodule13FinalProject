using System.IO;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        List<char> characters = new List<char>();
        List<string> words = new List<string>();
        HashSet<string> uniqueWords = new HashSet<string>();
        Dictionary<string, int> wordsStat = new Dictionary<string, int>();

        Console.Write("Введите путь до текста: ");
        string PATH = Console.ReadLine();

        if (!string.IsNullOrEmpty(PATH) && File.Exists(PATH))
        {
            StreamReader sr = new StreamReader(PATH);
            do
            {
                char character = (char)sr.Read();

                if (!char.IsPunctuation(character) && !char.IsNumber(character) &&
                    character != 'I' && character != 'V' && character != 'X' &&
                    character != ' ')
                {
                    characters.Add(character);
                }

                else
                {
                    if (characters.Count > 0)
                    {
                        string word = "";
                        foreach (char chr in characters)
                        {
                            word += chr;
                        }

                        word = word.Replace("\n", "");

                        if (!string.IsNullOrWhiteSpace(word))
                        {
                            words.Add(word.ToLower());
                        }

                        characters.Clear();
                    }
                }
            }
            while (!sr.EndOfStream);

            uniqueWords = new HashSet<string>(words);

            foreach (string uniqueWord in uniqueWords)
            {
                int wordCount = 0;
                foreach (string wrd in words)
                {
                    if (uniqueWord == wrd)
                    {
                        wordCount++;
                    }
                }
                wordsStat.Add(uniqueWord, wordCount);
            }

            Dictionary<string, int> sorted = new Dictionary<string, int>();
            int counter = 1;

            sorted = wordsStat.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            Console.WriteLine("10 слов, которые встречаются в тексте чаще всего:");

            foreach (KeyValuePair<string, int> word in sorted)
            {
                if (counter <= 10)
                {
                    Console.WriteLine($"{counter}. {word.Key}");
                    counter++;
                }
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы закрыть программу...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Ошибка: файла по такому пути нет, или вы ввели пустое знаечние!!!\n" +
                              "Нажмите любую клавишу, чтобы закрыть программу...");
            Console.ReadKey();
        }
    }
}