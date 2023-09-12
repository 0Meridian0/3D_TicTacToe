using System;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField] private GameObject cell;

    private Vector3 _cellPos = new Vector3(0f, 0f, 0f);
    private float _posDiff = 1.5f;

    private void Generate(int numOfCells)
    {
        for (var i = 0; i < numOfCells; i++)
        {
            Instantiate(cell, _cellPos, Quaternion.identity).transform.SetParent(this.transform);
            _cellPos.x += _posDiff;
        }
    }

    private void Start()
    {
        Generate(4);
    }
}