namespace TicTacToe3D;

public class CubeChecker
{
    public static CheckAnswer CheckCube(List<List<List<string>>> cube)
    {
        var answer = CheckCubeDiagonals(cube);
        if (answer != CheckAnswer.GameNotOver)
        {
            return answer;
        }

        answer = CheckHorisontalCubeEdge(cube);
        if (answer != CheckAnswer.GameNotOver)
        {
            return answer;
        }

        answer = CheckVerticalCubeEdge(cube);
        if (answer != CheckAnswer.GameNotOver)
        {
            return answer;
        }

        answer = CheckCubeDraw(cube);
        if (answer != CheckAnswer.GameNotOver)
        {
            return answer;
        }

        return CheckAnswer.GameNotOver;
    }

    private static CheckAnswer CheckCubeDiagonals(List<List<List<string>>> cube)
    {
        var n = cube.Count - 1;

        var oneSymbol = cube[0][0][0]; var flagOne = oneSymbol != ".";
        var secSymbol = cube[0][n][n]; var flagSec = secSymbol != ".";

        var thrSymbol = cube[0][n][0]; var flagThr = thrSymbol != ".";
        var forSymbol = cube[0][0][n]; var flagFor = forSymbol != ".";

        if (!flagOne && !flagSec && !flagThr && !flagFor)
        {
            return CheckAnswer.GameNotOver;
        }

        for (int i = 0; i < cube[0].Count; i++)
        {
            if (oneSymbol != cube[i][i][i] && flagOne) { flagOne = false; }
            if (secSymbol != cube[i][n][n] && flagSec) { flagSec = false; }
            if (thrSymbol != cube[i][n][i] && flagThr) { flagThr = false; }
            if (forSymbol != cube[i][i][n] && flagFor) { flagFor = false; }

            n--;
        }

        if (flagOne)
        {
            return oneSymbol == "O" ? CheckAnswer.WinO : CheckAnswer.WinX;
        }
        if (flagSec)
        {
            return secSymbol == "O" ? CheckAnswer.WinO : CheckAnswer.WinX;
        }
        if (flagThr)
        {
            return thrSymbol == "O" ? CheckAnswer.WinO : CheckAnswer.WinX;
        }
        if (flagFor)
        {
            return forSymbol == "O" ? CheckAnswer.WinO : CheckAnswer.WinX;
        }

        return CheckAnswer.GameNotOver;
    }

    private static CheckAnswer CheckHorisontalCubeEdge(List<List<List<string>>> cube)
    {
        for (int row = 0; row < cube.Count; row++)
        {
            var edgeCut = new List<List<string>>();

            for (int cut = 0; cut < cube.Count; cut++)
            {
                edgeCut.Add(cube[cut][row]);
            }

            var answer = CubeCutChecker.CheckColumn(edgeCut);

            return answer != CheckAnswer.GameNotOver ? answer :
                   CubeCutChecker.CheckDiagonal(edgeCut);
        }

        return CheckAnswer.GameNotOver;
    }

    private static CheckAnswer CheckVerticalCubeEdge(List<List<List<string>>> cube)
    {
        for (int col = 0; col < cube.Count; col++)
        {
            var edgeCut = new List<List<string>>();
            for (int cut = 0; cut < cube.Count; cut++)
            {
                var edgeRow = new List<string>();
                for (int row = 0; row < cube.Count; row++)
                {
                    edgeRow.Add(cube[cut][row][col]);
                }

                edgeCut.Add(edgeRow);
            }

            var answer = CubeCutChecker.CheckColumn(edgeCut);

            return answer != CheckAnswer.GameNotOver ? answer :
                   CubeCutChecker.CheckDiagonal(edgeCut);
        }

        return CheckAnswer.GameNotOver;
    }

    private static CheckAnswer CheckCubeDraw(List<List<List<string>>> cube)
    {
        foreach (var cut in cube)
        {
            foreach (var row in cut)
            {
                if (row.Contains("."))
                {
                    return CheckAnswer.GameNotOver;
                }
            }
        }

        return CheckAnswer.Draw;
    }

}
