using MySql.Data.MySqlClient;

namespace veritabani
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnKayitOlButtonClicked(object sender, EventArgs e)
        {
            // Kullanıcı bilgilerini al
            var ad = AdEntry.Text;
            var soyad = SoyadEntry.Text;
            var telefon = TelefonEntry.Text;
            var eposta = EpostaEntry.Text;
            var sifre = SifreEntry.Text;

            // Kullanıcı bilgilerini veritabanına kaydet
            try
            {
                using (var connection = new MySqlConnection(App.ConnectionString))
                {
                    await connection.OpenAsync();
                    var query = "INSERT INTO kullanicilar (adi, soyad, telefon, mail, sifre) VALUES (@Ad, @Soyad, @Telefon, @Eposta, @Sifre)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ad", ad);
                        command.Parameters.AddWithValue("@Soyad", soyad);
                        command.Parameters.AddWithValue("@Telefon", telefon);
                        command.Parameters.AddWithValue("@Eposta", eposta);
                        command.Parameters.AddWithValue("@Sifre", sifre);
                        await command.ExecuteNonQueryAsync();
                    }
                }
                // Ana sayfaya yönlendirme
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", $"Kullanıcı kaydedilirken bir hata oluştu: {ex.Message}", "Tamam");
            }
        }
    }
}
