using AppCriptografia.Controllers;
using AppCriptografia.Models;
using AppCriptografia.Services;

namespace AppCriptografia.Views;

public partial class pgUsuarioCadastroView : ContentPage
{
    private UsuarioController usuarioController =
        new UsuarioController();

    //Atributo privado que irá armazenar qual a
    //ação na tela deverá ser executada
    AcaoTelaService acaoSelecionada;
    Usuario usuarioCadastro;
    bool IsAlteracao = false;
    int IdCadastro = 0;

	public pgUsuarioCadastroView(
        AcaoTelaService acaoTela, Usuario usuario)
	{
		InitializeComponent();
        acaoSelecionada = acaoTela;
        usuarioCadastro = usuario;

        if (acaoSelecionada == AcaoTelaService.Inserir)
            txtTitulo.Text = "Cadastrar";
        else
        {
            CarregarCamposCadastro();

            if(acaoSelecionada == AcaoTelaService.Alterar)
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
        IdCadastro = usuarioCadastro.ID;
        txtNome.Text = usuarioCadastro.Nome;
        txtEmail.Text = usuarioCadastro.Email;
        txtSenha.Text = 
            CriptografiaService.Decodificar(
                usuarioCadastro.Senha);
    }

    private void VisualizarCampos()
    {
        txtNome.IsReadOnly = true;
        txtEmail.IsReadOnly = true;
        txtSenha.IsReadOnly = true;
        btnSalvar.IsVisible = false;
    }

    private void LimparCampos()
    {
        txtNome.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtSenha.Text = string.Empty;
    }

    private void btnVoltar(object sender, EventArgs e)
    {
        VoltarPagina();
    }

    private void ckbMostrarSenha_Checked(object sender, CheckedChangedEventArgs e)
    {
        MostrarSenha();
    }

    private void tapMostraSenha(object sender, TappedEventArgs e)
    {
        ckbMostrarSenha.IsChecked = 
            !ckbMostrarSenha.IsChecked;
        MostrarSenha();
    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        SalvarCadastro();
    }

    private void SalvarCadastro()
    {
        string nome, email, senha;
        bool registroSalvo = false;

        nome = txtNome.Text;
        email = txtEmail.Text;
        senha = txtSenha.Text;

        if (!string.IsNullOrEmpty(nome) &&
           !string.IsNullOrEmpty(email) &&
           !string.IsNullOrEmpty(senha))
        {
            Usuario usuario = new Usuario();

            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = 
                CriptografiaService.Codificar(senha);

            if (IsAlteracao)
            {
                usuario.ID = IdCadastro;
                registroSalvo =
                    usuarioController.Update(usuario);
            }
            else
                registroSalvo =
                    usuarioController.Insert(usuario);

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

    private async void VoltarPagina()
    {
        await Application.Current.
            MainPage.Navigation.PopAsync();
    }

    private void MostrarSenha()
    {
        txtSenha.IsPassword = !ckbMostrarSenha.IsChecked;
    }
}