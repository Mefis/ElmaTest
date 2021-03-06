﻿using ORMConfig.Models;
using NHibernate;
using NHibernate.Cfg;

namespace ORMConfig.Repositories
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly("ORMConfig");
                    //configuration.AddAssembly(typeof(FileViewORMModel).Assembly);
                    //configuration.AddAssembly(typeof(FileCreateORMModel).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
