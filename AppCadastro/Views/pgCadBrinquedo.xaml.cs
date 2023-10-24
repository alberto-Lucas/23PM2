using AppCadastro.Models;
using AppCadastro.Controllers;
using AppCadastro.Services;

namespace AppCadastro.Views;

public partial class pgCadBrinquedo : ContentPage
{
	//Importar Models
	//Importar Controllers

	//Criar instancia da classe controller
	private BrinquedoController brinquedoController = 
		new BrinquedoController();

	private string sImagemSelecionada;

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

			//Chamar metodo para copiar a imagem para dentro da pasta do
			//do aplicativo, e retorno o novo diretorio
			brinquedo.DirImagem =
				ImageService.CopiarImagemDirApp(sImagemSelecionada);

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
				sImagemSelecionada = string.Empty;
				RemoverIamagem();
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

    private async void btnAdicionarImagem_Clicked(object sender, EventArgs e)
    {
		sImagemSelecionada = await ImageService.SelecionarImagem();
		imgCadastro.Source = sImagemSelecionada;
		btnRemoverImagem.IsVisible = true;
    }

    private void btnRemoverImagem_Clicked(object sender, EventArgs e)
    {
		RemoverIamagem();
    }

	private void RemoverIamagem()
	{
		imgCadastro.Source = "";
		btnRemoverImagem.IsVisible = false;
	}
}