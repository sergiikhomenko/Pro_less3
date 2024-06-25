using System.IO;
using System.Net.Mime;


namespace task2;
/*
 * Створіть файл, запишіть у нього довільні дані та закрийте файл.
 * Потім знову відкрийте цей файл, прочитайте дані і виведіть їх на консоль.
 */

class Program
{
    static void Main(string[] args)
    {
        string path = "text.txt";
        WriteFile(path);
        ReadFile(path);
    }
    
    public static void WriteFile(string path)
    {
        using ( StreamWriter streamWriter =  new StreamWriter(path))
        {
            streamWriter.WriteLine("Test text");
            streamWriter.Close();
        }
    }
    public static void ReadFile(string path)
    {
        using ( StreamReader  streamReader = new StreamReader(path))
        {
            Console.WriteLine( streamReader.ReadToEnd());
            streamReader.Close();
        }
    }

}