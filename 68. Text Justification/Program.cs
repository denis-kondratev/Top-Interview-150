/*
 * 68. Text Justification
 * https://leetcode.com/problems/text-justification/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth
 * characters and is fully (left and right) justified. You should pack your words in a greedy approach; that is,
 * pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly
 * maxWidth characters.
 *
 * Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line does not
 * divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.
 * For the last line of text, it should be left-justified, and no extra space is inserted between words.
 *
 * Note:
 *   - A word is defined as a character sequence consisting of non-space characters only.
 *   - Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
 *   - The input array words contains at least one word.
 *
 * Example 1:
 *   Input: words = ["This", "is", "an", "example", "of", "text", "justification."], maxWidth = 16
 *   Output:
 *   [
 *     "This    is    an",
 *     "example  of text",
 *     "justification.  "
 *   ]
 *
 * Example 2:
 *   Input: words = ["What","must","be","acknowledgment","shall","be"], maxWidth = 16
 *   Output:
 *   [
 *     "What   must   be",
 *     "acknowledgment  ",
 *     "shall be        "
 *   ]
 *   Explanation: Note that the last line is "shall be    " instead of "shall     be", because the last line must
 *                be left-justified instead of fully-justified. Note that the second line is also left-justified
 *                because it contains only one word.
 *
 * Example 3:
 *   Input: words = ["Science","is","what","we","understand","well","enough","to","explain","to",
 *                   "a","computer.","Art","is","everything","else","we","do"], maxWidth = 20
 *   Output:
 *   [
 *     "Science  is  what we",
 *     "understand      well",
 *     "enough to explain to",
 *     "a  computer.  Art is",
 *     "everything  else  we",
 *     "do                  "
 *   ]
 *
 * Constraints:
 *   1 <= words.length <= 300
 *   1 <= words[i].length <= 20
 *   words[i] consists of only English letters and symbols.
 *   1 <= maxWidth <= 100
 *   words[i].length <= maxWidth
 */

string[] words = ["This", "is", "an", "example", "of", "text", "justification."];
var solution = new Solution();
Console.WriteLine(solution.FullJustify(words, 16));

public class Solution 
{
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        var j = 0;
        var row = new char[maxWidth];
        var rows = new List<string>();

        while (j < words.Length)
        {
            var i = j;
            var length = words[j++].Length;

            while (j < words.Length && length + words[j].Length + 1 <= maxWidth)
            {
                length += words[j++].Length + 1;
            }

            var someWords = words.AsSpan(i, j - i);
            var spaceCount = maxWidth - length + someWords.Length - 1;
            
            if (j < words.Length && j - i > 1)
            {
                CreateRow(row, someWords, spaceCount);
            }
            else
            {
                CreateLastRow(row, someWords, spaceCount);
            }

            rows.Add(new string(row));
        }
        
        return rows;
    }

    private void CreateRow(char[] row, Span<string> words, int spaceCount)
    {
        var i = 0;
        var gapCount = words.Length - 1;
        var gapSize = spaceCount / gapCount;
        var bigGapCount = spaceCount % gapCount;

        for (var j = 0; j < words.Length; j++)
        {
            words[j].CopyTo(0, row, i, words[j].Length);
            i += words[j].Length;
            
            if (i == row.Length) break;

            var curGapSize = j < bigGapCount ? gapSize + 1 : gapSize;
            Array.Fill(row, ' ', i, curGapSize);
            i += curGapSize;
        }
    }
    
    private void CreateLastRow(char[] row, Span<string> words, int spaceCount)
    {
        var i = 0;
        
        for (var j = 0; j < words.Length; j++)
        {
            if (j > 0) row[i++] = ' ';
            
            words[j].CopyTo(0, row, i, words[j].Length);
            i += words[j].Length;
        }

        Array.Fill(row, ' ', i, row.Length - i);
    }
}