using AppCadastro.Models;

namespace AppCadastro.Views;

public partial class pgVisualizarBrinquedo : ContentPage
{
	public pgVisualizarBrinquedo(Brinquedo brinquedo)
	{
		InitializeComponent();
		lblDescricao.Text = brinquedo.Descricao;
		imgCadastro.Source = brinquedo.DirImagem;
    }
}