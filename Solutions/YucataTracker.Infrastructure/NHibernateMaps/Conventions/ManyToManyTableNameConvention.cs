using FluentNHibernate.Conventions.Inspections;
using inflector_extension;
using FNH = FluentNHibernate;

namespace YucataTracker.Infrastructure.Conventions
{
    public class ManyToManyTableNameConvention : FNH.Conventions.ManyToManyTableNameConvention
    {
        protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection,
            IManyToManyCollectionInspector otherSide)
        {

            return collection.EntityType.Name.InflectTo().Pluralized + "_" +
                otherSide.EntityType.Name.InflectTo().Pluralized;
        }

        protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            return collection.EntityType.Name.InflectTo().Pluralized + "_" +
                collection.ChildType.Name.InflectTo().Pluralized;
        }
    }
}
