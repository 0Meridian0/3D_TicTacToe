using UnityEngine;

public class Cut : MonoBehaviour
{
    [SerializeField] private GameObject row;
    
    private Vector3 _rowPos = new Vector3(0f, 0f, 0f);
    private float _posDiff = 1.5f;

    private void Generate(int numOfRows)
    {
        for (var i = 0; i < numOfRows; i++)
        {
            Instantiate(row, _rowPos, Quaternion.identity).transform.SetParent(this.transform);
            _rowPos.z += _posDiff;
            
            
            /*
            var a = row.transform.position;
            Instantiate(row);
            */
            
        }
    }

    void Start()
    {
        Generate(4);
    }
}
