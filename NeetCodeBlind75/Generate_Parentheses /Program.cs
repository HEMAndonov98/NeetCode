using System.Text;

namespace Generate_Parentheses;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine(String.Join(" " ,GenerateParenthesis(3)));
        
         List<string> GenerateParenthesis(int n) {
            List<string> result = new List<string>();
            Backtrack(0, 0 , n, "", result);
            return result;
        }

        void Backtrack(int left, int right, int n, string parenthesis, List<string> result)
        {
            if (left == n && right == n)
            {
                result.Add(parenthesis);
                return;
            }

            if (left < n)
            { 
                Backtrack(left + 1, right, n, parenthesis + "(", result);
            }

            if (right < left)
            {
                Backtrack(left, right + 1, n, parenthesis + ")", result);
            }

        }
    }
}
