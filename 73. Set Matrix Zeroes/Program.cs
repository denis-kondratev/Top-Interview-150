﻿/*
 * 73. Set Matrix Zeroes
 * https://leetcode.com/problems/set-matrix-zeroes/?envType=study-plan-v2&envId=top-interview-150
 *
 * Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.
 * You must do it in place.
 *
 * Example 1:
 *   Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
 *   Output: [[1,0,1],[0,0,0],[1,0,1]]
 *
 * Example 2:
 *   Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
 *   Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]
 *
 * Constraints:
 *   m == matrix.length
 *   n == matrix[0].length
 *   1 <= m, n <= 200
 *   -231 <= matrix[i][j] <= 231 - 1
 *
 * Follow up:
 *   A straightforward solution using O(mn) space is probably a bad idea.
 *   A simple improvement uses O(m + n) space, but still not the best solution.
 *   Could you devise a constant space solution?
 */

int[][] matrix = [[1, 1, 1], [1, 0, 1], [1, 1, 1]];
var solution = new Solution();
solution.SetZeroes(matrix);
Console.WriteLine("Hello, World!");

public class Solution 
{
    public void SetZeroes(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int[] rows = new int[m], cols = new int[n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    rows[i] = 1;
                    cols[j] = 1;
                }
            }
        }
        
        for (var i = 0; i < m; i++)
        {
            if (rows[i] == 1)
            {
                Array.Fill(matrix[i], 0);
            }
        }

        for (var j = 0; j < n; j++)
        {
            if (cols[j] != 1) continue;
            
            for (var i = 0; i < m; i++)
            {
                matrix[i][j] = 0;
            }
        }
    }
}