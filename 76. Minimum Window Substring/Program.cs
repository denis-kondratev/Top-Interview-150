/*
 * 76. Minimum Window Substring
 * https://leetcode.com/problems/minimum-window-substring/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such
 * that every character in t (including duplicates) is included in the window. If there is no such substring,
 * return the empty string "". The testcases will be generated such that the answer is unique.
 *
 * Example 1:
 *   Input: s = "ADOBECODEBANC", t = "ABC"
 *   Output: "BANC"
 *   Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
 *
 * Example 2:
 *   Input: s = "a", t = "a"
 *   Output: "a"
 *   Explanation: The entire string s is the minimum window.
 *
 * Example 3:
 *   Input: s = "a", t = "aa"
 *   Output: ""
 *   Explanation: Both 'a's from t must be included in the window.
 *   Since the largest window of s only has one 'a', return empty string.
 *
 * Constraints:
 *   m == s.length
 *   n == t.length
 *   1 <= m, n <= 10^5
 *   s and t consist of uppercase and lowercase English letters.
 *
 * Follow up: Could you find an algorithm that runs in O(m + n) time?
 */

Console.WriteLine("Hello, World!");

public class Solution 
{
    public string MinWindow(string s, string t) 
    {
        var map = new int[128];

        foreach (var c in t)
        {
            map[c]++;
        }
        
        int left = 0, right = 0, counter = t.Length;
        var min = (left: -1, length: int.MaxValue);

        while (right < s.Length)
        {
            if (map[s[right]] > 0)
            {
                counter--;
            }

            --map[s[right++]];

            while (counter == 0)
            {
                if (min.length > right - left)
                {
                    min = (left, right - left);
                }
                
                if (++map[s[left++]] > 0)
                {
                    counter++;
                }
            }
        }
        
        return min.left >= 0 ? s.Substring(min.left, min.length) : "";
    }
}