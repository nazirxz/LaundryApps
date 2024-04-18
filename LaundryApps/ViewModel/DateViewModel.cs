using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LaundryApps.ViewModel
{

    namespace LaundryApps.ViewModel
    {
        public class DateViewModel : INotifyPropertyChanged
        {
            private Color _borderColor;
            public string Day { get; set; }
            public string Month { get; set; }
            public string Date { get; set; }
            public Color BorderColor
            {
                get { return _borderColor; }
                set
                {
                    _borderColor = value;
                    OnPropertyChanged();
                }
            }
            public string NextDay { get; set; }
            public string NextDate { get; set; }
            public string NextDay2 { get; set; }
            public string NextDate2 { get; set; }
            public string NextDay3 { get; set; }
            public string NextDate3 { get; set; }

            public DateViewModel()
            {
                // Mendapatkan tanggal saat ini
                var currentDate = DateTime.Now;

                // Mengatur nama hari dalam bahasa Indonesia
                Day = currentDate.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));

                // Mengatur nama bulan dalam bahasa Indonesia
                Month = currentDate.ToString("MMMM", new System.Globalization.CultureInfo("id-ID"));

                // Mengatur tanggal
                Date = currentDate.Day.ToString();
                NextDay = currentDate.AddDays(1).ToString("dddd", new System.Globalization.CultureInfo("id-ID"));
                NextDate = currentDate.AddDays(1).Day.ToString();
                NextDay2 = currentDate.AddDays(2).ToString("dddd", new System.Globalization.CultureInfo("id-ID"));
                NextDate2 = currentDate.AddDays(2).Day.ToString();
                NextDay3 = currentDate.AddDays(3).ToString("dddd", new System.Globalization.CultureInfo("id-ID"));
                NextDate3 = currentDate.AddDays(3).Day.ToString();

                // Set the initial border color to white
                BorderColor = Color.FromHex("#FFFFFF");
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}