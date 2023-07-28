using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Newtonsoft.Json;

namespace SigortaIslemleri.ViewModel
{
    public partial class PoliceViewModel : ObservableObject
    {


        int userid = 0;
        public PoliceViewModel(int id){


            this.userid= id;
            client = CreateHttpClient();

        }


        private string _veritabanıBilgisi;
        public string VeritabanıBilgisi
        {
            get { return _veritabanıBilgisi; }
            set { SetProperty(ref _veritabanıBilgisi, value); }
        }
        public class Police
        {
            public string SonTarih { get; set; }
            public int KulId { get;  set; }
            public string PoliceGrup { get;  set; }
            public string PoliceDetay { get;  set; }
            public object PoliceId { get;  set; }
        }


        private HttpClient client;
        public static string BaseAddress =
        DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7077" : "https://localhost:7077";
        string TodoItemsUrl = $"{BaseAddress}/api/Police";

        [RelayCommand]
        public async Task first()
        {

            YasayanPoliceui policeler = new YasayanPoliceui(new YasayanPoliceler(userid));
            await Application.Current.MainPage.Navigation.PushAsync(policeler);

        }
        [RelayCommand]
        public async void second()
        {
            Policeler policeler = new Policeler(new TumPoliceler(userid));
            await Application.Current.MainPage.Navigation.PushAsync(policeler);
        }



        [RelayCommand]
        public async void Teklif()
        {

            TeklifPage teklif = new TeklifPage(new TeklifViewModel(userid));
            await Application.Current.MainPage.Navigation.PushAsync(teklif);




        }


        [RelayCommand]
        public async void Sil()
        {

            VeriSilPage teklif = new VeriSilPage(new VeriSilViewModel(userid));
            await Application.Current.MainPage.Navigation.PushAsync(teklif);


        }




        private HttpClient CreateHttpClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                }
            };

            return new HttpClient(httpClientHandler);
        }

    }
}
