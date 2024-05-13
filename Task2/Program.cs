using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        using FileStream fileStream = new FileStream("C:\\Users\\Dinkles\\Downloads\\Text1.txt", FileMode.Open);
        {
            List<char> characters = new List<char>();
            List<string> words = new List<string>();
            HashSet<string> uniqueWords = new HashSet<string>();
            Dictionary<string, int> wordsStat = new Dictionary<string, int>();

            while (fileStream.Position < fileStream.Length)
            {
                StreamReader sr = new StreamReader(fileStream);
                char character = (char)sr.Read();
                
                if (!char.IsPunctuation(character) && !char.IsNumber(character) &&
                    character != 'I' && character != 'V' && character != 'X') 
                {
                    characters.Add(character);
                }

                else 
                {
                    if (characters.Count > 0) 
                    {
                        string word = characters.ToString();
                        words.Add(word);
                        characters.Clear();
                    }
                }
            }

            uniqueWords = new HashSet<string>(words);

            foreach(string uniqueWord in uniqueWords) 
            {
                int wordCount = 0;
                foreach(string wrd in words) 
                {
                    if (uniqueWord == wrd) 
                    {
                        wordCount++;
                    }
                }
                wordsStat.Add(uniqueWord, wordCount);
            }

        }
    }
}