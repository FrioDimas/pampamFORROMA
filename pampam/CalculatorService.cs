using System.Diagnostics;

namespace pampam
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class CalculatorService
    {
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
