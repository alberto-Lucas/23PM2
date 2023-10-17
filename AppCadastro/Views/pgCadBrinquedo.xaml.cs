using AppCadastro.Models;
using AppCadastro.Controllers;

namespace AppCadastro.Views;

public partial class pgCadBrinquedo : ContentPage
{
	//Importar Models
	//Importar Controllers

	//Criar instancia da classe controller
	private BrinquedoController brinquedoController = 
		new BrinquedoController();

	public pgCadBrinquedo()
	{
		InitializeComponent();
	}

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
		//Definir as variaveis dos campos
		string descricao, categoria, codigoBarras;
		int idadeMinima;
		decimal preco;

		descricao = txtDescricao.Text;
		categoria = txtCategoria.Text;
		codigoBarras = txtCodigoBarras.Text;

		idadeMinima = int.Parse(txtIdadeMinima.Text);
		preco = decimal.Parse(txtPreco.Text);

		if(!string.IsNullOrEmpty(descricao) &&
			!string.IsNullOrEmpty(categoria) &&
			!string.IsNullOrEmpty(codigoBarras) &&
			idadeMinima > 0 &&
			preco > 0)
		{
			Brinquedo brinquedo = new Brinquedo();

			brinquedo.CodigoBarras	= codigoBarras;
			brinquedo.Descricao		= descricao;
			brinquedo.Categoria		= categoria;
			brinquedo.IdadeMinima	= idadeMinima;
			brinquedo.Preco			= preco;

			if (brinquedoController.Insert(brinquedo))
			{
				DisplayAlert("Informção",
							 "Registro salvo com sucesso!",
							 "Ok");

				txtCodigoBarras.Text = string.Empty;
				txtDescricao.Text = string.Empty;
				txtCategoria.Text = string.Empty;
				txtIdadeMinima.Text = string.Empty;
				txtPreco.Text = string.Empty;
			}
			else
				DisplayAlert("Erro",
							 "Falha ao salvar registros!",
							 "Ok");
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