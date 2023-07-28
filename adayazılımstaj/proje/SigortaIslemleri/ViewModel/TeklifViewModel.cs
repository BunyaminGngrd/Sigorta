using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace SigortaIslemleri.ViewModel
{
    public partial class TeklifViewModel : ObservableObject
    {
        int userid = 0;
        public TeklifViewModel(int userid)
        {
            this.userid = userid;

        }
    [RelayCommand]
    async void Trafik()
        {
            TrafikPage policePage = new TrafikPage(new Trafik(userid));
            await Application.Current.MainPage.Navigation.PushAsync(policePage);


        }

        [RelayCommand]
        async void Dask()
        {
            DaskPage policePage = new DaskPage(new Dask(userid));
            await Application.Current.MainPage.Navigation.PushAsync(policePage);


        }


        [RelayCommand]
        async void Kasko()
        {
            KaskoPage policePage = new KaskoPage(new Kasko(userid));
            await Application.Current.MainPage.Navigation.PushAsync(policePage);


        }


        [RelayCommand]
        async void Saglik()
        {
            SaglikPage policePage = new SaglikPage(new Saglik(userid));
            await Application.Current.MainPage.Navigation.PushAsync(policePage);


        }

    }
}
