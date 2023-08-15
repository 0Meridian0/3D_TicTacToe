using TicTacToe3D;

public static class GameWriter
{
    public static void PrintMatrix(List<List<List<string>>> matrix)
    {
        for (int cut = 0; cut < 4; cut++)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write(matrix[cut][row][col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
    }

    public static Player PrintWhoseTurn(bool flag, List<Player> playersTurn)
    {
        var player = !flag ? playersTurn[0] : playersTurn[1];
        Console.WriteLine("\n======================================\nХод игрока " + player.Name);

        return player;
    }

    public static void PrintWinner(CheckAnswer gameEnd, List<Player> playersTurn)
    {
        var winner = gameEnd == CheckAnswer.WinO ? playersTurn[0].Name : playersTurn[1].Name;

        Console.WriteLine(gameEnd == CheckAnswer.Draw ? "Это ничья!!!" :
                                                        "\nПобедил игрок " + winner + "!");
    }
}
