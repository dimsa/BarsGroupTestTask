using DataAccess.Entities;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings
{
    public class DataModelMapping
    {
        public class ProductMap : ClassMap<Product>
        {
            public ProductMap()
            {
                Id(it => it.Id);
                Map(it => it.Name);
                Map(it => it.Code).UniqueKey("UniqueProductCode");              
            }
        }

        public class ProvisionerMap : ClassMap<Provisioner>
        {
            public ProvisionerMap()
            {
                Id(it => it.Id);
                Map(it => it.Name);                
            }
        }

        public class SupplyMap : ClassMap<Supply>
        {
            public SupplyMap()
            {
                Id(it => it.Id);

                Map(it => it.TimeStamp).UniqueKey("UniqueSupplyKey");
                References(it => it.Product).Column("ProductId").Not.Nullable().UniqueKey("UniqueSupplyKey");
                References(it => it.Provisioner).Column("ProvisionerId").Not.Nullable().UniqueKey("UniqueSupplyKey");
            }
        }
    }
}
