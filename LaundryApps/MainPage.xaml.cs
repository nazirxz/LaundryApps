namespace LaundryApps
{
    public partial class MainPage : ContentPage
    {
     
        public MainPage()
        {
            InitializeComponent();
        }
        public void OnLabelTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Register());
        }

        public void btnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.MainMenu());
        }
    }

}
