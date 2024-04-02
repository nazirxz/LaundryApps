namespace LaundryApps.Views;

using LaundryApps.Models;
using System.Collections.ObjectModel;
public partial class Ticket : ContentPage
{
    public ObservableCollection<Promo> Promos { get; set; }

    public Ticket()
    {
        InitializeComponent();
        InitializePromos();
        BindingContext = this;
    }
    private void InitializePromos()
    {
        Promos = new ObservableCollection<Promo>
        {
            new Promo{ Nama= "KUCEKSHOE21",Deskripsi="Bikin Sepatu kinclong! Pakai kode ini :", Image="promo1.png"},
            new Promo{ Nama= "SHOE21",Deskripsi="Bikin Sepatu kinclong! Pakai kode ini :", Image="promo2.png"}
        };
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