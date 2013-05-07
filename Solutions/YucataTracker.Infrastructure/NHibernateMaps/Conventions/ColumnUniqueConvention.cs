using System;
using FluentNHibernate.Conventions;
using YucataTracker.Domain.Attributes;
using FNH = FluentNHibernate;

namespace YucataTracker.Infrastructure.Conventions
{
	public class ColumnUniqueConvention : AttributePropertyConvention<UniqueAttribute>
	{
		protected override void Apply(UniqueAttribute attribute, FNH.Conventions.Instances.IPropertyInstance instance)
		{
			instance.Unique();
			instance.UniqueKey(String.Format("UIX_{0}_{1}", instance.EntityType.Name, instance.Name));
		}
	}
}
