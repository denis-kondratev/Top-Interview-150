/*
 * 42. Trapping Rain Water
 * https://leetcode.com/problems/trapping-rain-water/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much
 * water it can trap after raining.
 *
 * Example 1:
 * 
 *   Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
 *   Output: 6
 *   Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1].
 *                In this case, 6 units of rain water (blue section) are being trapped.
 *
 * Example 2:
 * 
 *   Input: height = [4,2,0,3,2,5]
 *   Output: 9
 *
 * Constraints:
 * 
 *   n == height.length
 *   1 <= n <= 2 * 104
 *   0 <= height[i] <= 105
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public int Trap(int[] heights)
    {
        var length = heights.Length;
        var levels = new int[length];
        var maxLevel = 0;

        for (var i = 0; i < length; i++)
        {
            maxLevel = Math.Max(maxLevel, heights[i]);
            levels[i] = maxLevel;
        }

        maxLevel = 0;
        var result = 0;
        
        for (var i = length - 1; i >= 0; i--)
        {
            maxLevel = Math.Max(maxLevel, heights[i]);
            var level = Math.Min(levels[i], maxLevel);
            result += Math.Max(level - heights[i], 0);
        }
        
        return result;
    }
}