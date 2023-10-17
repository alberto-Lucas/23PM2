using SQLite;
using AppCadastro.Models;
using AppCadastro.Services;

namespace AppCadastro.Controllers
{
    public class BrinquedoController
    {
        //Importar SQLite;
        //Importar Models;
        //Importar Services;

        //Criar as instancia do Banco de Dados
        private DatabaseService databaseService;
        private SQLiteConnection conexao;

        //Criar o método construtor
        //Será executado automaticamente
        //quando for instanciado
        public BrinquedoController()
        {
            //Instanciar a classe de conexão
            databaseService = new DatabaseService();

            //Gerar a conexão com o BD
            //a variacel conexao esta conectada com o BD
            conexao = databaseService.GetConnection();

            //Mapear classe para criar a tabela
            conexao.CreateTable<Brinquedo>();
        }

        //Métodos de manipulação

        public bool Insert(Brinquedo value)
        {
            return conexao.Insert(value) > 0;
        }


        //Nao foi pedido na prova, mas usaremos mais tarde
        public bool Delete(Brinquedo value)
        {
            return conexao.Delete(value) > 0;
        }

        public List<Brinquedo> GetAll()
        {
            return conexao.Table<Brinquedo>().ToList();
        }
    }
}
