using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Введiть шлях до каталогу: ");
        string directoryPath = Console.ReadLine();
        long totalSize = GetDirectorySize(directoryPath);

        Console.WriteLine($"Об'єм файлiв у каталозi: {FormatBytes(totalSize)}");
        Console.ReadLine();
    }

    static long GetDirectorySize(string path)
    {
        long totalSize = 0;

        try
        {
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                totalSize += fileInfo.Length;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка!: {ex.Message}");
        }

        return totalSize;
    }

    static string FormatBytes(long bytes)
    {
        const int scale = 1024;
        string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB" };
        int i = 0;
        decimal number = (decimal)bytes;

        while (Math.Round(number / scale) >= 1 && i < sizeSuffixes.Length - 1)
        {
            number /= scale;
            i++;
        }

        return string.Format("{0} {1}", Math.Round(number, 2), sizeSuffixes[i]);
    }
}