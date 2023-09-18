public class FileParser
{
    private readonly string _filePath;

    public FileParser(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException(nameof(filePath));
        }

        _filePath = filePath;
    }

    public List<string> Parse()
    {
        int lineNumber = 1;
        var lines = new List<string>();

        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("The file does not exist.");
            }
            else
            {
                string[] fileLines = File.ReadAllLines(_filePath);

                foreach (string line in fileLines)
                {
                    lines.Add(line);
                    lineNumber++;
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error while reading the file: {ex.Message}");
        }

        return lines;
    }
}