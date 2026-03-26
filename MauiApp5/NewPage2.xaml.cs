namespace MauiApp5;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}
    private async void OnEksportClicked(object sender, EventArgs e)
    {
        string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "notatki_eksport.txt");
        string tresc = DateTime.Now.ToString("dd.MM.yyyy HH:mm ") + "\n" + EditorWpis.Text + "\n";

        await File.WriteAllTextAsync(sciezka, tresc);
        Informacja.Text = Informacja.Text + "\n" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "Eksport";
    }

    private async void OnImportClicked(object sender, EventArgs e)
    {
        try
        {
            var wynik = await FilePicker.Default.PickAsync();
            if (wynik != null)

            {
                string nazwaPliku = wynik.FileName;
                string pelnaSciezka = wynik.FullPath;
                await DisplayAlert("Wybrano plik", $"Nazwa: {nazwaPliku}", "OK");
                string tresc = await File.ReadAllTextAsync(pelnaSciezka);
                EditorWpis.Text = tresc;
                Informacja.Text = Informacja.Text + "\n" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "Import";
            }
        }

        catch (Exception ex)

        {
            await DisplayAlert("Błąd", $"Nie udało się wybrać pliku: {ex.Message}", "OK");

        }

    }
}
