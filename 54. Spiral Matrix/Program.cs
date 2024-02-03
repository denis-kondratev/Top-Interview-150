/*
 * 54. Spiral Matrix
 * https://leetcode.com/problems/spiral-matrix/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given an m x n matrix, return all elements of the matrix in spiral order.
 *
 * Example 1:
 *   Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
 *   Output: [1,2,3,6,9,8,7,4,5]
 *
 * Example 2:
 *   Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
 *   Output: [1,2,3,4,8,12,11,10,9,5,6,7]
 *
 * Constraints:
 *   m == matrix.length
 *   n == matrix[i].length
 *   1 <= m, n <= 10
 *   -100 <= matrix[i][j] <= 100
 */

int[][] matrix = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]];
var solution = new Solution();
Console.WriteLine(solution.SpiralOrder(matrix));

public class Solution 
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;

        if (m == 1) return matrix[0];

        var spiral = new int[m * n];
        int left = 0, right = n - 1, top = 0, bottom = m - 1, index = 0;

        while (left <= right && top <= bottom)
        {
            for (var i = left; i <= right; i++)
            {
                spiral[index++] = matrix[top][i];
            }

            if (++top > bottom) break;

            for (var i = top; i <= bottom; i++)
            {
                spiral[index++] = matrix[i][right];
            }

            if (left > --right) break;

            for (var i = right; i >= left; i--)
            {
                spiral[index++] = matrix[bottom][i];
            }

            if (top > --bottom) break;

            for (var i = bottom; i >= top; i--)
            {
                spiral[index++] = matrix[i][left];
            }

            left++;
        }
        
        return spiral;
    }
}