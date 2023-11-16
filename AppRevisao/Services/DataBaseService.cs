using PCLExt.FileStorage.Folders;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRevisao.Services
{
    public class DataBaseService
    {
        public SQLiteConnection GetConnection()
        {
            var folder = new LocalRootFolder();
            var file =
                folder.CreateFile("revisao",
                PCLExt.FileStorage.
                CreationCollisionOption.OpenIfExists);

            return new SQLiteConnection(file.Path);
        }
    }
}
