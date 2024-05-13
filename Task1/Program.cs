using System.Diagnostics;

class Program 
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь до текста: ");
        string PATH = Console.ReadLine();
        if (!string.IsNullOrEmpty(PATH) && File.Exists(PATH))
        {
            List<char> characterArr = new List<char>();

            StreamReader sr = new StreamReader(PATH);

            do
            {
                characterArr.Add((char)sr.Read());

            }
            while (!sr.EndOfStream);

            List<char> listTest = new List<char>();
            LinkedList<char> linkedListTest = new LinkedList<char>();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < characterArr.Count; i++)
            {
                listTest.Add(characterArr[i]);
            }
            sw.Stop();
            Console.WriteLine("Время добавления в эл-ов в List: " + sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            for (int i = 0; i < characterArr.Count; i++)
            {
                linkedListTest.AddLast(characterArr[i]);
            }
            sw.Stop();

            Console.WriteLine("Время добавления в эл-ов в LinkedList: " + sw.Elapsed.TotalMilliseconds);
        }
    }
}