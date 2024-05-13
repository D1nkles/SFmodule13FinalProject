using System.Diagnostics;

class Program 
{
    static void Main(string[] args) 
    {
        Console.WriteLine("Введите путь до текста: ");
        string PATH = Console.ReadLine();
        if (!string.IsNullOrEmpty(PATH) && File.Exists(PATH)) 
        {
            using FileStream fileStream = new FileStream(PATH, FileMode.Open);
            {
                char[] characterArr = new char[fileStream.Length];

                while (fileStream.Position < fileStream.Length)
                {
                    StreamReader sr = new StreamReader(fileStream);

                    characterArr[fileStream.Position] = (char)sr.Read();
                }

                List<char> listTest = new List<char>();
                LinkedList<char> linkedListTest = new LinkedList<char>();

                Stopwatch sw = new Stopwatch();

                sw.Start();
                for (int i = 0; i < characterArr.Length; i++)
                {
                    listTest.Add(characterArr[i]);
                }
                sw.Stop();
                Console.WriteLine("Время добавления в эл-ов в List: " + sw.Elapsed.TotalMilliseconds);

                sw.Restart();
                for (int i = 0; i < characterArr.Length; i++)
                {
                    linkedListTest.AddLast(characterArr[i]);
                }
                sw.Stop();

                Console.WriteLine("Время добавления в эл-ов в LinkedList: " + sw.Elapsed.TotalMilliseconds);
            }
        }
    }
}