using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGeneration : MonoBehaviour
{
    [SerializeField] private GameObject cell;
    
    private Vector3 cellPos = new Vector3(0,4.5f,4.5f);
    private float cellDistanse = 1.5f;

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
                    Instantiate(cell, cellPos, Quaternion.identity).transform.SetParent(this.transform);

                    cellPos.x += cellDistanse;
                }

                cellPos.x = 0;
                cellPos.z -= cellDistanse;
                tableRow.Add(tableCol);
            }

            cellPos.x = 0;
            cellPos.z = 4.5f;
            cellPos.y -= cellDistanse;
            matrix.Add(tableRow);
        }
        
        return matrix;
    }
}