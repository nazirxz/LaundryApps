using Firebase.Database;
using Firebase.Database.Query;

namespace LaundryApps.Views;

public partial class Register : ContentPage
{

    public Register()
    {
        InitializeComponent();


    }
    private void OnLabelTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        // Mendapatkan data dari input pengguna (nama lengkap, alamat email, dan password)
        string namaLengkap = nama_lengkap.Text;
        string alamatEmail = email.Text;
        string kataSandi = password.Text;

        try
        {
            // Inisialisasi Firebase Realtime Database
            var firebaseClient = new FirebaseClient("https://laundryapps-6fbd8-default-rtdb.asia-southeast1.firebasedatabase.app/");
            // Simpan data pengguna ke Firebase Realtime Database
            var userReference = firebaseClient.Child("users").Child(alamatEmail.Replace(".", "_"));

            await userReference.PutAsync(new
            {
                FullName = namaLengkap,
                Email = alamatEmail,
                Password = kataSandi
            });
            await DisplayAlert("Registrasi Berhasil", "Akun Anda telah berhasil didaftarkan.", "OK");
            Navigation.PushAsync(new MainMenu());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Registrasi Gagal", $"Error: {ex.Message}", "OK");
        }
    }

}