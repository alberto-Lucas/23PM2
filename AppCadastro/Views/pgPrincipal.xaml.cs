using AppCadastro.Models;
using AppCadastro.Controllers;

namespace AppCadastro.Views;

public partial class pgPrincipal : ContentPage
{
    //Importar a pasta Models
    //Importar a pasta Controllers

    //Criar instancia com a classe BrinquedoController
    private BrinquedoController brinquedoController = 
        new BrinquedoController();

	public pgPrincipal()
	{
		InitializeComponent();

        AtualizarListView();
	}

    private void AtualizarListView()
    {
        lstBrinquedos.ItemsSource = brinquedoController.GetAll();
    }

    private void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.
            PushAsync(new pgCadBrinquedo());
    }

    private void btnAtualizar_Clicked(object sender, EventArgs e)
    {
        AtualizarListView();
    }

    private async void tapDeletar_Tapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if(tapped.Parameter is Brinquedo item)
        {
            bool validacao = 
                await DisplayAlert("Confirmação",
                "Deseja realmente excluir este registro?",
                "Sim", "Cancelar");
            if(validacao)
            {
                brinquedoController.Delete(item);
                AtualizarListView();
            }
        }
    }

    private void tapVisualizar_Tapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if (tapped.Parameter is Brinquedo item)
        {
            Application.Current.MainPage.Navigation.
                PushAsync(new pgVisualizarBrinquedo(item));
        }
    }
}