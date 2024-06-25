using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть диск для пошуку:");
        string disk = Console.ReadLine();
        Console.WriteLine("Введіть назву файлу або маску для пошуку:");
        string mask = Console.ReadLine();

        DirectoryInfo root = new DirectoryInfo(disk);
        try
        {
            SearchFiles(root, mask);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }

    public static void SearchFiles(DirectoryInfo rootDirectory, string mask)
    {
        foreach (DirectoryInfo directory in rootDirectory.GetDirectories())
        {
            SearchFiles(directory, mask);
        }

        var files = Directory.EnumerateFiles(rootDirectory.FullName, mask, SearchOption.TopDirectoryOnly);
        foreach (var file in files)
        {
            Console.WriteLine($"Знайдено файл: {file}");

            // Відкриття і перегляд вмісту файлу через FileStream
            ViewFileContents(file);

            // Стиснення знайденого файлу
            CompressFile(file);
        }
    }

    public static void ViewFileContents(string filePath)
    {
        try
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    Console.WriteLine($"Вміст файлу '{filePath}':");
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при читанні файлу '{filePath}': {ex.Message}");
        }
    }

    public static void CompressFile(string filePath)
    {
        try
        {
            string zipPath = Path.ChangeExtension(filePath, ".zip");

            // Стиснення файлу
            ZipFile.CreateFromDirectory(Path.GetDirectoryName(filePath), zipPath);

            Console.WriteLine($"Файл '{filePath}' був стиснений і збережений як '{zipPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при стисканні файлу '{filePath}': {ex.Message}");
        }
    }
}