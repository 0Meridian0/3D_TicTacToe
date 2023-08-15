namespace TicTacToe3D;

public static class Cube
{
    public static List<List<List<string>>> GenerateMatrix()
    {
        int cut = 4;
        int row = 4;
        int col = 4;

        var matrix = new List<List<List<string>>>();

        for (int i = 0; i < cut; i++)
        {
            var tableRow = new List<List<string>>();
            for (int j = 0; j < row; j++)
            {
                var tableCol = new List<string>();
                for (int k = 0; k < col; k++)
                {
                    tableCol.Add(".");
                }

                tableRow.Add(tableCol);
            }

            matrix.Add(tableRow);
        }

        return matrix;
    }

    public static bool CheckCell(Coordinates cell, List<List<List<string>>> matrix)
    {
        if (matrix[cell.Cut][cell.Row][cell.Col] == ".")
        {
            return true;
        }
        return false;
    }
}
