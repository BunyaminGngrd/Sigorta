using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigortaIslemleri.ViewModel
{
    public partial class Saglik: ObservableObject
    {
        private HttpClient client;
        public static string apiUrl =
         DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7077/api/Saglik/" : "https://localhost:7077/api/Saglik/";
        public static string apiUrl2 =
               DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7077/api/Police/" : "https://localhost:7077/api/Police/";



        [ObservableProperty]
        string username;

        [ObservableProperty]
        long tc;


        [ObservableProperty]
        string email;

        [ObservableProperty]
        string sagliksigorta;

        [ObservableProperty]
        string mulkiyet;

        [ObservableProperty]
        string teminatlar;

        int userid = 0;
        public Saglik(int userid)
        {
            client = CreateHttpClient();

            this.userid = userid;

        }
        [RelayCommand]
        public async Task ClickEkle()
        {
            try
            {
                if (tc.ToString().Length <= 10)
                {
                    await Application.Current.MainPage.DisplayAlert("Uyarı", "Tc 11 haneli olmalıdır!", "Tamam");
                }
                else
                {
                    int prim = new Random().Next(1000, 10000);

                    var json = new JObject();
                    json["Tc"] = tc;
                    json["Name"] = username;
                    json["Email"] = email;
                    json["TanzimTarihi"] = DateTime.Now.ToString("yyyy-MM-dd");
                    json["VadeBaslangic"] = DateTime.Now.ToString("yyyy-MM-dd");
                    json["VadeBitis"] = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
                    json["Prim"] = prim;
                    json["Sagliksigorta"] = sagliksigorta;

                    var json1 = new JObject();
                    json1["PoliceGrup"] = "Sağlık";
                    json1["SonTarih"] = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
                    json1["PoliceDetay"] = "Lorem";
                    json1["KulId"] = userid;
                    json1["TanzimTarihi"] = DateTime.Now.ToString("yyyy-MM-dd");
                    json1["VadeBaslangic"] = DateTime.Now.ToString("yyyy-MM-dd");
                    json1["VadeBitis"] = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
                    json1["Teminatlar"] = teminatlar;
                    json1["SigortalananMulkiyet"] = mulkiyet;
                    json1["Prim"] = prim;

                    var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                    var content1 = new StringContent(json1.ToString(), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(apiUrl, content);
                    var response1 = await client.PostAsync(apiUrl2, content1);

                    if (response.IsSuccessStatusCode)
                    {
                        await Application.Current.MainPage.DisplayAlert("Başarı", "Poliçeniz Eklenmiştir", "Tamam");

                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Uyarı", "Hatalı Giriş Yaptınız. Lütfen Tekar Deneyiniz.", "Tamam");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Uyarı", "Bağlanılamadı Tekrar Deneyiniz.", "Tamam");
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
