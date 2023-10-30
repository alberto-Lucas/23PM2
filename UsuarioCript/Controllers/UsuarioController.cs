using SQLite;
using UsuarioCript.Services;
using UsuarioCript.Models;

namespace UsuarioCript.Controllers
{
    public class UsuarioController
    {
        private DataBaseService dataBaseService;
        private SQLiteConnection conexao;

        public UsuarioController()
        {
            dataBaseService = new DataBaseService();
            conexao = dataBaseService.GetConnection();
            conexao.CreateTable<Usuario>();
        }

        public bool Insert(Usuario value)
        {
            return conexao.Insert(value) > 0;
        }

        public bool Update(Usuario value)
        {
            return conexao.Update(value) > 0;
        }

        public bool Delete(Usuario value)
        {
            return conexao.Delete(value) > 0;
        }

        public List<Usuario> GetAll()
        {
            return conexao.Table<Usuario>().ToList();
        }

        public Usuario GetByID(int value) 
        {
            //O Find realiza um select pela PrimaryKey da tabela 
            //Ou seja pelo ID do registro
            return conexao.Find<Usuario>(value);
        }

        public Usuario GetByEmail(string value)
        {
            //Realize um select filtrando pelo email
            //Retorno o primeiro registro encontrado
            return conexao.Table<Usuario>().
                FirstOrDefault(x => x.Email == value);
        }
    }
}
