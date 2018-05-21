using System.Collections.Generic;

namespace SurvivalExample
{
    public interface IEntity
    {
        List<IComponent> Components { get; }
    }
}