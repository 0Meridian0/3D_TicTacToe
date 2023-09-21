using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected Entity entity;
    [SerializeField] public int position;
    
    protected void Generate(Transform parent, Entity ent)
    {
        for (var i = 0; i < 4; i++)
        {
            ent.position = i + 1;
            Instantiate(ent, parent);
        }
    }
}