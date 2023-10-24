var sol = new Solution();
string s = "(){}}{";
Console.WriteLine(sol.IsValid(s));

public class Solution {
    public bool IsValid(string s) {
        Stack<char> parentheses = new Stack<char>();
        
        Dictionary<char, char> backTrackMap = new Dictionary<char, char>();
        //Populate the map with the needed parentheses this will be used instead of a switch to make the whole operation o(1)
        backTrackMap[')'] = '(';
        backTrackMap[']'] = '[';
        backTrackMap['}'] = '{';
        
        
        string progressString = "([{";
        
        //Edge Case
        if (s[0] == ')' || s[0] == ']' || s[0] == '}')
        {
            return false;
        }

        for (int i = 0; i < s.Length; i++)
        {
            char currentChar = s[i];

            //If is opening parentheses add to the stack
            if (progressString.Contains(currentChar))
            {
                parentheses.Push(currentChar);
                continue;
            }

            //if closing parentheses is the same like the last opening one we remove from the stack
            if (parentheses.Count > 0 && parentheses.Peek() == backTrackMap[currentChar])
            {
                parentheses.Pop();
                continue;
            }

            return false;
        }

        //If the stack is empty it is balanced
        return parentheses.Count == 0 ? true : false;
    }
}