using AppCriptografia.Models;
using AppCriptografia.Controllers;
using AppCriptografia.Services;

namespace AppCriptografia.Views;

public partial class pgLoginView : ContentPage
{
    UsuarioController usuarioController =
        new UsuarioController();
	public pgLoginView()
	{
		InitializeComponent();
	}

    private void MostrarSenha()
    {
        txtSenha.IsPassword = 
            !ckbMostrarSenha.IsChecked;
    }

    private void ckbMostrarSenha_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        MostrarSenha();
    }

    private void tapMostrarSenha_Tapped(object sender, TappedEventArgs e)
    {
        ckbMostrarSenha.IsChecked =
            !ckbMostrarSenha.IsChecked;
        MostrarSenha();
    }

    private void btnEntrar_Clicked(object sender, EventArgs e)
    {
        Entrar();
    }

    private void Entrar()
    {
        string email, senha;

        email = txtEmail.Text;
        senha = txtSenha.Text;

        if (!string.IsNullOrEmpty(email) &&
           !string.IsNullOrEmpty(senha))
        {
            Usuario usuario = new Usuario();
            usuario = usuarioController.GetByEmail(email);

            if (usuario == null)
                DisplayAlert("Atenção",
                    "Email inválido", 
                    "Ok");
            else
            {
                if (CriptografiaService.
                    Decodificar(usuario.Senha) ==
                    senha)
                {
                    Application.Current.MainPage.Navigation.
                        PushAsync(new pgUsuarioListaView());
                }
                else
                    DisplayAlert("Atenção",
                        "Senha inválida",
                        "Ok");
            }
        }
        else
            DisplayAlert("Atenção",
                "Informe os dados de Login corretamente!.",
                "Ok");
    }

    private void tapCadastrar_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage.Navigation.
            PushAsync(new pgUsuarioCadastroView(
                AcaoTelaService.Inserir, null));
    }
}