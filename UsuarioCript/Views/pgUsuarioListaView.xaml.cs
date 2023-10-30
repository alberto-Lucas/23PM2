using UsuarioCript.Controllers;
using UsuarioCript.Models;
using UsuarioCript.Services;

namespace UsuarioCript.Views;

public partial class pgUsuarioListaView : ContentPage
{
    //Importar a pasta Models
    //Importar a pasta Controllers

    //Criar instancia com a classe BrinquedoController
    private UsuarioController usuarioController =
        new UsuarioController();

    public pgUsuarioListaView()
	{
		InitializeComponent();
        AtualizarListView();
    }

    private void AtualizarListView()
    {
        lstUsuarios.ItemsSource = usuarioController.GetAll();
    }

    private void btnAtualizar_Clicked(object sender, EventArgs e)
    {
        AtualizarListView();
    }

    private async void tapDeletar_Tapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if (tapped.Parameter is Usuario item)
        {
            bool validacao =
                await DisplayAlert("Confirmação",
                "Deseja realmente excluir este registro?",
                "Sim", "Cancelar");
            if (validacao)
            {
                usuarioController.Delete(item);
                AtualizarListView();
            }
        }
    }

    private void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        ChamarTelaCadastro(AcaoTelaService.Inserir, null);
    }

    //Método para centralizar a chamada da tela de cadastro
    //Por qualquer tipo de evento
    private void ChamarTelaCadastro(AcaoTelaService acaoTela, Usuario usuario)
    {
        Application.Current.MainPage.Navigation.
                PushAsync(new pgUsuarioCadastroView(acaoTela, usuario));
    }

    //Método para centralizar a chamada da tela de cadastro
    //Por um evento do tipo Tapped
    private void TappedChamarTelaCadastro(object sender, TappedEventArgs e, AcaoTelaService acaoTela) 
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if (tapped.Parameter is Usuario item)
        {
            ChamarTelaCadastro(acaoTela, item);
        }        
    }

    private void tapVisualizar_Tapped(object sender, TappedEventArgs e)
    {
        TappedChamarTelaCadastro(sender, e, AcaoTelaService.Visualizar);
    }

    private void tapEditar_Tapped(object sender, TappedEventArgs e)
    {
        TappedChamarTelaCadastro(sender, e, AcaoTelaService.Alterar);
    }
}