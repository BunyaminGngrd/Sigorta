namespace SigortaIslemleri;
using SigortaIslemleri.ViewModel;

public partial class SilindiPage : ContentPage
{
	public SilindiPage(SilindiViewModel mvm)
	{
		InitializeComponent(); 
        BindingContext = mvm;
    }
}
