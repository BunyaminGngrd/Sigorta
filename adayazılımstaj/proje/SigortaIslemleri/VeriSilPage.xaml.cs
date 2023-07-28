namespace SigortaIslemleri;
using SigortaIslemleri.ViewModel;

public partial class VeriSilPage : ContentPage
{
	public VeriSilPage(VeriSilViewModel mvm)
	{
		InitializeComponent();
        BindingContext = mvm;

    }
    private int selectedPoliceId = -1; // Initialize with an invalid value

    private void listViewm_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedItem = e.SelectedItem as VeriSilViewModel.TeklifItem;
        selectedPoliceId = int.Parse(selectedItem.Column1); // Assuming Column1 holds the PoliceId
        gotur();
    }
    public async Task gotur()
    {
        SilindiPage detay = new SilindiPage(new SilindiViewModel(selectedPoliceId));
        await Application.Current.MainPage.Navigation.PushAsync(detay);

    }
}
