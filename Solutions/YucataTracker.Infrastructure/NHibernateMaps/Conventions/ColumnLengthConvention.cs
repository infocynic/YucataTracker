using System.ComponentModel.DataAnnotations;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace YucataTracker.Infrastructure.Conventions
{
    public class ColumnLengthConvention : AttributePropertyConvention<StringLengthAttribute>
    {
        protected override void Apply(StringLengthAttribute attribute, IPropertyInstance instance)
        {
            // override the default column length
            if (attribute.MaximumLength != default(int)) instance.Length(attribute.MaximumLength);
        }
    }
}
