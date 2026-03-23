namespace MauiApp5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            }

            private async void OnZapiszTekstClicked(object sender, EventArgs e)
            {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "moj_plik.txt");
            string tresc = ZapisEntry.Text;

            await File.WriteAllTextAsync(sciezka, tresc);
            await DisplayAlert("Zapisano", "Notatka jest zapisana", "OK");
            }

        private async void OnOdczytajTekstClicked(object sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "moj_plik.txt");
            if (File.Exists(sciezka))
            {
                string tresc = await File.ReadAllTextAsync(sciezka);
                OdczytanyTekstLabel.Text = tresc;
            }
            else
            {
                OdczytanyTekstLabel.Text = "Brak zapisanej notatki";
            } 
        }
    }
}
