namespace PamPam;

public static class PostfixCalculator
{
    public static ResultOfExpression EvaluatePostfixExpression(string expression)
    {
        var results = new List<string>();
        Stack<double> stack = new Stack<double>();

        string currentToken = "";

        foreach (char token in expression)
        {
            if (IsOperator(token.ToString()) || token == ' ')
            {
                if (!string.IsNullOrWhiteSpace(currentToken))
                {
                    if (double.TryParse(currentToken, out double number))
                    {
                        stack.Push(number);
                    }
                    else
                    {
                        string invalidInput = "Exception. Wrong input";
                        results.Add(invalidInput);
                        return new ResultOfExpression(results);
                    }

                    currentToken = "";
                }

                if (IsOperator(token.ToString()))
                {
                    if (stack.Count < 2)
                    {
                        string absenseOperator = "Invalid expression: Not enough operands.";
                        results.Add(absenseOperator);
                        return new ResultOfExpression(results);
                    }
                    else
                    {
                        double operand2 = stack.Pop();
                        double operand1 = stack.Pop();
                        string result = ApplyOperator(token, operand1, operand2);

                        if (result == "cannot divide by zero")
                        {
                            results.Add("Exception. Divide by zero");
                            return new ResultOfExpression(results);
                        }

                        double res;

                        if (double.TryParse(result, out res))
                        {
                            stack.Push(res);
                        }
                        else
                        {
                            string invalidTok = "Exception. Wrong input";
                            results.Add(invalidTok);
                            return new ResultOfExpression(results);
                        }
                    }
                }
            }
            else
            {
                currentToken += token;
            }
        }

        if (!string.IsNullOrWhiteSpace(currentToken))
        {
            if (double.TryParse(currentToken, out double number))
            {
                stack.Push(number);
            }
            else
            {
                string invalidTok = "Exception. Wrong input";
                results.Add(invalidTok);
            }
        }

        if (stack.Count == 1)
        {
            string topElement = stack.Pop().ToString();
            results.Add(topElement);
        }
        else
        {
            string manyOperands = "Invalid expression: Too many operands.";
            results.Add(manyOperands);
        }

        return new ResultOfExpression(results);
    }

    private static bool IsOperator(string operatorToken)
    {
        return operatorToken == "+" || operatorToken == "-" || operatorToken == "*" || operatorToken == "/";
    }

    private static string ApplyOperator(char operatorToken, double operand1, double operand2)
    {
        switch (operatorToken)
        {
            case '+':
                string addition = (operand1 + operand2).ToString();
                return addition;
            case '-':
                string subtract = (operand1 - operand2).ToString();
                return subtract;
            case '*':
                string multipl = (operand1 * operand2).ToString();
                return multipl;
            case '/':
                if (operand2 != 0)
                {
                    string division = (operand1 / operand2).ToString();
                    return division;
                }
                else
                {
                    string zeroException = "cannot divide by zero";
                    return zeroException;
                }
            default:
                string def = "invalid expression";
                return def;
        }
    }
}
