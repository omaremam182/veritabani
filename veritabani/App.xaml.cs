namespace veritabani
{
    public partial class App : Application
    {

        public static string ConnectionString = "server=localhost;user=non;password=Pass123!;database=db_t;";

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
