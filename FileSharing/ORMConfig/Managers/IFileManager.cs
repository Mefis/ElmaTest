using ORMConfig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMConfig.Managers
{
    public interface IFileManager
    {
        void Add(FileCreateORMModel item);
        IEnumerable<FileViewORMModel> List(String sort, String dir);
        FileCreateORMModel GetFile(Guid fileId);
        void Delete(Guid fileId);
    }
}
