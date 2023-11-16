using AppRevisao.Models;
using AppRevisao.Services;
using AppRevisao.Controllers;

namespace AppRevisao.Views;

public partial class pgJogosListaView : ContentPage
{
    private JogosController jogosController =
        new JogosController();

    public pgJogosListaView()
	{
		InitializeComponent();
        AtualizarListView();
    }

    private void AtualizarListView()
    {
        lstJogos.ItemsSource = jogosController.GetAll();
    }

    //Método para centralizar a chamada da tela de cadastro
    //Por qualuqer tipo de Evento
    private void ChamarTelaCadastro(
        AcaoTelaService acaoTela, Jogos jogos)
    {
        Application.Current.MainPage.Navigation.
            PushAsync(
            new pgJogosCadastroView(acaoTela, jogos));
    }


    //Método para centralizar a chamada da tela de cadastro
    //Por tipo de Evento Tapped
    private void TappedChamarTelaCadastro(
        object sender, TappedEventArgs e,
        AcaoTelaService acaoTela)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if (tapped.Parameter is Jogos item)
            ChamarTelaCadastro(acaoTela, item);
    }

    private void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        ChamarTelaCadastro(AcaoTelaService.Inserir, null);
    }

    private void btnAtualizar_Clicked(object sender, EventArgs e)
    {
        AtualizarListView();
    }

    private async void tapDeletar(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if (tapped.Parameter is Jogos item)
        {
            bool validacao =
                await DisplayAlert("Confirmação",
                "Deseja realmene excluir este registro?",
                "Sim", "Cancelar");
            if (validacao)
            {
                jogosController.Delete(item);
                AtualizarListView();
            }
        }
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
}