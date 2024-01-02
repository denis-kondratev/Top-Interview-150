/*
 * 238. Product of Array Except Self
 * https://leetcode.com/problems/product-of-array-except-self/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements
 * of nums except nums[i]. The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 *
 * You must write an algorithm that runs in O(n) time and without using the division operation.
 *
 * Example 1:
 *
 * Input: nums = [1,2,3,4]
 * Output: [24,12,8,6]
 *
 * Example 2:
 *
 * Input: nums = [-1,1,0,-3,3]
 * Output: [0,0,9,0,0]
 *
 * Constraints:
 *
 * 2 <= nums.length <= 10^5
 * -30 <= nums[i] <= 30
 * The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 *
 * Follow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra
 * space for space complexity analysis.)
 */

Console.WriteLine("Hello, World!");

public class Solution 
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var zeroCount = 0;
        var zeroIndex = 0;
        var product = 1;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                product *= nums[i];
                continue;
            }

            zeroCount++;
            zeroIndex = i;

            if (zeroCount > 1) break;
        }

        if (zeroCount > 0)
        {
            Array.Fill(nums, 0);

            if (zeroCount > 1) return nums;
            
            nums[zeroIndex] = product;
            return nums;
        }
        
        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] = product / nums[i];
        }
        
        return nums;
    }
}