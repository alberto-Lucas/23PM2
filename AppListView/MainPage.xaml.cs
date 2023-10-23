using AppListView.Controllers;
using AppListView.Models;
using AppListView.Views;

namespace AppListView;

public partial class MainPage : ContentPage
{
    //Instalar Nuget sqlite-net-pcl (icone pena)
    //Instalar Nuget pclext.filestorage

    //Passos para transformar em MVC
    //---------------------------------------------------------------------------
    //Primeira coisa criar uma pasta Models
    //Mover nosso objto para Models
    //Crie uma classe chamda Pessoa na pasta Models
    //E mova a classe Pessoa para esse novo arquivo
    //---------------------------------------------------------------------------
    //Criar uma pasta chamada Services para armazenar
    //A conexão com o BD
    //Na pasta Srvices crie a classe DatabaseService
    //Mova a conexão do BD para o novo arquivo
    //---------------------------------------------------------------------------
    //Criar uma pasta chamada Controllers
    //Ira armazer as classes de manipulação de dados
    //No caso do objeto Pessoa teremos a classe PessoaController
    //Ira manipular o insert, update, delete e select no BD
    //Mover o metodos de manipulação para o novo arquivo
    //---------------------------------------------------------------------------
    //Criar uma pasta Views para colocar as novas ContentPage
    //Levar a tela de cadastro para uma nova pagina
    //Deixar apenas a listView na mainPage
    //---------------------------------------------------------------------------

    //Importar o using AppListView.Controllers;
    //Importar o using AppListView.Models;
    //Importar o using AppListView.Views;

    //Criar instacia com a classe pessoaController
    private PessoaController pessoaController = new PessoaController();

    public MainPage()
    {
        InitializeComponent();

        //btnTeste.Source = urlIconTrash;
        AtualizarListView();
    }

    private void AtualizarListView()
    {
        lsvLista.ItemsSource = pessoaController.GetAll();
    }

    private void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
    {
        /*
        //Sender = componente
        //e = valor no caso o item

        //valida se o item da lista é do tipo Pessoa
        if (sender is ListView list && e.Item is Pessoa pessoa)
        {
            string mensagem = 
                "Registro: " + pessoa.Id.ToString() + Environment.NewLine +
                "Nome: " + pessoa.Nome + Environment.NewLine +
                "Idade: " + pessoa.Idade;

            DisplayAlert("Detalhes da Pessoa", mensagem, "OK");
        }

        //Deseleciona o item
        //Preciso informar o tipo do componente do sender
        //para acessar as prioridades
        ((ListView)sender).SelectedItem = null; 
        */
        
    }

    private async void btnDeletar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Pessoa item)
        {
            //DisplayAlert como validação obriga a utilizar async
            //Devido seu método ser do tipo Task
            //Usando Diplay normal ele cria uma task sobre a operação atual
            //Porém para capturar o botão digitado pelo usuario preciso do await 
            //Com isso é preciso alterar o tipo do método para async
            bool validacao = await DisplayAlert("Confirmação", "Você deseja realmente excluir este item?", "Sim", "Cancelar");
            if (validacao)
            {
                // Implemente aqui a lógica para excluir o item da lista.
                // Por exemplo, remova-o da fonte de dados da lista e atualize a ListView.
                pessoaController.Delete(item);
                AtualizarListView(); // Atualize a ListView após a exclusão.
            }
        }
    }

    private void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new pgCadPessoaView());
    }

    private void btnAtualizar_Clicked(object sender, EventArgs e)
    {
        AtualizarListView();
    }

    private async void tapDeletar_Tapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if (tapped.Parameter is Pessoa item)
        {
            bool validacao = await DisplayAlert("Confirmação", "Você deseja realmente excluir este item?", "Sim", "Cancelar");
            if (validacao)
            {
                // Implemente aqui a lógica para excluir o item da lista.
                // Por exemplo, remova-o da fonte de dados da lista e atualize a ListView.
                pessoaController.Delete(item);
                AtualizarListView(); // Atualize a ListView após a exclusão.
            }
        }
    }

    private void tapVisualizar_Tapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;
        if (tapped.Parameter is Pessoa item)
        {
            Application.Current.MainPage.Navigation.PushAsync(new pgVisualizarPessoaView(item));
        }
    }
}

