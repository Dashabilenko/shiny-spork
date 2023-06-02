using System;
using System.IO;

class Program
{
    static void ChangeCreationDateTime(string directoryPath)
    {
        try
        {
            DateTime newCreationDateTime = new DateTime(2000, 12, 1, 0, 0, 0);

            string[] files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                File.SetCreationTime(file, newCreationDateTime);
                File.SetLastWriteTime(file, newCreationDateTime);
                File.SetLastAccessTime(file, newCreationDateTime);
                Console.WriteLine($"Изменена дата и время создания файла: {file}");
            }

            Console.WriteLine($"Изменение даты и времени создания файлов в директории {directoryPath} завершено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при изменении даты и времени создания файлов: {ex.Message}");
            Environment.ExitCode = 1; // Устанавливаем код завершения в 1 в случае ошибки
        }
    }

    static void Main()
    {
        Console.WriteLine("Введите путь к директории:");

        string directoryPath = Console.ReadLine();

        if (directoryPath.Length < 1)
        {
            Console.WriteLine("Не указан путь к директории.");
            Environment.ExitCode = 1; // Устанавливаем код завершения в 1 в случае ошибки
            return;
        }

        ChangeCreationDateTime(directoryPath);

        Console.ReadLine();
    }
}
