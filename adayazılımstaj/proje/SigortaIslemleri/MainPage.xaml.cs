using SigortaIslemleri.ViewModel;

namespace SigortaIslemleri
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel mvm)
        {
            InitializeComponent();
            BindingContext = mvm;
        }


    }
}