using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;

class task4
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть дані для збереження:");
        string data = Console.ReadLine();

        // Зберігання даних у ізольованому сховищі
        SaveDataToIsolatedStorage("myData.txt", data);

        Console.WriteLine("\nДані було збережено. Тепер введіть 'read', щоб прочитати дані:");
        string input = Console.ReadLine();

        if (input.Trim().ToLower() == "read")
        {
            // Читання даних з ізольованого сховища
            string savedData = ReadDataFromIsolatedStorage("myData.txt");
            Console.WriteLine($"\nПрочитані дані з ізольованого сховища:\n{savedData}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }

    static void SaveDataToIsolatedStorage(string fileName, string data)
    {
        // Отримуємо ізольоване сховище для поточного користувача на локальній машині
        using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
        {
            // Створюємо файл у ізольованому сховищі
            using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(fileName, FileMode.Create, isolatedStorage))
            {
                // Записуємо дані у файл
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(data);
                }
            }
        }
    }

    static string ReadDataFromIsolatedStorage(string fileName)
    {
        string data = string.Empty;

        // Отримуємо ізольоване сховище для поточного користувача на локальній машині
        using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
        {
            // Перевіряємо, чи існує файл у ізольованому сховищі
            if (isolatedStorage.FileExists(fileName))
            {
                // Відкриваємо файл для читання
                using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(fileName, FileMode.Open, isolatedStorage))
                {
                    // Читаємо дані з файлу
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        data = reader.ReadToEnd();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Файл '{fileName}' не знайдено в ізольованому сховищі.");
            }
        }

        return data;
    }
}