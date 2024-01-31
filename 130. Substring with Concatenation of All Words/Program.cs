/*
 * 130. Substring with Concatenation of All Words
 * https://leetcode.com/problems/substring-with-concatenation-of-all-words/?envType=study-plan-v2&envId=top-interview-150
 *
 * You are given a string s and an array of strings words. All the strings of words are of the same length.
 * A concatenated substring in s is a substring that contains all the strings of any permutation of words concatenated.
 * For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd",
 * and "efcdab" are all concatenated strings. "acdbef" is not a concatenated substring because it is
 * not the concatenation of any permutation of words.
 *
 * Return the starting indices of all the concatenated substrings in s. You can return the answer in any order.
 *
 * Example 1:
 *   Input: s = "barfoothefoobarman", words = ["foo","bar"]
 *   Output: [0,9]
 *   Explanation: Since words.length == 2 and words[i].length == 3, the concatenated substring has to be of length 6.
 *                The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is
 *                a permutation of words. The substring starting at 9 is "foobar". It is the concatenation
 *                of ["foo","bar"] which is a permutation of words. The output order does not matter.
 *                Returning [9,0] is fine too.
 *
 * Example 2:
 *   Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
 *   Output: []
 *   Explanation: Since words.length == 4 and words[i].length == 4, the concatenated substring has to be of length 16.
 *                There is no substring of length 16 in s that is equal to the concatenation of any
 *                permutation of words. We return an empty array.
 *
 * Example 3:
 *   Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
 *   Output: [6,9,12]
 *   Explanation: Since words.length == 3 and words[i].length == 3, the concatenated substring has to be of length 9.
 *                The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"]
 *                which is a permutation of words. The substring starting at 9 is "barthefoo". It is the
 *                concatenation of ["bar","the","foo"] which is a permutation of words. The substring starting
 *                at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"] which is a permutation of words.
 *
 * Constraints:
 *   1 <= s.length <= 10^4
 *   1 <= words.length <= 5000
 *   1 <= words[i].length <= 30
 *   s and words[i] consist of lowercase English letters.
 */

string[] words = ["aa"];
var s = "aaaa";
var solution = new Solution();
Console.WriteLine(solution.FindSubstring(s, words));

public class Solution 
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        int wordCount = words.Length, wordLength = words[0].Length, lastIndex = s.Length - wordLength + 1;
        var map = CreateWordMap(words);
        var positions = new Positions();
        var result = new List<int>();
        
        for (var i = 0; i < wordLength; i++)
        {
            positions.Clear(i - wordLength);
            int left = -wordLength;

            for (var right = i; right < lastIndex; right += wordLength)
            {
                if (!map.TryGetValue(s.AsSubString(right, wordLength), out var value))
                {
                    left = right + wordLength;
                    continue;
                }

                var last = positions.RollPosition(value.word, value.count, right);

                if (last >= left)
                {
                    left = last + wordLength;
                }
            
                if ((right - left) / wordLength + 1 == wordCount)
                {
                    result.Add(left);
                    left += wordLength;
                }
            }
        }
        
        return result;
    }

    private static Dictionary<SubString, (string word, int count)> CreateWordMap(string[] words)
    {
        var map = new Dictionary<SubString, (string word, int count)>();
        
        foreach (var word in words)
        {
            var sub = word.AsSubString();
            
            if (map.TryGetValue(word.AsSubString(), out var value))
            {
                value.count += 1;
                map[sub] = value;
            }
            else
            {
                map.Add(sub, (word, 1));
            }
        }

        return map;
    }
}

public static class SubStringExtensions
{
    public static SubString AsSubString(this string source, int firstIndex, int length)
    {
        return new SubString(source, firstIndex, length);
    }
    
    public static SubString AsSubString(this string source)
    {
        return new SubString(source, 0, source.Length);
    }
}

public class Positions
{
    private readonly Dictionary<string, int> _single = new();
    private readonly Dictionary<string, Queue<int>> _multiple = new();
    private int _defaultValue;

    public int RollPosition(string word, int count, int position)
    {
        if (count == 1)
        {
            var last = _single.GetValueOrDefault(word, _defaultValue);
            _single[word] = position;
            return last;
        }

        if (!_multiple.TryGetValue(word, out var queue))
        {
            queue = new Queue<int>();
            _multiple.Add(word, queue);
        }

        queue.Enqueue(position);
        return queue.Count > count ? queue.Dequeue() : _defaultValue;
    }

    public void Clear(int defaultValue)
    {
        _defaultValue = defaultValue;
        _single.Clear();
        
        foreach (var queue in _multiple.Values)
        {
            queue.Clear();
        }
    }
}

public struct SubString(string source, int startIndex, int length) : IEquatable<SubString>
{
    public bool Equals(SubString other) => AsSpan().SequenceEqual(other.AsSpan());

    public override bool Equals(object? obj) => obj is SubString other && Equals(other);

    public ReadOnlySpan<char> AsSpan() => source.AsSpan(startIndex, length);

    public override int GetHashCode()
    {
        var hash = source[startIndex].GetHashCode();
        var lastIndex = startIndex + length;

        for (var i = startIndex + 1; i < lastIndex ; i++)
        {
            hash ^= source[i].GetHashCode();
        }

        return hash;
    }
}