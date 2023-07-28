using SigortaIslemleri.ViewModel;

namespace SigortaIslemleri;

public partial class DaskPage : ContentPage
{
	public DaskPage(Dask mvm)
	{
		InitializeComponent();
        BindingContext = mvm;

    }
}