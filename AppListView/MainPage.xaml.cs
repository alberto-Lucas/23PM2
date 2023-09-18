using System.Collections.ObjectModel;
using System.Linq;
using PCLExt.FileStorage.Folders;
using SQLite;


namespace AppListView;

public partial class MainPage : ContentPage
{
    //Instalar Nuget sqlite-net-pcl (icone pena)
    //Instalar Nuget pclext.filestorage

    //Variavel responsavel pela conexao com o BD
    private SQLiteConnection conexao;

    //Removo a nossa coleção do objeto Pessoa
    //ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();
        
    public class Pessoa
    {
        //Adiciona a propriedade Id e defino as propriedades
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
    }

    //Crio uma função para retornar a conexão com o BD
    public SQLiteConnection GetConnection()
    {
        var folder = new LocalRootFolder();
        //Definimos o nome do banco de dados
        //Configuramos para caso o arquivo não exista seja criado
        //Caso exista seja atualizado
        var file = folder.CreateFile("list.db3", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

        //Retorna a conexao criada com o banco de dados
        return new SQLiteConnection(file.Path);
    }

    public MainPage()
    {
        InitializeComponent();
        //Removo a atribuição da coleção ao Source da lista
        //lsvLista.ItemsSource = pessoas;
        /*
        pessoas.Add(new Pessoa
        {
            Nome = "Lucas",
            Idade = "0"
        });
        */

        //Abre a conexão com o BD
        conexao = GetConnection();
        //Mapear a classe para criação de tabela
        conexao.CreateTable<Pessoa>(); 
        AtualizarListView();
    }

    private void AtualizarListView()
    {
        lsvLista.ItemsSource = conexao.Table<Pessoa>().ToList();
    }

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        string nome = txtNome.Text;
        string idade = txtIdade.Text;

        if (!string.IsNullOrEmpty(nome) &&
            !string.IsNullOrEmpty(idade))
        {
            /*
            pessoas.Add(new Pessoa
            {
                Nome = nome,
                Idade = idade
            });*/

            conexao.Insert(new Pessoa 
            { 
                Nome = nome, 
                Idade = idade 
            });
            
            txtNome.Text = string.Empty;
            txtIdade.Text = string.Empty;

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
        //e = valor no caso o item

        //valida se o item da lista é do tipo Pessoa
        if (e.Item is Pessoa pessoa)
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
                conexao.Delete(item);
                AtualizarListView(); // Atualize a ListView após a exclusão.
            }
        }
    }
}

