using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Security;
using System.Threading.Tasks;


namespace SigortaIslemleri.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private HttpClient client;
        public static string BaseAddress =
         DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7077" : "https://localhost:7077";


        public MainViewModel()
        {
            client = CreateHttpClient();
        }

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        public async Task ClickLogin()
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Uyarı", "Kullanıcı adı ve şifre gereklidir", "Tamam");
                });
                return;
            }

            string TodoItemsUrl = $"{BaseAddress}/api/Bilgiler/" + username + "/" + password;


            try { 
                HttpResponseMessage response = await client.GetAsync(TodoItemsUrl);

                if (response.IsSuccessStatusCode)
                {
                    var userId = JsonConvert.DeserializeObject<Bilgiler>(response.Content.ReadAsStringAsync().Result).Id;
                    Debug.WriteLine(userId);
                    PolicePage policePage = new PolicePage(new PoliceViewModel(userId));
                    await Application.Current.MainPage.Navigation.PushAsync(policePage);
                }
                else
                {
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Uyarı", "Kullanıcı Bulunamadı", "Tamam");
                    });
                }
            }
            catch
            {

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Hata", "Hatalı İşlem Tekrar Deneyiniz", "Tamam");
                });

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
        public class Bilgiler
        {
            public int Id { get; set; }

        }


    }


}