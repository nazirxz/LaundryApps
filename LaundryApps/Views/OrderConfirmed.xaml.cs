using LaundryApps.Models;
namespace LaundryApps.Views;

public partial class OrderConfirmed : ContentPage
{
    public User User { get; set; }
    public OrderConfirmed()
    {
        InitializeComponent();
    }
    public OrderConfirmed(User user)
    {
        InitializeComponent();
        User = user;
    }
    private void btnHome(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainMenu(User));
    }
}