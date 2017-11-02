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
                Map(it => it.Code);
                HasMany<SupplyMap>(it => it.Id).
                    Cascade.All().
                    Inverse().
                    Table("Supply");
            }
        }

        public class ProvisionerMap : ClassMap<Provisioner>
        {
            public ProvisionerMap()
            {
                Id(it => it.Id);
                Map(it => it.Name);
                HasMany<SupplyMap>(it => it.Id).
                    Cascade.All().
                    Inverse().
                    Table("Supply");
            }
        }

        public class SupplyMap : ClassMap<Supply>
        {
            public SupplyMap()
            {
             //   Id(it => it.Id);
                Map(it => it.ProductId);
                Map(it => it.ProvisionerId);
                Map(it => it.TimeStamp);
                
                References<Product>(it => it.ProductId);
                References<Provisioner>(it => it.ProvisionerId);
            }
        }
    }
}
