namespace SigortaIslemleri;
using SigortaIslemleri.ViewModel;
public partial class YasayanPoliceui : ContentPage
{
	public YasayanPoliceui(YasayanPoliceler mvm)
	{
		InitializeComponent();
        BindingContext = mvm;

    }
    private int selectedPoliceId = -1; // Initialize with an invalid value

    private void listViewm_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedItem = e.SelectedItem as YasayanPoliceler.TeklifItem;
        selectedPoliceId = int.Parse(selectedItem.Column1); // Assuming Column1 holds the PoliceId
        gotur();
    }
    public async Task gotur()
    {
        PoliceDetay detay = new PoliceDetay(new PoliceDetayViewModel(selectedPoliceId));
        await Application.Current.MainPage.Navigation.PushAsync(detay);

    }
}


