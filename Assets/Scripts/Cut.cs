using System.Collections.Generic;
using JetBrains.Annotations;

public class Cut : Entity
{
    [CanBeNull] public List<Row> Cuts { get; set; }
    
    private void Start()
    {
        Generate(this.transform, entity);
    }
}