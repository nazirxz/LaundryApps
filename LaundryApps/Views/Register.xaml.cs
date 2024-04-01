namespace LaundryApps.Views;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}
    private void OnLabelTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}