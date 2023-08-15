using TicTacToe3D;


internal static class Program
{
    private static void Main(string[] args)
    {
        var matrix = Cube.GenerateMatrix();

        var players = new List<Player>();

        for (int i = 1; i <= 2; i++)
        {
            Console.WriteLine($"Игрок номер {i}\nУкажите свое имя");

            players.Add(
                new Player 
                {
                    Name = Console.ReadLine() 
                });
        }
        var turnOrder = PrioritySetter.RandomPriotizeTurns(players);

        GameFlow(turnOrder, matrix);
    }

    private static void GameFlow(List<Player> playersTurn, List<List<List<string>>> matrix)
    {
        var flag = false;
        CheckAnswer gameEnd;

        while (true)
        {
            var player = GameWriter.PrintWhoseTurn(flag, playersTurn);

            var move = PlayerMovement.SetMove(matrix);

            matrix[move.Cut][move.Row][move.Col] = player.Symbol;

            flag = !flag;

            GameWriter.PrintMatrix(matrix);

            gameEnd = CubeCutChecker.CheckCut(matrix);
            if (gameEnd != CheckAnswer.GameNotOver)
            {
                break;
            }

            gameEnd = CubeChecker.CheckCube(matrix);
            if (gameEnd != CheckAnswer.GameNotOver)
            {
                break;
            }
        }

        GameWriter.PrintWinner(gameEnd, playersTurn);
    }
}