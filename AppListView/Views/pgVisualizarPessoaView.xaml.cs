using AppListView.Models;

namespace AppListView.Views;

public partial class pgVisualizarPessoaView : ContentPage
{
	Pessoa pessoaVisualizar;
	public pgVisualizarPessoaView(Pessoa pessoa)
	{
		InitializeComponent();
        pessoaVisualizar = pessoa;
        ExibirDados();
    }

    private void ExibirDados()
    { 
        lblId.Text = pessoaVisualizar.Id.ToString();
        lblNome.Text = pessoaVisualizar.Nome;
        lblIdade.Text = pessoaVisualizar.Idade;
    }

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}