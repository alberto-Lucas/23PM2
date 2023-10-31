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

        //continua
	}

    private void btnVoltar(object sender, EventArgs e)
    {

    }

    private void ckbMostrarSenha_Checked(object sender, CheckedChangedEventArgs e)
    {

    }

    private void tapMostraSenha(object sender, TappedEventArgs e)
    {

    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {

    }
}