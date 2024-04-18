using LaundryApps.Models;
namespace LaundryApps.Views;

public partial class HistoryCucian : ContentPage
{
    public User User { get; set; }
    public HistoryCucian(Models.User user)
    {
        InitializeComponent();
    }

    private void btnBack(object sender, EventArgs e)
    {
        // Lakukan navigasi kembali ke halaman sebelumnya di sini
        if (Navigation != null)
        {
            Navigation.PopAsync(); // Jika Anda menggunakan NavigationPage

        }
    }
}