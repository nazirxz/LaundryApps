using Firebase.Database;
using Firebase.Database.Query;
using LaundryApps.Models;
using LaundryApps.ViewModel.LaundryApps.ViewModel;
namespace LaundryApps.Views;

public partial class Order : ContentPage
{

    private bool _isSelected = false;
    public User User { get; set; }
    string selecteddate = "";
    string selectedtime = "";
    public Color SelectedBorderColor { get; set; } = Color.FromHex("#FFFFFF");

    public Order()
    {
        InitializeComponent();
        BindingContext = new OrderViewModel();
    }
    public Order(User user)
    {
        InitializeComponent();
        User = user;
        BindingContext = new OrderViewModel { User = user };
    }


    private void BorderTapped(object sender, EventArgs e)
    {
        var tappedFrame = (Frame)sender;
        _isSelected = !_isSelected;

        // Deselect all frames
        foreach (var frame in new[] { frame1, frame2, frame3, frame4 })
        {
            frame.BackgroundColor = Color.FromHex("#FFFFFF");
        }

        // Select the tapped frame
        tappedFrame.BackgroundColor = _isSelected ? Color.FromHex("#F691CD") : Color.FromHex("#FFFFFF");

        // Get the selected value from the Children property of the tapped frame
        if (tappedFrame.Content is StackLayout stackLayout)
        {
            var nextDayLabel = (Label)stackLayout.Children[0];
            var monthLabel = (Label)stackLayout.Children[1];
            var nextDateLabel = (Label)stackLayout.Children[2];

            selecteddate = nextDayLabel.Text + " " + monthLabel.Text + " " + nextDateLabel.Text;
        }
    }
    private void TimeTapped(object sender, EventArgs e)
    {
        var tappedBorder = (Border)sender;
        _isSelected = !_isSelected;

        // Deselect all time borders
        foreach (var border in new[] { jam10, jam12, jam13, jam15 })
        {
            border.BackgroundColor = Color.FromHex("#FFFFFF");
        }

        // Select the tapped border
        tappedBorder.BackgroundColor = _isSelected ? Color.FromHex("#F691CD") : Color.FromHex("#FFFFFF");

        if (tappedBorder == jam10)
        {
            selectedtime = "10:00";
        }
        else if (tappedBorder == jam12)
        {
            selectedtime = "12:00";
        }
        else if (tappedBorder == jam13)
        {
            selectedtime = "13:00";
        }
        else if (tappedBorder == jam15)
        {
            selectedtime = "15:00";
        }

        // If OrderViewModel implements INotifyPropertyChanged, trigger the PropertyChanged event
        // for the SelectedTimeBorderColor property
    }
    private void btnBack(object sender, EventArgs e)
    {
        // Lakukan navigasi kembali ke halaman sebelumnya di sini
        if (Navigation != null)
        {
            Navigation.PopAsync(); // Jika Anda menggunakan NavigationPage

        }
    }
    private async void btnOrder(object sender, EventArgs e)
    {
        // Mendapatkan data dari input pengguna (nama lengkap, alamat email, dan password)
        string alamat = alamatEntry.Text;
        string harijemput = selecteddate;
        string jamjemput = selectedtime;
        string jenispaket = picker.SelectedItem.ToString();
        string jenislayanan = pickerlayanan.SelectedItem.ToString();

        try
        {
            // Inisialisasi Firebase Realtime Database
            var firebaseClient = new FirebaseClient("https://laundryapps-6fbd8-default-rtdb.asia-southeast1.firebasedatabase.app/");

            // Generate a unique key for the order
            string uniqueKey = Guid.NewGuid().ToString();

            // Simpan data pengguna ke Firebase Realtime Database
            var userReference = firebaseClient
           .Child("orders")
           .Child(User.Fullname)
           .Child(Guid.NewGuid().ToString());


            await userReference.PutAsync(new
            {

                Alamat = alamat,
                HariJemput = harijemput,
                JamJemput = jamjemput,
                JenisPaket = jenispaket,
                JenisLayanan = jenislayanan
            });

            await Navigation.PushAsync(new OrderConfirmed(User));
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during the database operation
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}