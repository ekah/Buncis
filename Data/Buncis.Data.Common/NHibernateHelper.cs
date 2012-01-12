//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NHibernate;
//using FluentNHibernate.Cfg;
//using FluentNHibernate.Cfg.Db;
//using Buncis.Data.Domain.Mappings;

//namespace Buncis.Data.Common
//{
//    public class NHibernateHelper
//    {
//        //private readonly string _connectionString;
//        private ISessionFactory _sessionFactory;

//        public ISessionFactory SessionFactory
//        {
//            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
//        }

//        //public NHibernateHelper(string connectionString)
//        //{
//        //    _connectionString = connectionString;
//        //}

//        private ISessionFactory CreateSessionFactory()
//        {
//            return Fluently.Configure()
//                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("BuncisConnectionString")))
//                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>())
//                .BuildSessionFactory();
//        }
//    }
//}
