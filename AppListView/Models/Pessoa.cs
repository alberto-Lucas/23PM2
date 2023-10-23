using SQLite;

namespace AppListView.Models
{
    //Importar o using SQLite;

    //Deixe a classe publica
    public class Pessoa
    {
        //Adiciona a propriedade Id e defino as propriedades
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }

        //public string urlIconTrash = "icon_trash.png";

    }
}
