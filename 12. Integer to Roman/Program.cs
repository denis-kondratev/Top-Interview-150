/*
 * 12. Integer to Roman
 * https://leetcode.com/problems/integer-to-roman/?envType=study-plan-v2&envId=top-interview-150
 *
 * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
 *
 *   Symbol       Value
 *   I             1
 *   V             5
 *   X             10
 *   L             50
 *   C             100
 *   D             500
 *   M             1000
 *
 * For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which
 * is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
 *
 * Roman numerals are usually written largest to smallest from left to right. However, the numeral for four
 * is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making
 * four. The same principle applies to the number nine, which is written as IX. There are six instances
 * where subtraction is used:
 * 
 *   - I can be placed before V (5) and X (10) to make 4 and 9.
 *   - X can be placed before L (50) and C (100) to make 40 and 90.
 *   - C can be placed before D (500) and M (1000) to make 400 and 900.
 *
 * Given an integer, convert it to a roman numeral.
 *
 * Example 1:
 *   Input: num = 3
 *   Output: "III"
 *   Explanation: 3 is represented as 3 ones.
 *
 * Example 2:
 *   Input: num = 58
 *   Output: "LVIII"
 *   Explanation: L = 50, V = 5, III = 3.
 *
 * Example 3:
 *   Input: num = 1994
 *   Output: "MCMXCIV"
 *   Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 *
 * Constraints:
 *   1 <= num <= 3999
 */

using System.Text;

Console.WriteLine("Hello, World!");

public class Solution
{
    private static readonly RomanNumeral[] RomanNumerals = 
    {
        new(1000, 'M'),
        new(900, 'M', 'C'),
        new(500, 'D'),
        new(400, 'D', 'C'),
        new(100, 'C'),
        new(90, 'C', 'X'),
        new(50, 'L'),
        new(40, 'L', 'X'),
        new(10, 'X'),
        new(9, 'X', 'I'),
        new(5, 'V'),
        new(4, 'V', 'I'),
        new(1, 'I')
    };
    
    public string IntToRoman(int num)
    {
        var romanNumber = new StringBuilder();

        foreach (var romanNumeral in RomanNumerals)
        {
            AddNumeral(ref num, in romanNumeral, romanNumber);
        }

        return romanNumber.ToString();
    }

    private void AddNumeral(ref int number, in RomanNumeral numeral, StringBuilder romanNumber)
    {
        var count = number / numeral.Divider;

        if (count == 0)
        {
            return;
        }

        if (numeral.HasAdditionalCharacter)
        {
            if (count > 1)
            {
                throw new Exception("WTF!!!");
            }

            romanNumber.Append(numeral.AdditionalCharacter);
            romanNumber.Append(numeral.Character);
        }
        else
        {
            romanNumber.Append(numeral.Character, count);
        }

        number %= numeral.Divider;
    }

    public readonly struct RomanNumeral
    {
        public readonly int Divider;
        public readonly char Character;
        public readonly char AdditionalCharacter;

        public bool HasAdditionalCharacter => AdditionalCharacter != '*';
        
        public RomanNumeral(int divider, char character, char additionalCharacter)
        {
            if (additionalCharacter == '*')
            {
                throw new ArgumentOutOfRangeException(nameof(additionalCharacter));
            }
            
            Divider = divider;
            Character = character;
            AdditionalCharacter = additionalCharacter;
        }
        
        public RomanNumeral(int divider, char character)
        {
            Divider = divider;
            Character = character;
            AdditionalCharacter = '*';
        }
    }
}