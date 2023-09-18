namespace PamPam
{
    public class ResultOfExpression
    {
        public List<string> Outcome { get; }

        public ResultOfExpression(List<string> outcome)
        {
            Outcome = outcome;
        }
        public ResultOfExpression()
        {
            Outcome = new List<string>();
        }
    }
}
