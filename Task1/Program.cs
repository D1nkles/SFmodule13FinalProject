using System.Diagnostics;

class Program 
{
    static void Main(string[] args) 
    {
        using FileStream fileStream = new FileStream("C:\\Users\\Dinkles\\Downloads\\Text1.txt", FileMode.Open);
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
            for (int i = 0; i < characterArr.Length ; i++) 
            {
                listTest.Add(characterArr[i]);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            for (int i = 0; i < characterArr.Length; i++)
            {
                linkedListTest.AddLast(characterArr[i]);
            }
            sw.Stop();

            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }
    }
}