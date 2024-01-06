/*
 * 6. Zigzag Conversion
 * https://leetcode.com/problems/zigzag-conversion/description/?envType=study-plan-v2&envId=top-interview-150
 *
 * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:
 * (you may want to display this pattern in a fixed font for better legibility)
 *   P   A   H   N
 *   A P L S I I G
 *   Y   I   R
 *
 * And then read line by line: "PAHNAPLSIIGYIR"
 *
 * Write the code that will take a string and make this conversion given a number of rows:
 *   string convert(string s, int numRows);
 *
 * Example 1:
 *   Input: s = "PAYPALISHIRING", numRows = 3
 *   Output: "PAHNAPLSIIGYIR"
 *
 * Example 2:
 *   Input: s = "PAYPALISHIRING", numRows = 4
 *   Output: "PINALSIGYAHRPI"
 *   Explanation:
 *     P     I    N
 *     A   L S  I G
 *     Y A   H R
 *     P     I
 *
 * Example 3:
 *   Input: s = "A", numRows = 1
 *   Output: "A"
 *
 * Constraints:
 *   1 <= s.length <= 1000
 *   s consists of English letters (lower-case and upper-case), ',' and '.'.
 *   1 <= numRows <= 1000
 */

var solution = new Solution();
Console.WriteLine(solution.Convert("PAYPALISHIRING", 3));

public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }

        return string.Create(s.Length, s, (zigzag, str) =>
        {
            var i = 0;
            
            for (var r = 0; r < numRows; r++)
            {
                var d1 = r < numRows - 1 ? (numRows - r - 1) * 2 : (numRows - 1) * 2;
                var d2 = r > 0 && r < numRows - 1 ? (numRows - 1) * 2 - d1 : d1;
                var j = r;

                while (j < str.Length)
                {
                    zigzag[i++] = str[j];
                    j += d1;
                    (d1, d2) = (d2, d1);
                }
            }
        });
    }
}