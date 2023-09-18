using PamPam;

namespace pampam
{
    public static class Calculator
    {
        private enum CalculatorMode
        {
            Console = 1,
            File = 2
        }

        private static CalculatorMode GetCalculatorMode()
        {
            if (!byte.TryParse(Console.ReadLine(), out byte mode))
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Invalid input. Please enter 1 or 2.");
                Console.ResetColor();

                return GetCalculatorMode();
            }
            else
            {
                return (CalculatorMode)mode;
            }
        }

        public static async void Starter(string[] args)
        {
            Console.WriteLine("Calculator features: Can perform simple math operations like +, -, /, *, and use parentheses.");
            Console.WriteLine("Choose calculator mode (Enter 1 for console, 2 for file):");

            Calculator.CalculatorMode mode = Calculator.GetCalculatorMode();

            bool restart = true;
            while (restart)
            {
                switch (mode)
                {
                    case Calculator.CalculatorMode.Console:
                        Console.WriteLine();
                        restart = Calculator.FirstMode();
                        break;
                    case Calculator.CalculatorMode.File:
                        restart = false;
                        await Calculator.SecondMode(args);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid mode. Please enter 1 or 2.");
                        Console.ResetColor();
                        mode = Calculator.GetCalculatorMode();
                        break;
                }
            }
        }

        private static bool FirstMode()
        {
            Console.Write("Enter an arithmetic expression: ");

            string input = Console.ReadLine()!;

            try
            {
                string postfix = InfToPost.InfixToPostfix(input);

                ResultOfExpression result = PostfixCalculator.EvaluatePostfixExpression(postfix);

                result.PrintingFirstMode(input);

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("Do you want to enter another expression? (Y/N)");
            string finish = Console.ReadLine()?.ToLower()!;
            return finish == "y";
        }

        private static async Task SecondMode(string[] args)
        {
            string filePath;

            if (args.Length > 0)
            {
                filePath = args[0];
            }
            else
            {
                Console.WriteLine("Specify the file path as a command line argument or enter it here:");

                filePath = new FileInput().GetFilePath();
            }

            ResultOfExpression result = new ResultOfExpression();

            FileParser parser = new FileParser(filePath);
            List<string> parsedLines = parser.Parse();

            Console.WriteLine("output");

            List<string> outcomeList = new List<string>();

            for (int i = 0; i < parsedLines.Count; i++)
            {
                string postfix = InfToPost.InfixToPostfix(parsedLines[i]);
                result = PostfixCalculator.EvaluatePostfixExpression(postfix);

                foreach (var token in result.Outcome)
                {
                    outcomeList.Add(token);
                }
            }

            await result.ImplementationSecondMode(parsedLines, outcomeList);
        }
    }
}
