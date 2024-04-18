using LaundryApps.Models;
using System.Collections.ObjectModel;
namespace LaundryApps.Views;

public partial class MainMenu : ContentPage
{
    public User User { get; set; }
    public ObservableCollection<Promo> Promos { get; set; }

    public MainMenu()
    {
        InitializeComponent();
        User = new User(); // Inisialisasi objek User
        InitializePromos();
        BindingContext = this; // Set BindingContext ke objek MainMenu
    }

    public MainMenu(User user)
    {
        InitializeComponent();
        User = user;
        InitializePromos();
        BindingContext = this; // Set BindingContext ke objek MainMenu
    }

    private void InitializePromos()
    {
        Promos = new ObservableCollection<Promo>
            {
                new Promo { Nama = "KUCEKSHOE21", Deskripsi = "Bikin Sepatu kinclong! Pakai kode ini :", Image = "promo1.png" },
                new Promo { Nama = "SHOE21", Deskripsi = "Bikin Sepatu kinclong! Pakai kode ini :", Image = "promo2.png" }
            };

        OnPropertyChanged(nameof(Promos)); // Memastikan UI diperbarui dengan perubahan pada koleksi
    }

    private void HomeTapped(object sender, EventArgs e)
    {
        // Tidak perlu membuat instance baru, cukup update BindingContext
        BindingContext = this;
    }

    private void HistoryTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HistoryCucian(User));
    }

    private void TicketTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Ticket());
    }

    private void LihatSemuaTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Ticket());
    }

    private void LayananTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Order(User));
    }
}
