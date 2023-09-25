namespace AppListView.Views;
using AppListView.Controllers;
using AppListView.Models;

public partial class pgCadPessoaView : ContentPage
{
    //Importar o using AppListView.Controllers;
    //Importar o using AppListView.Models;

    //Criar instacia com a classe pessoaController
    private PessoaController pessoaController = new PessoaController();
    public pgCadPessoaView()
	{
		InitializeComponent();
	}

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        string nome = txtNome.Text;
        string idade = txtIdade.Text;

        if (!string.IsNullOrEmpty(nome) &&
            !string.IsNullOrEmpty(idade))
        {
            Pessoa pessoa = new Pessoa();

            pessoa.Nome = nome;
            pessoa.Idade = idade;

            if (pessoaController.Insert(pessoa))
            {
                DisplayAlert("Informação",
                             "Registro salvo com sucesso!", "Ok");

                txtNome.Text = string.Empty;
                txtIdade.Text = string.Empty;

            }
            else
                DisplayAlert("Erro",
                             "Falha ao salvar registro no banco de dados.", "Ok");
        }
        else
            DisplayAlert("Atenção",
                        "Preencha os campos corretamente.",
                        "Ok");
    }

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}