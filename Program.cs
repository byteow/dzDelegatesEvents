using StudentManagement;
using CollectionExtensions;
using FileManagement;
class Program
{
    static void Main()
    {
        // DELEGATE

        List<Student> students =
        [
            new() { Name = "Дмитрий", Score = 75 },
            new() { Name = "Евпатий", Score = 92 },
            new() { Name = "Кирилл", Score = 88 }
        ];

        Student bestStudent = students.GetMax(x => x.Score);

        Console.WriteLine("Максимальный результат:");
        Console.WriteLine($"{bestStudent.Name} — {bestStudent.Score}");


        // EVENTS

        Console.WriteLine("\nПоиск файлов:");

        FileSearcher searcher = new();

        searcher.FileFound += OnFileFound;
        searcher.Search(Environment.CurrentDirectory);
        searcher.FileFound -= OnFileFound;

        Console.WriteLine("Программа завершена.");
    }

    static void OnFileFound(object sender, FileArgs e)
    {
        Console.WriteLine($"Найден файл: {e.FileName}");

        if (e.FileName.Contains("stop.txt"))
        {
            ((FileSearcher)sender).Cancel = true;
            Console.WriteLine("Выполнено условие для отмены дальнейшего поиска");
        }
    }
}
