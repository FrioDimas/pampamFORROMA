namespace FileInputTest
{
    [TestClass]
    public class TestInput
    {
        public class ConsoleInputSimulator : IDisposable
        {
            private readonly TextReader originalInput;
            private readonly TextWriter originalOutput;
            private readonly StringWriter inputSimulator;

            public ConsoleInputSimulator(params string[] inputLines)
            {
                originalInput = Console.In;
                originalOutput = Console.Out;
                inputSimulator = new StringWriter();

                foreach (var line in inputLines)
                {
                    inputSimulator.WriteLine(line);
                }

                inputSimulator.Flush();
            }

            public void Dispose()
            {
                Console.SetIn(originalInput);
                Console.SetOut(originalOutput);
            }

            public static ConsoleInputSimulator Create(params string[] inputLines)
            {
                return new ConsoleInputSimulator(inputLines);
            }

            public static implicit operator ConsoleInputSimulator(string[] inputLines)
            {
                return Create(inputLines);
            }

            public void Disposes()
            {
                Console.SetIn(originalInput);
                Console.SetOut(originalOutput);
            }
        }
    }
}