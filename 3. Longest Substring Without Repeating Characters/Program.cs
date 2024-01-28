/*
 * 3. Longest Substring Without Repeating Characters
 * https://leetcode.com/problems/longest-substring-without-repeating-characters/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given a string s, find the length of the longest substring without repeating characters.
 *
 * Example 1:
 *   Input: s = "abcabcbb"
 *   Output: 3
 *   Explanation: The answer is "abc", with the length of 3.
 *
 * Example 2:
 *   Input: s = "bbbbb"
 *   Output: 1
 *   Explanation: The answer is "b", with the length of 1.
 *
 * Example 3:
 *  Input: s = "pwwkew"
 *  Output: 3
 *  Explanation: The answer is "wke", with the length of 3.
 *  Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 *
 * Constraints:
 *   0 <= s.length <= 5 * 10^4
 *   s consists of English letters, digits, symbols and spaces.
 */

Console.WriteLine("Hello, World!");

public class Solution 
{
    public int LengthOfLongestSubstring(string s)
    {
        int left = -1, max = 0;
        var map = new Dictionary<char, int>();
        
        for (var right = 0; right < s.Length; right++)
        {
            var isRepeated = map.TryGetValue(s[right], out var last) && last >= left;
            map[s[right]] = right;
            
            if (isRepeated)
            {
                left = last + 1;
            }
            else
            {
                max = Math.Max(max, right - left);
            }
        }
        
        return max;
    }
}

// public class Solution 
// {
//     public int LengthOfLongestSubstring(string s)
//     {
//         int left = 0, max = 0;
//         HashSet<char> sequence = new(26);
//         
//         for (var right = 0; right < s.Length; right++)
//         {
//             if (!sequence.Add(s[right]))
//             {
//                 while (s[left] != s[right])
//                 {
//                     sequence.Remove(s[left++]);
//                 }
//
//                 left++;
//             }
//
//             max = Math.Max(max, sequence.Count);
//         }
//         
//         return max;
//     }
// }