using AppRevisao.Models;
using AppRevisao.Controllers;
using AppRevisao.Services;

namespace AppRevisao.Views;

public partial class pgJogosCadastroView : ContentPage
{
    private JogosController jogosController =
    new JogosController();

    //Atributo privado que irá armazenar qual a
    //ação na tela deverá ser executada
    AcaoTelaService acaoSelecionada;
    Jogos jogosCadastro;
    bool IsAlteracao = false;
    int IdCadastro = 0;

    public pgJogosCadastroView(
        AcaoTelaService acaoTela, Jogos jogos)
	{
        InitializeComponent();
        acaoSelecionada = acaoTela;
        jogosCadastro = jogos;

        if (acaoSelecionada == AcaoTelaService.Inserir)
            txtTitulo.Text = "Cadastrar";
        else
        {
            CarregarCamposCadastro();

            if (acaoSelecionada == AcaoTelaService.Alterar)
            {
                txtTitulo.Text = "Editar";
                IsAlteracao = true;
            }
            else
            {
                txtTitulo.Text = "Visualizar";
                VisualizarCampos();
            }
        }
    }

    private void CarregarCamposCadastro()
    {
        IdCadastro = jogosCadastro.JogosID;
        txtBixo.Text = jogosCadastro.Bixo;
        txtNumero.Text = jogosCadastro.Numero.ToString();
        txtJogador.Text = jogosCadastro.Jogador;
    }

    private void VisualizarCampos()
    {
        txtBixo.IsReadOnly = true;
        txtNumero.IsReadOnly = true;
        txtJogador.IsReadOnly = true;
        btnSalvar.IsVisible = false;
    }

    private void LimparCampos()
    {
        txtBixo.Text = string.Empty;
        txtNumero.Text = string.Empty;
        txtJogador.Text = string.Empty;
    }

    private async void VoltarPagina()
    {
        await Application.Current.
            MainPage.Navigation.PopAsync();
    }

    private void btnVoltar(object sender, EventArgs e)
    {
        VoltarPagina();
    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        SalvarCadastro();
    }

    private void SalvarCadastro()
    {
        string bixo, numero, jogador;
        bool registroSalvo = false;

        bixo = txtBixo.Text;
        numero = txtNumero.Text;
        jogador = txtJogador.Text;

        if (!string.IsNullOrEmpty(bixo) &&
           !string.IsNullOrEmpty(numero) &&
           !string.IsNullOrEmpty(jogador))
        {
            Jogos jogos = new Jogos();

            jogos.Bixo = bixo;
            //Nao estamos validando se
            //possue somento numero
            //se passar letra vai dar erro aqui
            jogos.Numero = int.Parse(numero);
            jogos.Jogador = jogador;

            if (IsAlteracao)
            {
                jogos.JogosID = IdCadastro;
                registroSalvo =
                    jogosController.Update(jogos);
            }
            else
                registroSalvo =
                    jogosController.Insert(jogos);

            if (registroSalvo)
            {
                DisplayAlert("Informação",
                    "Registro salvo com sucesso!.",
                    "Ok");

                if (IsAlteracao)
                    VoltarPagina();
                else
                    LimparCampos();
            }
            else
                DisplayAlert("Erro",
                    "Falha ao savar registro!.",
                    "Ok");
        }
        else
            DisplayAlert("Atenção",
                "Preencha os campos corretamente.",
                "Ok");
    }
}