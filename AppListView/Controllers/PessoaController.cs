using AppListView.Models;
using AppListView.Services;
using SQLite;

namespace AppListView.Controllers
{
    //Importar o using SQLite;
    //Importar o using AppListView.Services;
    //Importar o using AppListView.Models;

    //Deixe a classe publica
    public class PessoaController
    {
        //Criar as intancias para conexão com o BD
        private DatabaseService databaseService;
        private SQLiteConnection conexao;

        //Criando o método construtor
        public  PessoaController()
        {
            //Instancio a classe de conexão
            databaseService = new DatabaseService();
            //Gero a conexão com o BD
            conexao = databaseService.GetConnection();

            //Mapear classe para criacao da tabela
            conexao.CreateTable<Pessoa>();
        }

        //Criação do Método de manipulação
        public bool Insert(Pessoa value)
        {
            //o Insert retona o numero de linhas alteras
            //No caso como como vou inserir apenas um registro por vez
            //ira retornar 1
            //Se retornar 1 é oq foi inserido com sucesso
            //Se retornar 0 é pq houve algum problema
            return conexao.Insert(value) > 0;
        }

        public bool Update(Pessoa value)
        {
            //O retorno segue os mesmo principios do Insert
            return conexao.Update(value) > 0;
        }

        public bool Delete(Pessoa value)
        {
            //O retorno segue os mesmo principios do Insert
            return conexao.Delete(value) > 0;
        }

        public List<Pessoa> GetAll()
        {
            //Retorna uma lista do Objeto Pessoa
            //Com base nos registo da tabela Pessoa
            //Posso usar o OrderByDescending para ordenação
            //Definindo por qual campo
            //Ex: rderByDescending(x => x.Nome)
            return
                conexao.Table<Pessoa>().
                OrderByDescending(x => x.Nome).
                ToList();

            //Exe de retorno sem ordenação
            /*
            return
                conexao.Table<Pessoa>().
                ToList();
            */
        }

        public Pessoa GetByIdAsync(int value)
        {
            //O Find realizar uma consulta
            //com base na primary Key da tabela
            //Ou seja pelo ID
            return conexao.Find<Pessoa>(value);
        }

        public List<Pessoa> GetByNomeAsync(string value)
        {
            //Retorno uma lista de registro 
            //que o campo nome contenha o valor digitar
            //Ex semelhante a um select com LIKE
            return 
                conexao.Table<Pessoa>().
                Where(x => x.Nome.Contains(value)).
                ToList();
        }
    }
}
