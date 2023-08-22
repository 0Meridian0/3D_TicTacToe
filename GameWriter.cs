using System.Reflection.PortableExecutable;
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

    public static void PrintSetNickName(int i)
    {
        Console.WriteLine($"Игрок номер {i}\nУкажите свое имя");
    }

    public static void PrintChoisePriority()
    {
        Console.WriteLine("\nУкажите игрока, который будет ходить первым 1/2");
    }

    public static void PrintPlayersPriority()
    {
        Console.WriteLine("\nВыберите как будет определяться очередность ходов игроков:\n1) Указать вручную\n2) Подкинуть монетку\nУкажите цифру в зависимости от выбора");
    }

    public static void PrintWrongNumber()
    {
        Console.WriteLine("\n#####\nError\n#####\nУказано неверная цифра");
    }

    public static void PrintWrongCell()
    {
        Console.WriteLine("\n#####\nError\n#####\nКлетка уже занята.\n");
    }

    public static void PrintWhoseTurn(Player player)
    {
        Console.WriteLine("\n======================================\nХод игрока " + player.Name);
    }

    public static void PrintWinner(CheckAnswer gameEnd, List<Player> playersTurn)
    {
        var winner = gameEnd == CheckAnswer.WinO ? playersTurn[0].Name : playersTurn[1].Name;

        Console.WriteLine(gameEnd == CheckAnswer.Draw ? "Это ничья!!!" :
                                                        "\nПобедил игрок " + winner + "!");
    }
}
