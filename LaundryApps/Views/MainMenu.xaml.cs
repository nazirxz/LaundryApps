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
	private void HomeTapped(object sender, EventArgs e) 
	{
		Navigation.PushAsync(new MainMenu());
	}
	private void HistoryTapped(object sender, EventArgs e)
	{
		
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
		Navigation.PushAsync(new Order());
	}
}