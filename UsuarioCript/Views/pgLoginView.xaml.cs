using UsuarioCript.Controllers;
using UsuarioCript.Models;
using UsuarioCript.Services;

namespace UsuarioCript.Views;

public partial class pgLoginView : ContentPage
{
    //Importar Models
    //Importar Controllers

    //Criar instancia da classe controller
    private UsuarioController usuarioController =
        new UsuarioController();

    public pgLoginView()
	{
		InitializeComponent();
	}

    private void MostrarSenha()
    {
        txtSenha.IsPassword = !ckbMostrarSenha.IsChecked;
    }

    private void ckbMostrarSenha_CheckdChanged(object sender, CheckedChangedEventArgs e)
    {
        MostrarSenha();
    }

    private void tapMostraSenha_Tapped(object sender, TappedEventArgs e)
    {
        ckbMostrarSenha.IsChecked = !ckbMostrarSenha.IsChecked;
        MostrarSenha();
    }

    private void tapCadastrar_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage.Navigation.
                PushAsync(new pgUsuarioCadastroView(AcaoTelaService.Inserir, null));
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
            try
            {
                //Recuperar o registro que possua o email informado
                //E atribuido o retorno ao objeto user
                Usuario usuario = new Usuario();
                usuario = usuarioController.GetByEmail(email);

                if (usuario == null) //verifica se o retorno foi nulo
                        DisplayAlert("Atenção", "Email inválido.", "Ok");

                else
                {
                    if (CriptografiaService.Decodificar(usuario.Senha) == senha) //valida a senha carregada no objeto
                        Application.Current.MainPage.Navigation.
                            PushAsync(new pgUsuarioListaView());
                    else
                    {
                        DisplayAlert("Atenção", "Senha inválida.", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                //Tratamento de exceção para subir mensagem de erro ao usuário
                DisplayAlert("Erro", "Falha ao validar Login.\r\n"+
                                     "Erro original: " + ex.Message, "Ok");
            }
        }
        else
            DisplayAlert("Atenção",
                         "Informe os dados de Login corretamente.",
                         "Ok");
    }

    private void tapBurlar_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current.MainPage.Navigation.
                            PushAsync(new pgUsuarioListaView());
    }
}