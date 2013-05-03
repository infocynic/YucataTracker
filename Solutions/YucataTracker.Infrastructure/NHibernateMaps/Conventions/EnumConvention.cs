using System;
using FNH = FluentNHibernate;

namespace YucataTracker.Infrastructure.Conventions
{
    /// <summary>
    /// Enum convention that maps enumerations as integers.
    /// </summary>
    public class EnumConvention : FNH.Conventions.IUserTypeConvention
    {

        #region IConventionAcceptance<IPropertyInspector> Members

        public void Accept(FNH.Conventions.AcceptanceCriteria.IAcceptanceCriteria<FNH.Conventions.Inspections.IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum ||
                (x.Property.PropertyType.IsGenericType &&
                x.Property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                x.Property.PropertyType.GetGenericArguments()[0].IsEnum));

        }

        #endregion

        #region IConvention<IPropertyInspector,IPropertyInstance> Members

        public void Apply(FNH.Conventions.Instances.IPropertyInstance instance)
        {
            instance.CustomType(instance.Property.PropertyType);
        }

        #endregion
    }
}
