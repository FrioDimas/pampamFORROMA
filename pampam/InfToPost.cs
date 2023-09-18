using System.Text;

namespace PamPam
{
    public static class InfToPost
    {
        private static int Priority(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }

        public static string InfixToPostfix(string exp)
        {
            string result = "";
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];

                if (char.IsDigit(c))
                {
                    StringBuilder number = new StringBuilder();
                    while (i < exp.Length && (char.IsDigit(exp[i]) || exp[i] == '.'))
                    {
                        number.Append(exp[i]);
                        i++;
                    }
                    result += number + " ";
                    i--;
                }

                else if (c == '(')
                {
                    stack.Push(c);
                }

                else if (c == ')')
                {
                    while (stack.Count > 0
                           && stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0
                        && stack.Peek() != '(')
                    {
                        return "Invalid Expression";
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else if (char.IsLetter(c))
                {
                    result += c;
                }
                else
                {
                    while (stack.Count > 0
                           && Priority(c) <= Priority(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
    }
}
