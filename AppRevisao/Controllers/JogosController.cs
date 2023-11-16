using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRevisao.Models;
using AppRevisao.Services;

namespace AppRevisao.Controllers
{
    public class JogosController
    {
        private DataBaseService dataBaseService;
        private SQLiteConnection conexao;

        public JogosController()
        {
            dataBaseService = new DataBaseService();
            conexao = dataBaseService.GetConnection();
            conexao.CreateTable<Jogos>();
        }

        public bool Insert(Jogos value)
        {
            return conexao.Insert(value) > 0;
        }

        public bool Update(Jogos value)
        {
            return conexao.Update(value) > 0;
        }

        public bool Delete(Jogos value)
        {
            return conexao.Delete(value) > 0;
        }

        public List<Jogos> GetAll()
        {
            return conexao.Table<Jogos>().ToList();
        }

        public Jogos GetByID(int value)
        {
            //O Find realiza um select pela PrimaryKey da tabela
            //Ou seja pelo ID do registro
            return conexao.Find<Jogos>(value);
        }

        public List<Jogos> GetByBixo(string value)
        {
            //SELECT * FROM Jogos
            //WHERE Email = value;
            return conexao.Table<Jogos>().
                            Where(x => x.Bixo == value).ToList();
        }

        public List<Jogos> GetByNumero(int value)
        {
            //SELECT * FROM Jogos
            //WHERE Email = value;
            return conexao.Table<Jogos>().
                            Where(x => x.Numero == value).ToList();
        }

        public List<Jogos> GetByJogador(string value)
        {
            //SELECT * FROM Jogos
            //WHERE Email = value;
            return conexao.Table<Jogos>().
                            Where(x => x.Bixo == value).ToList();
        }
    }
}

