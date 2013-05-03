using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;

namespace UOE.NHibernate.Conventions.Conventions
{
	public class HasManyConstraintNameConvention : IHasManyConvention
	{


		#region IConvention<IOneToManyCollectionInspector,IOneToManyCollectionInstance> Members

		public void Apply(global::FluentNHibernate.Conventions.Instances.IOneToManyCollectionInstance instance)
		{
			instance.Key.ForeignKey(string.Format("FK_{0}_{1}",
				instance.Member.Name,
				instance.EntityType.Name));
		}

		#endregion
	}
}
