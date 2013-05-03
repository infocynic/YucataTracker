using System.ComponentModel.DataAnnotations;
using FluentNHibernate.Conventions;
using FNH = FluentNHibernate;

namespace YucataTracker.Infrastructure.Conventions
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(FNH.Conventions.Instances.IManyToOneInstance instance)
        {
            //instance.Column(instance.Property.Name); --seems to be superfluous, and moveover, breaks with newer versions


            if (instance.Property.MemberInfo.IsDefined(typeof(RequiredAttribute), false))
                instance.Not.Nullable();

			instance.ForeignKey(string.Format("FK_{0}_{1}",
				instance.EntityType.Name,
				instance.Name));

        }
    }
}
