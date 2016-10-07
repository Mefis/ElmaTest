using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using NHibernate;
using DomainModel.Repositories;
using NHibernate.Criterion;

namespace Domain.Managers
{
    public class HistoryManager : IHistoryManager
    {
        public void Add(Models.HistoryDomain item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(item);
                    transaction.Commit();
                }
            }
        }

        public IEnumerable<Models.HistoryDomain> List()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(HistoryDomain));

                criteria.AddOrder(Order.Asc("CreationDate"));

                var docs = criteria.List<HistoryDomain>();

                return docs;
            }
        }

        public IEnumerable<HistoryDomain> List(string search)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(HistoryDomain));

                if (!string.IsNullOrWhiteSpace(search))
                {
                    criteria.Add(Restrictions.Like("Operation", search, MatchMode.Anywhere));
                }

                criteria.AddOrder(Order.Asc("CreationDate"));

                var docs = criteria.List<HistoryDomain>();

                return docs;
            }
        }
    }
}
