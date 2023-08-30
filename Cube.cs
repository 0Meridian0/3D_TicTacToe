namespace TicTacToe3D;

public class Rows
{
    public List<string>? Row { get; set; }
}
public class Cuts
{
    public List<Rows>? Cut { get; set; }
}
public static class Cube
{
    public static List<Cuts> GenerateMatrixEx(int sideValue)
    {
        var cube = new List<Cuts>();

        for (int i = 0; i < sideValue; i++)
        {
            var cut = new Cuts();
            for (int j = 0; j < sideValue; j++)
            {
                var row = new Rows();
                for (int k = 0; k < sideValue; k++)
                {
                    row.Row.Add(".");
                }
                cut.Cut.Add(row);
            }
            cube.Add(cut);
        }

        return cube;
    }

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

    public static bool CheckCellEx(Coordinates cell, List<Cuts> cube)
    {
        return cube[cell.Cut].Cut[cell.Row].Row[cell.Col] == ".";
    }

    public static bool CheckCell(Coordinates cell, List<List<List<string>>> matrix)
    {
        return matrix[cell.Cut][cell.Row][cell.Col] == ".";
    }
}
