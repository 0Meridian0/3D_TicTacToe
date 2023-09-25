using System.Collections.Generic;
using JetBrains.Annotations;

public class Row : Entity
{
    [CanBeNull] public List<string> Rows { get; set; }

    private void Start()
    {
        Generate(this.transform, entity);
    }
}