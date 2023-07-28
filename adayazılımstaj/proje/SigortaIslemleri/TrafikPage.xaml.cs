namespace SigortaIslemleri;
using SigortaIslemleri.ViewModel;

public partial class TrafikPage : ContentPage
{
public TrafikPage(Trafik mvm)
    {


        InitializeComponent();
        BindingContext = mvm;


    }
}
