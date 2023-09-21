using System.Collections.Generic;
using UnityEngine;

public class MatrixGeneration : MonoBehaviour
{
    private List<List<List<string>>> cube;
    
    void Start()
    {
        cube = GenerateMatrix();
    }

    public List<List<List<string>>> GenerateMatrix()
    {
        const int cut = 4;
        const int row = 4;
        const int col = 4;

        var matrix = new List<List<List<string>>>();

        for (var i = 0; i < cut; i++)
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
}