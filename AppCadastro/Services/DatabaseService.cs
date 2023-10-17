using SQLite;
using PCLExt.FileStorage.Folders;

namespace AppCadastro.Services
{
    public class DatabaseService
    {
        //Importar a blibioteca SQLite;
        //Importar a biblioteca PCLExt.FileStorage.Folders;

        //Instancia de conexao
        public SQLiteConnection connection;

        //Metodo para retornar a conexao
        public SQLiteConnection GetConnection()
        {
            var folder = new LocalRootFolder();
            var file = folder.CreateFile("hihappy",
                PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

            //Retorno a conexao como banco de dados
            return new SQLiteConnection(file.Path);
        }
    }
}
