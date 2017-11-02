using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace DataAccess
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Server=..\SQLEXPRESS;Database=BarsGroupTestTaskDB;Integrated Security=True;")
                    .ShowSql()
                )
                //Маппинг. Используя AddFromAssemblyOf NHibernate будет пытаться маппить КАЖДЫЙ класс в этой сборке (assembly). Можно выбрать любой класс. 
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Supply>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Provisioner>())

                //SchemeUpdate позволяет создавать/обновлять в БД таблицы и поля (2 поле ==true) 
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
