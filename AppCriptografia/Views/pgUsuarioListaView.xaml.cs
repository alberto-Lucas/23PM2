using AppCriptografia.Controllers;
using AppCriptografia.Models;
using AppCriptografia.Services;

namespace AppCriptografia.Views;

public partial class pgUsuarioListaView : ContentPage
{
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

    private void btnCadastrar(object sender, EventArgs e)
    {
        
    }

    private void btnAtualizar(object sender, EventArgs e)
    {
        AtualizarListView();
    }

    private async void tapDeletar(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if(tapped.Parameter is Usuario item)
        {
            bool validacao =
                await DisplayAlert("Confirmação",
                "Deseja realmene excluir este registro?",
                "Sim", "Cancelar");
            if(validacao)
            {
                usuarioController.Delete(item);
                AtualizarListView();
            }
        }
    }

    //Método para centralizar a chamada da tela de cadastro
    //Por qualuqer tipo de Evento
    private void ChamarTelaCadastro(
        AcaoTelaService acaoTela, Usuario usuario)
    {
        Application.Current.MainPage.Navigation.
            PushAsync(
            new pgUsuarioCadastroView(acaoTela, usuario));
    }

    //Método para centralizar a chamada da tela de cadastro
    //Por tipo de Evento Tapped
    private void TappedChamarTelaCadastro(
        object sender, TappedEventArgs e, 
        AcaoTelaService acaoTela)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if (tapped.Parameter is Usuario item)
            ChamarTelaCadastro(acaoTela, item);
    }

    private void tapVisualizar(object sender, TappedEventArgs e)
    {
        TappedChamarTelaCadastro(
            sender, e, AcaoTelaService.Visuaizar);
    }

    private void tapEditar(object sender, TappedEventArgs e)
    {
        TappedChamarTelaCadastro(
                    sender, e, AcaoTelaService.Alterar);
    }

    private void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        ChamarTelaCadastro(AcaoTelaService.Inserir, null);
    }
}