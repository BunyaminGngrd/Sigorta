using SigortaIslemleri.ViewModel;

namespace SigortaIslemleri;

public partial class TeklifPage : ContentPage
{
public TeklifPage(TeklifViewModel mvm)
    {
        InitializeComponent();
        BindingContext = mvm;

    }
}