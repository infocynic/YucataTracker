using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace YucataTracker.Infrastructure.Conventions
{
    public class HasManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Cascade.All();

			instance.Key.ForeignKey(string.Format("FK_{0}_{1}",
				instance.TableName,
				instance.Relationship.EntityType.Name));
        }
    }
}
