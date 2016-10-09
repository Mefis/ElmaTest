using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMConfig.Models;
using NHibernate;
using ORMConfig.Repositories;
using NHibernate.Criterion;

namespace ORMConfig.Managers
{
    public class FileManager : IFileManager
    {
        public void Add(FileCreateORMModel item)
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

        public void Delete(Guid fileId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var criteria = session.CreateCriteria(typeof(FileViewORMModel));

                    criteria.Add(Restrictions.Where<FileViewORMModel>(f => f.Id == fileId));

                    var files = criteria.List<FileViewORMModel>();
                    session.Delete(files.FirstOrDefault());
                    transaction.Commit();
                }
            }
        }

        public IEnumerable<FileViewORMModel> List()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(FileViewORMModel));

                criteria.AddOrder(Order.Asc("CreationDate"));

                var files = criteria.List<FileViewORMModel>();

                return files;
            }
        }
    }
}
