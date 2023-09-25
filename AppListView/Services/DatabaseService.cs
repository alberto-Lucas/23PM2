using PCLExt.FileStorage.Folders;
using SQLite;

namespace AppListView.Services
{
    //Importar o using SQLite;
    //Importar o using PCLExt.FileStorage.Folders;

    //Deixe a classe publica
    public class DatabaseService
    {
        //Variavel responsavel pela conexao com o BD
        public SQLiteConnection connection;

        //Crio uma função para retornar a conexão com o BD
        public SQLiteConnection GetConnection()
        {
            var folder = new LocalRootFolder();
            //Definimos o nome do banco de dados
            //Configuramos para caso o arquivo não exista seja criado
            //Caso exista seja atualizado
            var file = folder.CreateFile("list", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

            //Retorna a conexao criada com o banco de dados
            return new SQLiteConnection(file.Path);
        }
    }
}
