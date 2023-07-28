
namespace SigortaIslemleri;
using SigortaIslemleri.ViewModel;

public partial class SaglikPage : ContentPage
{
	public SaglikPage(Saglik mvm)
	{
		InitializeComponent();
        BindingContext = mvm;

    }
}

