using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRevisao.Models
{
    public class Jogos
    {
        [PrimaryKey, AutoIncrement]
        public int JogosID { get; set; }
        public string Bixo { get; set; }
        public int Numero { get; set; }
        public string Jogador { get; set; }
    }
}
