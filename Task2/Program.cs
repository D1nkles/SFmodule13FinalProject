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
            }
        }
    }
}