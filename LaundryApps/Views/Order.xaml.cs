namespace LaundryApps.Views;

public partial class Order : ContentPage
{
	public Order()
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