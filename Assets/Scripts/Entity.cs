using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected Entity entity;
    [SerializeField] public int position;
    public static int SideSize { get; set; }
    
    protected void Generate(Transform parent, Entity ent)
    {
        for (var i = 0; i < SideSize; i++)
        {
            ent.position = i;
            Instantiate(ent, parent);
        }
    }
}