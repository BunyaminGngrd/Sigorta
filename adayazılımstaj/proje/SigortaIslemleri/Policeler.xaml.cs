using SigortaIslemleri.ViewModel;
using System.Diagnostics;

namespace SigortaIslemleri;

public partial class Policeler : ContentPage
{
	public Policeler(TumPoliceler mvm)
	{
		InitializeComponent();
        BindingContext = mvm;

    }
    private int selectedPoliceId = -1; // Initialize with an invalid value
    private void listViewm_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedItem = e.SelectedItem as TumPoliceler.TeklifItem;
        selectedPoliceId = int.Parse(selectedItem.Column1); // Assuming Column1 holds the PoliceId
        gotur();


    }
    public async Task gotur()
    {
        PoliceDetay detay = new PoliceDetay(new PoliceDetayViewModel(selectedPoliceId));
        await Application.Current.MainPage.Navigation.PushAsync(detay);

    }
}

