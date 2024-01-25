/*
 * 15. 3Sum
 * https://leetcode.com/problems/3sum/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k,
 * and j != k, and nums[i] + nums[j] + nums[k] == 0. Notice that the solution set must not contain duplicate triplets.
 *
 * Example 1:
 *   Input: nums = [-1,0,1,2,-1,-4]
 *   Output: [[-1,-1,2],[-1,0,1]]
 *   Explanation:
 *     nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
 *     nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
 *     nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
 *     The distinct triplets are [-1,0,1] and [-1,-1,2].
 *     Notice that the order of the output and the order of the triplets does not matter.
 *
 * Example 2:
 *   Input: nums = [0,1,1]
 *   Output: []
 *   Explanation: The only possible triplet does not sum up to 0.
 *
 * Example 3:
 *   Input: nums = [0,0,0]
 *   Output: [[0,0,0]]
 *   Explanation: The only possible triplet sums up to 0.
 *
 * Constraints:
 *   3 <= nums.length <= 3000
 *   -10^5 <= nums[i] <= 10^5
 */

Console.WriteLine("Hello, World!");

public class Solution 
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        int m = nums.Length - 1, n = nums.Length - 2;
        
        for (var i = 0; i < n; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            int j = i + 1, k = m;

            while (j < k)
            {
                switch (nums[i] + nums[j] + nums[k])
                {
                    case > 0:
                        k--;
                        continue;
                    case < 0:
                        j++;
                        continue;
                }

                result.Add(new[] { nums[i], nums[j++], nums[k--] });
                while (j < k && nums[j] == nums[j - 1]) { j++; }
                while (j < k && nums[k] == nums[k + 1]) { k--; }
            }
        }

        return result;
    }
}