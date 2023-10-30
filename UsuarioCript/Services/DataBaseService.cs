using PCLExt.FileStorage.Folders;
using SQLite;

namespace UsuarioCript.Services
{
    public class DataBaseService
    {
        //Importar a blibioteca SQLite;
        //Importar a biblioteca PCLExt.FileStorage.Folders;

        //Metodo para retornar a conexao
        public SQLiteConnection GetConnection()
        {
            var folder = new LocalRootFolder();
            var file = folder.CreateFile("crypt",
                PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

            //Retorno a conexao como banco de dados
            return new SQLiteConnection(file.Path);
        }
    }
}
