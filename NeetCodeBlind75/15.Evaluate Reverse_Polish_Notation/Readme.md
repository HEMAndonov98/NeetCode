Here’s the documentation in Markdown format for the `EvalRPN` solution to the "Evaluate Reverse Polish Notation" problem:

---

# Evaluate Reverse Polish Notation

## Problem Description

In Reverse Polish Notation (RPN), operators follow their operands. For example, to add the numbers `2` and `1`, we would write `2 1 +`, which evaluates to `3`. Given an array of strings `tokens` that represent an expression in RPN, implement an evaluator function that computes the result of the expression. The valid operators are `+`, `-`, `*`, and `/`. Each operand can be an integer or another expression.

The problem guarantees that the RPN expression is always valid and the division is integer division, which truncates toward zero.

### Example
Input:
```csharp
string[] tokens = {"1", "2", "+", "3", "*", "4", "-"};
Console.WriteLine(EvalRPN(tokens));
```

Output:
```
5
```

---

## Solution Overview

### Approach

This solution leverages a stack to evaluate the expression in a single pass. As we iterate through each token:
- **If the token is an operand (integer)**, we push it onto the stack.
- **If the token is an operator (`+`, `-`, `*`, `/`)**, we pop the top two elements from the stack (these are the operands for the operation), apply the operator, and push the result back onto the stack.

At the end of the iteration, the stack will contain only one element: the result of the entire RPN expression.

### Code

```csharp
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
                    operands.Push(operand1 + operand2);
                    break;
                case "-":
                    operands.Push(operand1 - operand2);
                    break;
                case "*":
                    operands.Push(operand1 * operand2);
                    break;
                case "/":
                    operands.Push(operand1 / operand2);
                    break;
            }
        }
        else
        {
            operands.Push(int.Parse(currentToken));
        }
    }
    return operands.Pop();
}
```

### Explanation of the Code

1. **Initialize a Stack**: We use a `Stack<int>` to store operands as they are encountered.
2. **Iterate through Tokens**: For each token in the input array:
    - **Check if it is an operator**:
        - If so, pop the top two elements from the stack (`operand2` and `operand1`), apply the operation, and push the result back onto the stack.
    - **If it is a number**:
        - Parse the string as an integer and push it onto the stack.
3. **Return the Result**: After the loop, the stack will contain the single final result of the expression, which is then returned.

### Complexity Analysis

- **Time Complexity**: \(O(n)\), where \(n\) is the number of tokens. We process each token once.
- **Space Complexity**: \(O(n)\), due to the stack storage for operands.

### Example Walkthrough

Consider `tokens = {"1", "2", "+", "3", "*", "4", "-"}`:

1. **Push 1** onto the stack → Stack: `[1]`
2. **Push 2** onto the stack → Stack: `[1, 2]`
3. **Encounter '+'**: Pop `2` and `1`, compute `1 + 2 = 3`, push `3` → Stack: `[3]`
4. **Push 3** onto the stack → Stack: `[3, 3]`
5. **Encounter '*'**: Pop `3` and `3`, compute `3 * 3 = 9`, push `9` → Stack: `[9]`
6. **Push 4** onto the stack → Stack: `[9, 4]`
7. **Encounter '-'**: Pop `4` and `9`, compute `9 - 4 = 5`, push `5` → Stack: `[5]`

The result is `5`.
