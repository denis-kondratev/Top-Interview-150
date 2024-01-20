/*
 * 125. Valid Palindrome
 * https://leetcode.com/problems/valid-palindrome/?envType=study-plan-v2&envId=top-interview-150
 *
 * A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all
 * non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters
 * and numbers.
 *
 * Given a string s, return true if it is a palindrome, or false otherwise.
 *
 * Example 1:
 *   Input: s = "A man, a plan, a canal: Panama"
 *   Output: true
 *   Explanation: "amanaplanacanalpanama" is a palindrome.
 *
 * Example 2:
 *   Input: s = "race a car"
 *   Output: false
 *   Explanation: "raceacar" is not a palindrome.
 *
 * Example 3:
 *   Input: s = " "
 *   Output: true
 *   Explanation: s is an empty string "" after removing non-alphanumeric characters. Since an empty string
 *                reads the same forward and backward, it is a palindrome.
 *
 * Constraints:
 *   1 <= s.length <= 2 * 10^5
 *   s consists only of printable ASCII characters.
 */

Console.WriteLine("Hello, World!");

public class Solution 
{
    public bool IsPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            if (!char.IsLetterOrDigit(s[left]))
            {
                left++;
                continue;
            }

            if (!char.IsLetterOrDigit(s[right]))
            {
                right--;
                continue;
            }
            
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }
        
        return true;
    }
}