﻿/*
 * 189. Rotate Array
 * https://leetcode.com/problems/rotate-array/description/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
 *
 * Example 1:
 *   Input: nums = [1,2,3,4,5,6,7], k = 3
 *   Output: [5,6,7,1,2,3,4]
 *
 *   Explanation:
 *     rotate 1 steps to the right: [7,1,2,3,4,5,6]
 *     rotate 2 steps to the right: [6,7,1,2,3,4,5]
 *     rotate 3 steps to the right: [5,6,7,1,2,3,4]
 *
 * Example 2:
 *   Input: nums = [-1,-100,3,99], k = 2
 *   Output: [3,99,-1,-100]
 * 
 *   Explanation:
 *     rotate 1 steps to the right: [99,-1,-100,3]
 *     rotate 2 steps to the right: [3,99,-1,-100]
 *
 * Constraints:
 *   1 <= nums.length <= 10^5
 *   -231 <= nums[i] <= 231 - 1
 *   0 <= k <= 105
 *
 * Follow up:
 * Try to come up with as many solutions as you can. There are at least three different ways to solve this problem.
 * Could you do it in-place with O(1) extra space?
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        var n = nums.Length;
        int prev = nums[0], j = k % n, start = 0;

        for (var i = 0; i < n; i++)
        {
            (nums[j], prev) = (prev, nums[j]);

            if (j == start)
            {
                start = j = (j + 1) % n;
                prev = nums[j];
            }
            
            j = (j + k) % n;
        }
    }
}