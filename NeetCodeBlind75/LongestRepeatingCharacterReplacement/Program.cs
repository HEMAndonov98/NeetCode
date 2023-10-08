// See https://aka.ms/new-console-template for more information

//Time Complexity using Sliding Window Technique is O(N) 
var solution = new Solution();

Console.WriteLine($"CASE 1: s = AABABBA, k = 1 \n Expected: 4, Result: {solution.CharacterReplacement("AABABBA", 1)}");
Console.WriteLine($"CASE 2: s = ABAB, k = 2 \n Expected: 4, Result: {solution.CharacterReplacement("ABAB", 2)}");


public class Solution {
    public int CharacterReplacement(string s, int k) {
       
        int res = 0, maxF = 0, l = 0;
        //Map brings down table lookup to O(1)
        Dictionary<char, int> map = new Dictionary<char, int>();

        //Iterate through entire string
        for(int r = 0; r < s.Length; r++){
           
            //Add Character to the map and increment the number of times it is repeated in the current window
            if(!map.ContainsKey(s[r])){
                map[s[r]] = 0;
            }

            map[s[r]]++;
            //MaxF will just improve our while loop by making the check a constant time operation
            maxF = Math.Max(maxF, map[s[r]]);

            //Check determines if our window minus the most repeated character in it
            //is bigger than the number of replacements we can make
            if(r - l + 1 - maxF > k){
                //decrement window start character count
                map[s[l]]--;
                //slide the window(shorten it from the left-hand side)
                l++;
            }
            //Check if our current window is bigger than our previous window
            res = Math.Max(res, r - l + 1);
        } 
        return res;
    }
}