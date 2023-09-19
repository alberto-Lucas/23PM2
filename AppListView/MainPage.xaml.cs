using System.Collections.ObjectModel;
using PCLExt.FileStorage.Folders;
using SQLite;

namespace AppListView;

public partial class MainPage : ContentPage
{
    //Instalar Nuget sqlite-net-pcl (icone pena)
    //Instalar Nuget pclext.filestorage

    //Variavel responsavel pela conexao com o BD
    //Impartar using SQLite;
    private SQLiteConnection conexao;

    public class Pessoa
    {
        //Adiciona a propridade Id e define a configuração
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
    }

    //Removo a nossa coleção do objeto Pessoa
    //ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();

    //Função responsavel por retornar a conexão com o BD
    public SQLiteConnection GetConnection()
    {
        //Importart using PCLExt.FileStorage.Folders;
        //Variavel responsavel por manipular a pasta 
        //Onde o aplicativo esta executando
        var folder = new LocalRootFolder();
        //Definir o nome do banco de dados
        //Configurar para caso o arquivo não exista, seja criado
        //Caso exista seja atualizado
        //No xamarim.forms nao pode utilizar a extensão .db3
        //No MAUI funciona
        var file = folder.CreateFile(
            "list", PCLExt.FileStorage.
                CreationCollisionOption.OpenIfExists);

        //Retornar a conexao criada com o banco de dados
        return new SQLiteConnection(file.Path);
    }

    public MainPage()
    {
        InitializeComponent();
        //Remover a atribuição da coleção ao Souver da lista
        //Não será mais utilizado devido o BD
        //lsvLista.ItemsSource = pessoas;
        /*
        pessoas.Add(new Pessoa
        {
            Nome = "Lucas",
            Idade = "0"
        });
        */

        //Abrir a conexão com o BD
        conexao = GetConnection();

        //Mapear a classe para a criação da tabela
        conexao.CreateTable<Pessoa>();
        //Chamar o método para atualizar a listview
        AtualizarListView();
    }

    //Método para atualizar a ListView
    private void AtualizarListView()
    {
        //Realizar um select na tabela Pessoa
        //seria a query:
        //select * from pessoa
        lsvLista.ItemsSource = conexao.Table<Pessoa>().ToList();
    }

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        string nome = txtNome.Text;
        string idade = txtIdade.Text;

        if (!string.IsNullOrEmpty(nome) &&
            !string.IsNullOrEmpty(idade))
        {
            //Não vamos mais utilizar a a coleção de objeto Pessoa
            /*
            pessoas.Add(new Pessoa
            {
                Nome = nome,
                Idade = idade
            });
            */

            conexao.Insert(new Pessoa
            {
                Nome = nome,
                Idade = idade
            });

            txtNome.Text = string.Empty;
            txtIdade.Text = string.Empty;

            //Após adicionar vamos atualizar a lista
            AtualizarListView();
        }
        else
            DisplayAlert("Erro",
                        "Pro favor, preencha o nome e a idade.",
                        "Ok");
    }

    private void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
    {
        //Sender = componente
        //e = valor, no caso é o item

        //validar se o item da lista é do tipo Pessoa
        //separo o item do argumento e.Item
        //Comparo se o e.Item é do tipo Pessoa
        //is  = é
        //atribuo o e.Item para a varaivel pessoa
        //pessoa passa a receber as informações de e.Item
        if (e.Item is Pessoa pessoa)
        {
            //Environment.NewLine é usado para quebra de linha
            // semelhante ao \n do HTML
            string menssagem =
                "Registro: " + pessoa.Id.ToString() + 
                Environment.NewLine +
                "Nome: " + pessoa.Nome + 
                Environment.NewLine +
                "Idade: " + pessoa.Idade;

            DisplayAlert("Detalhes da Pessoa", menssagem, "Ok");
        }

        //Limpar seleção do item
        //Preciso informar o tipo do componente ou seja o sender
        //para acessar as propriedades
        ((ListView)sender).SelectedItem = null;

    }

    private async void btnDeletar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button &&
            button.CommandParameter is Pessoa pessoa)
        {
            bool validacao = await DisplayAlert(
                                "Confirmação",
                                "Deseja realmente excluir este item?",
                                "Sim",
                                "Cancelar");

            if (validacao)
            {
                conexao.Delete(pessoa);
                AtualizarListView();
            }
        }
    }
}

