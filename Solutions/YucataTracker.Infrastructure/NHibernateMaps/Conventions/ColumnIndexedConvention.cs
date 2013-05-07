using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using YucataTracker.Domain.Attributes;

namespace YucataTracker.Infrastructure.Conventions
{
	public class ColumnIndexedConvention : AttributePropertyConvention<IndexedAttribute>
	{
		protected override void Apply(IndexedAttribute attribute, IPropertyInstance instance)
		{
			instance.Index(String.Format("IX_{0}_{1}", instance.EntityType.Name, instance.Name));
		}
	}
}
