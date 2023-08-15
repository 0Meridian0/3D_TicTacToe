namespace TicTacToe3D;

public class CubeCutChecker
{
    public static CheckAnswer CheckCut(List<List<List<string>>> matrix)
    {
        foreach (var cut in matrix)
        {
            var answer = CheckRow(cut);
            if (answer != CheckAnswer.GameNotOver)
            {
                return answer;
            }

            answer = CheckColumn(cut);
            if (answer != CheckAnswer.GameNotOver)
            {
                return answer;
            }

            answer = CheckDiagonal(cut);
            if (answer != CheckAnswer.GameNotOver)
            {
                return answer;
            }

            return CheckAnswer.GameNotOver;
        }

        return CheckAnswer.GameNotOver;
    }

    public static CheckAnswer CheckRow(List<List<string>> cut)
    {
        foreach (var row in cut)
        {
            var isSingleCharacterString = true;
            var fSymbol = row[0];

            foreach (var el in row)
            {
                if (el == "." || fSymbol != el)
                {
                    isSingleCharacterString = false;
                    break;
                }
            }

            if (isSingleCharacterString)
            {
                return fSymbol == "O" ? CheckAnswer.WinO : CheckAnswer.WinX;
            }
        }

        return CheckAnswer.GameNotOver;
    }

    public static CheckAnswer CheckColumn(List<List<string>> cut)
    {
        var columnLen = cut.Count;
        for (int i = 0; i < columnLen; i++)
        {
            var isSingleCharacterColumn = true;
            var fSymbol = cut[0][i];

            for (int j = 0; j < columnLen; j++)
            {
                if (cut[j][i] == "." || fSymbol != cut[j][i])
                {
                    isSingleCharacterColumn = false;
                    break;
                }
            }

            if (isSingleCharacterColumn)
            {
                return fSymbol == "O" ? CheckAnswer.WinO : CheckAnswer.WinX;
            }
        }

        return CheckAnswer.GameNotOver;
    }

    public static CheckAnswer CheckDiagonal(List<List<string>> cut)
    {
        var answer = CheckLRDiagonal(cut);
        if (answer != CheckAnswer.GameNotOver)
            return answer;

        answer = CheckRLDiagonal(cut);
        if (answer != CheckAnswer.GameNotOver)
            return answer;

        return CheckAnswer.GameNotOver;
    }

    private static CheckAnswer CheckLRDiagonal(List<List<string>> cut)
    {
        string fSymbol = cut[0][0];
        if (fSymbol == ".")
            return CheckAnswer.GameNotOver;

        for (int i = 0; i < cut.Count; i++)
        {
            if (fSymbol != cut[i][i])
            {
                return CheckAnswer.GameNotOver;
            }
        }

        return fSymbol == "O" ? CheckAnswer.WinO : CheckAnswer.WinX;
    }

    private static CheckAnswer CheckRLDiagonal(List<List<string>> cut)
    {
        int n = cut.Count - 1;
        int j = 0;

        string fSymbol = cut[j][n];
        if (fSymbol == ".")
            return CheckAnswer.GameNotOver;

        for (int i = n; i > 0; i--)
        {
            if (fSymbol != cut[j][i])
            {
                return CheckAnswer.GameNotOver;
            }
            j++;
        }

        return fSymbol == "O" ? CheckAnswer.WinO : CheckAnswer.WinX;
    }

}
