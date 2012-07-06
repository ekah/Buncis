using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Collections;

namespace Buncis.Web.Common.WebServices
{
    //class WebSessionFactoryProvider : ISessionFactoryProvider
    //{
    //    public event EventHandler<EventArgs> BeforeCloseSessionFactory;

    //    public ISessionFactory GetFactory(string factoryId)
    //    {
    //        return new NHibernate.Burrow.BurrowFramework().GetSessionFactory("bPersistenceUnit");
    //    }

    //    public IEnumerator<ISessionFactory> GetEnumerator()
    //    {
    //        var sessionFactories = new List<ISessionFactory>();
    //        sessionFactories.Add(new NHibernate.Burrow.BurrowFramework().GetSessionFactory("bPersistenceUnit"));
    //        return sessionFactories.AsEnumerable().GetEnumerator();
    //    }

    //    IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
