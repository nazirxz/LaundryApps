using Firebase.Database;
using Firebase.Database.Query;

namespace LaundryApps
{
    public partial class MainPage : ContentPage
    {
        private FirebaseClient firebaseClient;

        public MainPage()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient("https://laundryapps-6fbd8-default-rtdb.asia-southeast1.firebasedatabase.app/");
        }
        public void OnLabelTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Register());
        }

        public async void btnClicked(object sender, EventArgs e)
        {
            string enteredEmail = email.Text;
            string enteredPassword = password.Text;

            // Membaca data pengguna dari Firebase Realtime Database
            var user = await ReadUserFromDatabase(enteredEmail);

            if (user != null && user.Password == enteredPassword)
            {
                // Jika email dan password cocok, login berhasil
                await DisplayAlert("Login", "Login berhasil!", "OK");
                Navigation.PushAsync(new Views.MainMenu());
            }
            else
            {
                // Jika email tidak ditemukan atau password salah, tampilkan pesan kesalahan
                await DisplayAlert("Login Gagal", "Email atau password salah.", "OK");
            }
        }

        // Method untuk membaca data pengguna dari Firebase Realtime Database berdasarkan alamat email
        private async Task<User> ReadUserFromDatabase(string email)
        {
            // Mendapatkan userId dari alamat email (sesuai dengan struktur kunci yang Anda gunakan)
            string userId = email.Replace(".", "_");

            try
            {
                // Mendapatkan referensi ke node pengguna di Firebase Database
                var userReference = firebaseClient.Child("users").Child(userId);

                // Membaca data pengguna dari Firebase Database
                var userSnapshot = await userReference.OnceSingleAsync<User>();

                return userSnapshot; // Mengembalikan objek pengguna dari Firebase Database
            }
            catch (Exception ex)
            {
                // Tangani kesalahan jika ada
                Console.WriteLine("Error reading user data: " + ex.Message);
                return null; // Mengembalikan null jika terjadi kesalahan
            }
        }
    }

    // Kelas model untuk merepresentasikan data pengguna
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        // Anda dapat menambahkan properti lain sesuai kebutuhan (misalnya: Nama Pengguna, dll.)
    }
}