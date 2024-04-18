using LaundryApps.ViewModel.LaundryApps.ViewModel;

namespace LaundryApps.Views;

public partial class Order : ContentPage
{

    private bool _isSelected = false;
    public Color SelectedBorderColor { get; set; } = Color.FromHex("#FFFFFF");
    public Order()
    {

        InitializeComponent();
        BindingContext = new DateViewModel();

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

        // If DateViewModel implements INotifyPropertyChanged, trigger the PropertyChanged event
        // for the BorderColor property of the selected frame
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

        // If DateViewModel implements INotifyPropertyChanged, trigger the PropertyChanged event
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
    private void btnOrder(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OrderConfirmed());
    }
}