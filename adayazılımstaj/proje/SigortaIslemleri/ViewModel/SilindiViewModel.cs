using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigortaIslemleri.ViewModel
{
    public partial class SilindiViewModel : ObservableObject
    {
        int polid = 0;


        private HttpClient client;
        public static string apiUrl =
               DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7077/api/Police/" : "https://localhost:7077/api/Police/";


        public SilindiViewModel(int polid)
        {
            client = CreateHttpClient();

            this.polid = polid;
            Debug.WriteLine(polid);

        }


        [RelayCommand]
        async Task ClickSil()
        {
            Debug.WriteLine(polid);
            string url = apiUrl + polid;
            var response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert("Başarılı", "Veri Silinmiştir", "Tamam");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Uyarı", "Hata Oluştu. Tekrar deneyiniz.", "Tamam");
            }
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