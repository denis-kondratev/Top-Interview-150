/*
 * S14. Longest Common Prefix
 * https://leetcode.com/problems/longest-common-prefix/?envType=study-plan-v2&envId=top-interview-150
 *
 * Write a function to find the longest common prefix string amongst an array of strings.
 * If there is no common prefix, return an empty string "".
 *
 * Example 1:
 *   Input: strs = ["flower","flow","flight"]
 *   Output: "fl"
 *
 * Example 2:
 *   Input: strs = ["dog","racecar","car"]
 *   Output: ""
 *   Explanation: There is no common prefix among the input strings.
 *
 * Constraints:
 *   1 <= strs.length <= 200
 *   0 <= strs[i].length <= 200
 *   strs[i] consists of only lowercase English letters.
 */

using System.Text;

Console.WriteLine("Hello, World!");

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var builder = new StringBuilder();

        for (var i = 0; i < strs[0].Length; i++)
        {
            var c = strs[0][i];
            var isMatch = true;

            for (var j = 1; j < strs.Length; j++)
            {
                if (i >= strs[j].Length || strs[j][i] != c)
                {
                    isMatch = false;
                    break;
                }
            }

            if (!isMatch)
            {
                break;
            }

            builder.Append(c);
        }

        return builder.ToString();
    }
}