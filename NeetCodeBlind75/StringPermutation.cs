public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {

        if (s1.Length > s2.Length)
            return false;

        Dictionary<char, int> s1Count = new Dictionary<char, int>();
        Dictionary<char, int> s2Count = new Dictionary<char, int>();
        foreach (char c in s1)
        {
            if (s1Count.ContainsKey(c))
                s1Count[c]++;
            else
                s1Count[c] = 1;
        }

        for (int i = 0; i < s2.Length; i++)
        {
            int match = 0;
            for (int j = i; j < s2.Length; j++)
            {
                char c = s2[j];
                if (s2Count.ContainsKey(c))
                {
                    s2Count[c]++;
                }
                else
                {
                    s2Count[c] = 1;
                }

                if (!s1Count.ContainsKey(c) || s1Count[c] < s2Count[c])
                {
                    s2Count.Clear();
                    break;
                }

                if (s1Count[c] == s2Count[c])
                {
                    match++;
                }

                if (match == s1Count.Count())
                {
                    return true;
                }
            }
        }
        return false;
    }
}

