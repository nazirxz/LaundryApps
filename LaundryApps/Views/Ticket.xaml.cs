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
}