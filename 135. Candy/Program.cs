/*
 * 135. Candy
 * https://leetcode.com/problems/candy/?envType=study-plan-v2&envId=top-interview-150
 *
 * There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.
 * You are giving candies to these children subjected to the following requirements:
 *
 *   - Each child must have at least one candy.
 *   - Children with a higher rating get more candies than their neighbors.
 *
 * Return the minimum number of candies you need to have to distribute the candies to the children.
 *
 * Example 1:
 *
 *   Input: ratings = [1,0,2]
 *   Output: 5
 *   Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.
 *
 * Example 2:
 *
 *   Input: ratings = [1,2,2]
 *   Output: 4
 *   Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
 *                The third child gets 1 candy because it satisfies the above two conditions.
 *
 * Constraints:
 *
 *   n == ratings.length
 *   1 <= n <= 2 * 10^4
 *   0 <= ratings[i] <= 2 * 10^4
 */

int[] ratings = [1, 3, 4, 5, 2];
var solution = new Solution();
Console.WriteLine(solution.Candy(ratings));

public class Solution 
{
    public int Candy(int[] ratings)
    {
        var candies = new int[ratings.Length];
        candies[0] = 1;

        for (int l = 0, r = 1; r < ratings.Length; l++, r++)
        {
            candies[r] = ratings[r] > ratings[l] ? candies[l] + 1 : 1;
        }

        var totalCandyCount = candies[^1];
        
        for (int r = ratings.Length - 1, l = r - 1; l >= 0; r--, l--)
        {
            if (ratings[l] > ratings[r] && candies[l] <= candies[r])
            {
                candies[l] = candies[r] + 1;
            }
            
            totalCandyCount += candies[l];
        }

        return totalCandyCount;
    }
}