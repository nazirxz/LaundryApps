namespace LaundryApps.Views;

public partial class OrderConfirmed : ContentPage
{
	public OrderConfirmed()
	{
		InitializeComponent();
	}
	private void btnHome(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainMenu());
    }
}