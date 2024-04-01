using LaundryApps.Models;
using System.Collections.ObjectModel;

namespace LaundryApps.Views;

public partial class MainMenu : ContentPage
{
	public ObservableCollection<Promo> Promos { get; set; }
	public MainMenu()
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