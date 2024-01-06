/*
 * 28. Find the Index of the First Occurrence in a String
 * https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/description/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given two strings needle and haystack, return the index of the first occurrence of needle in haystack,
 * or -1 if needle is not part of haystack.
 *
 * Example 1:
 *   Input: haystack = "sadbutsad", needle = "sad"
 *   Output: 0
 *   Explanation: "sad" occurs at index 0 and 6.
 *   The first occurrence is at index 0, so we return 0.
 *
 * Example 2:
 *   Input: haystack = "leetcode", needle = "leeto"
 *   Output: -1
 *   Explanation: "leeto" did not occur in "leetcode", so we return -1.
 *
 * Constraints:
 *   1 <= haystack.length, needle.length <= 10^4
 *   haystack and needle consist of only lowercase English characters.
 */

var solution = new Solution();
Console.WriteLine(solution.StrStr("mississippi", "issi"));

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        for (var i = 0; haystack.Length - i >= needle.Length; i++)
        {
            int j = 0, k = i;
            
            for (; j < needle.Length; j++)
            {
                if (needle[j] != haystack[k++]) break;
            }

            if (j == needle.Length) return i;
        }

        return -1;   
    }
}