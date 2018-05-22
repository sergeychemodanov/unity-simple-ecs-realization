using System.Collections.Generic;
using System.Linq;

namespace SurvivalExample
{
    public static class EntitiesExtensions
    {
        public static List<BaseEntity> WithComponent<T>(this List<BaseEntity> entities)
        {
            return (from entity in entities
                where entity.Components.Any(c => c is T)
                select entity).ToList();
        }
    }
}
