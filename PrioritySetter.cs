namespace TicTacToe3D;

public static class PrioritySetter
{
    public static List<Player> PersonalPriotizeTurns(List<Player> players)
    {
        Console.WriteLine("Укажите игрока, который будет ходить первым 1/2");
        string turn;

        while (true)
        {
            turn = Console.ReadLine();

            if (turn == "1" || turn == "2")
            {
                break;
            }

            Console.WriteLine("Указана неверная цифра. Укажите очередность снова.");
        }

        return SetPriotize(players, int.Parse(turn));
    }

    public static List<Player> RandomPriotizeTurns(List<Player> players)
    {
        return SetPriotize(players, new Random().Next(1, 3));
    }

    private static List<Player> SetPriotize(List<Player> players, int turn)
    {
        if (turn == 1)
        {
            players[0].Symbol = "O";
            players[1].Symbol = "X";

            return players;
        }
        else
        {
            players[0].Symbol = "X";
            players[1].Symbol = "O";

            (players[0], players[1]) = (players[1], players[0]);

            return players;
        }
    }
}
