﻿using SQLite;

namespace AppCadastro.Models
{
    public class Brinquedo
    {
        //Importar a biblioteca using SQLite;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public int IdadeMinima { get; set; }
        public decimal Preco { get; set; }
        public string  CodigoBarras { get; set; }
        public string DirImagem { get; set; }
    }
}
