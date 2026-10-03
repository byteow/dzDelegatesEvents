namespace FileManagement;

public class FileSearcher
{
    public event EventHandler<FileArgs> FileFound = null!;

    public bool Cancel { get; set; }

    public void Search(string directory)
    {
        foreach (string file in Directory.GetFiles(directory))
        {
            FileFound?.Invoke(this, new FileArgs(file));

            if (Cancel)
            {
                Console.WriteLine("Поиск остановлен.");
                return;
            }
        }

        foreach (string subDirectory in Directory.GetDirectories(directory))
        {
            if (Cancel)
                return;

            Search(subDirectory);
        }
    }
}
