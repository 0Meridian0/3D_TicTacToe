namespace TicTacToe3D;

public static class PlayerMovement
{
    public static Coordinates SetMove(List<List<List<string>>> matrix)
    {
        while (true)
        {
            var move = PlayerTurn();
            if (Cube.CheckCell(move, matrix))
            {
                return move;
            }
            GameWriter.PrintWrongCell();
        }
    }

    private static Coordinates PlayerTurn()
    {
        var titles = new List<string>()
        {
            "Введите номер слоя: ",
            "Введите номер столбца: ",
            "Введите номер ряда: "
        };

        return new Coordinates
        {
            Cut = CheckNumber(titles, 0),
            Col = CheckNumber(titles, 1),
            Row = CheckNumber(titles, 2)
        };
    }

    private static int CheckNumber(List<string> titles, int titleNumber)
    {
        Console.WriteLine(titles[titleNumber]);
        while (true)
        {
            var number = Console.ReadLine();
            if (number == "1" || number == "2" || number == "3" || number == "4")
            {
                return int.Parse(number) - 1;
            }
            Console.WriteLine("Цифра должна быть от 1 до 4");
        }
    }
}
