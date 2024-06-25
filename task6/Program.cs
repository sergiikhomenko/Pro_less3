namespace task6;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            Directory.CreateDirectory("Folder_" + i.ToString());
        }

        Console.WriteLine("перевір");
        Console.ReadLine();

        for (int i = 0; i < 100; i++)
        {
            Directory.Delete("Folder_" + i.ToString());
        }
        Console.WriteLine("перевір");
        Console.ReadLine();
    }
}