namespace PamPam
{
    public interface IFileInput
    {
        protected string GetFilePath();
    }
     public class FileInput : IFileInput
    {
        public string GetFilePath()
        {
            while (true)
            {
                Console.WriteLine("Enter file path : ");
                string input = Console.ReadLine()!;

                if (input == null)
                {
                    continue;
                }

                if (!File.Exists(input))
                {
                    Console.WriteLine("Invalid file path, please try enter correct file path! ");
                }
                else
                {
                    return input;
                }
            }
        }
    }
}
