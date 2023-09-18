using PamPam;

namespace pampam
{
    public static class CalculatorModesImplementer
    {
        public static void PrintingFirstMode(this ResultOfExpression result, string input)
        {
            foreach (var item in result.Outcome)
            {
                Console.Write($"{input} --> {item}");
            }
        }

        public static async Task ImplementationSecondMode(this ResultOfExpression result, List<string> parsedLine, List<string> outcomeList)
        {
            string emptyFilePath = Path.GetFullPath("EmptyFile.txt");

            using (StreamWriter writer = new StreamWriter(emptyFilePath))
            {
                for (int j = 0; j < outcomeList.Count; j++)
                {
                    writer.WriteLine($"{parsedLine[j]} --> {outcomeList[j]}");
                }
            }

            using (StreamReader reader = new StreamReader(emptyFilePath))
            {
                string text = await reader.ReadToEndAsync();
                Console.WriteLine(text);
            }
        }
    }
}
