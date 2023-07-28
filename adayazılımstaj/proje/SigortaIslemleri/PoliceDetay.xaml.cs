using SigortaIslemleri.ViewModel;

namespace SigortaIslemleri;

public partial class PoliceDetay : ContentPage
{
	public PoliceDetay(PoliceDetayViewModel mvm)
	{
        InitializeComponent();
        BindingContext = mvm;
    }
}