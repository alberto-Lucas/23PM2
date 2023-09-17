using System.Collections.ObjectModel;

namespace AppListView;

public partial class MainPage : ContentPage
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Idade { get; set; }
    }
    ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();

    public MainPage()
    {
        InitializeComponent();
        lsvLista.ItemsSource = pessoas;
        pessoas.Add(new Pessoa
        {
            Nome = "Lucas",
            Idade = "0"
        });
    }

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        string nome = txtIdade.Text;
        string idade = txtIdade.Text;

        if (!string.IsNullOrEmpty(nome) &&
            !string.IsNullOrEmpty(idade))
        {
            pessoas.Add(new Pessoa
            {
                Nome = nome,
                Idade = idade
            });
            txtNome.Text = string.Empty;
            txtIdade.Text = string.Empty;
        }
        else
            DisplayAlert("Erro",
                        "Pro favor, preencha o nome e a idade.",
                        "Ok");
    }
}

