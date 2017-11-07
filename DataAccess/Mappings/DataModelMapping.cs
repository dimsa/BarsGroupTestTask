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
                Map(it => it.TimeStamp);


                Join("Product", join =>
                {
                    join.KeyColumn("Id");
                    join.Component(it => it.Product, c =>
                    {
                        c.Map(it => it.Id);
                        c.Map(it => it.Name);
                        c.Map(it => it.Code);
                    });
                });

                Join("Provisioner", join =>
                {
                    join.KeyColumn("Id");
                    join.Component(it => it.Provisioner, c =>
                    {
                        c.Map(it => it.Id);
                        c.Map(it => it.Name);
                    });
                });
            }
        }
    }
}
