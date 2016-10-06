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
        public void Add(HistoryDomain item)
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

        public IEnumerable<HistoryDomain> List()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(HistoryDomain));

                //criteria.Add(Restrictions.Ge("X",5));

                var docs = criteria.List<HistoryDomain>();

                return docs;
            }
        }
    }
}
