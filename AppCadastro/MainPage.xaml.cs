using AppCadastro.Views;

namespace AppCadastro;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		AnimacaoLogo();
    }

	async void AnimacaoLogo()
	{
		await Task.Delay(50); //1 segundo
		imgLogo.Rotation = 0;
		//Girar 360 graus no sentido horario
		imgLogo.RotateTo(360, 50);
		imgLogo.Rotation = 0;
		await Task.Delay(50);
		
		//Importart o using da pasta Views
		Application.Current.MainPage =
			new NavigationPage(new pgPrincipal());
	}
}

