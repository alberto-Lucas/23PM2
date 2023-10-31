using PCLExt.FileStorage.Folders;
using SQLite;

namespace AppCriptografia.Services
{
    public class DataBaseService
    {
        public SQLiteConnection GetConnection()
        {
            var folder = new LocalRootFolder();
            var file =
                folder.CreateFile("crypt",
                PCLExt.FileStorage.
                CreationCollisionOption.OpenIfExists);

            return new SQLiteConnection(file.Path);
        }
    }
}
