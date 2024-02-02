/*
 * 36. Valid Sudoku
 * https://leetcode.com/problems/valid-sudoku/?envType=study-plan-v2&envId=top-interview-150
 *
 * Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated
 * according to the following rules:
 *   - Each row must contain the digits 1-9 without repetition.
 *   - Each column must contain the digits 1-9 without repetition.
 *   - Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
 *
 * Note:
 *   - A Sudoku board (partially filled) could be valid but is not necessarily solvable.
 *   - Only the filled cells need to be validated according to the mentioned rules.
 *
 * Constraints:
 *   board.length == 9
 *   board[i].length == 9
 *   board[i][j] is a digit 1-9 or '.'.
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            HashSet<char> rows = [], columns = [], cube = [];

            for (int j = 0; j < 9; j++)
            {
                if(board[i][j]!='.' && !rows.Add(board[i][j]))
                    return false;
                if(board[j][i]!='.' && !columns.Add(board[j][i]))
                    return false;
                int rowIndex = 3*(i/3), columnIndex = 3*(i%3);
                if(board[rowIndex + j/3][columnIndex + j%3]!='.' && !cube.Add(board[rowIndex + j/3][columnIndex + j%3]))
                    return false;
            }
        }
        return true;
    }
}