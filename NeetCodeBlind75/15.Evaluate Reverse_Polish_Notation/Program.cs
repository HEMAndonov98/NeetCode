int EvalRPN(string[] tokens)
{
    Stack<int> operands = new Stack<int>();

    for (int i = 0; i < tokens.Length; i++)
    {
        string currentToken = tokens[i];

        if (currentToken == "+" || currentToken == "-" || currentToken == "*" || currentToken == "/")
        {
            int operand2 = operands.Pop();
            int operand1 = operands.Pop();

            switch (currentToken)
            {
                case "+":
                {
                    operands.Push(operand1 + operand2);
                    break;
                }          
                case "-":
                {
                    operands.Push(operand1 - operand2);
                    break;
                }          
                case "*":
                {
                    
                    operands.Push(operand1 * operand2);
                    break;
                }          
                case "/":
                {
                    operands.Push(operand1 / operand2);
                    break;
                }
            }
        }
        else
        {
            operands.Push(int.Parse(currentToken));
        }
    }
    return operands.Pop();
}

string[] tokens = {"1", "2", "+", "3", "*", "4", "-"};
Console.WriteLine(EvalRPN(tokens));
