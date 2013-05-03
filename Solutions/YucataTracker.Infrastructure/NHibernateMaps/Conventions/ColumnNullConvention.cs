using System.ComponentModel.DataAnnotations;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace YucataTracker.Infrastructure.Conventions
{
    public class ColumnNullConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property.MemberInfo.IsDefined(typeof(RequiredAttribute), false))
                instance.Not.Nullable();
        }

    }
}
