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
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        static UnitOfWork()
        {
            _sessionFactory = Fluently.Configure()
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
        }


        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public ISession Session { get; }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {                
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {                
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
