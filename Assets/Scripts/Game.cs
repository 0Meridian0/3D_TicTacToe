using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Cube gameCube;
    
    private static List<List<List<string>>> _matrix;
    private CheckAnswer _gameEnd;
    private static List<Player> _players;
    private bool _playerTurn = false;
    
    private void OnEnable()
    {
        Cell.OnClickedCell += CheckPlayerMovement;
    }

    private void OnDisable()
    {
        Cell.OnClickedCell -= CheckPlayerMovement;
    }

    public void StartGame(int size)
    {
        Entity.SideSize = size;
        Instantiate(gameCube);
        
        _matrix = GenerateMatrix(size);
        _players = new List<Player>
        {
            new Player
            {
                Name = "Alex",
                Symbol = "X"
            },
            new Player
            {
                Name = "Dasha",
                Symbol = "O"
            }
        };
    }

    private List<List<List<string>>> GenerateMatrix(int sideValue)
    {
        var cube = new List<List<List<string>>>();
        
        for (int i = 0; i < sideValue; i++)
        {
            var tableRow = new List<List<string>>();
            for (int j = 0; j < sideValue; j++)
            {
                var tableCol = new List<string>();
                for (int k = 0; k < sideValue; k++)
                {
                    tableCol.Add(".");
                }

                tableRow.Add(tableCol);
            }

            cube.Add(tableRow);
        }
        
        return cube;
    }
    
    private void CheckPlayerMovement(Coordinates cord, Cell cell)
    {
        if(_matrix[cord.Cut][cord.Row][cord.Col] != ".") return;

        var player = !_playerTurn ? _players[0] : _players[1];
        _matrix[cord.Cut][cord.Row][cord.Col] = player.Symbol;
        cell.GetComponent<Renderer>().material.color = player.Symbol == "X" ? Color.black : Color.red;

        _playerTurn = !_playerTurn;
        
        _gameEnd = CubeCutChecker.CheckCut(_matrix);
        if (_gameEnd != CheckAnswer.GameNotOver)
        {
            Debug.Log($"Победа {_gameEnd}");
            return;
        }

        _gameEnd = CubeChecker.CheckCube(_matrix);
        if (_gameEnd != CheckAnswer.GameNotOver)
        {
            Debug.Log($"Победа {_gameEnd}");
            return;
        }
    }
}