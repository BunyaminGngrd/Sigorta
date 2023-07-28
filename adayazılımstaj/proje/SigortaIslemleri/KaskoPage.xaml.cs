using SigortaIslemleri.ViewModel;

namespace SigortaIslemleri;

public partial class KaskoPage : ContentPage
{
	public KaskoPage(Kasko mvm)
	{
		InitializeComponent();
        BindingContext = mvm;
    }
}

