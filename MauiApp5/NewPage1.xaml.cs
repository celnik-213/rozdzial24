namespace MauiApp5;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
        string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
        if (File.Exists(sciezka))
        {
            string tresc = File.ReadAllText(sciezka);
            Hisotria.Text = tresc;
        }
	}
    private async void OnZapiszTekstClicked(object sender, EventArgs e)
    {
        string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
        string tresc = DateTime.Now.ToString("dd.MM.yyyy HH:mm ")+EditorWpis.Text;
        EditorWpis.Text = string.Empty;
        Hisotria.Text = Hisotria.Text + " \n " + tresc;

        await File.WriteAllTextAsync(sciezka, Hisotria.Text);
        await DisplayAlert("Zapisano", "Notatka jest zapisana", "OK");
    }
    private async void OnUsunTekstCilcked(object sender, EventArgs e)
    {
        string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
        if (File.Exists(sciezka))
        {
            File.Delete(sciezka);
        };
        Hisotria.Text = string.Empty;
    }
}