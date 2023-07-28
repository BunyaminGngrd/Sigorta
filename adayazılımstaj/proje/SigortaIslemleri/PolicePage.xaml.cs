using SigortaIslemleri.ViewModel;


namespace SigortaIslemleri;



public partial class PolicePage : ContentPage
{
	public PolicePage(PoliceViewModel mvm)
	{
		InitializeComponent();
		BindingContext = mvm;
	}
}