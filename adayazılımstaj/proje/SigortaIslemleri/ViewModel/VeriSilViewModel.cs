using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


namespace SigortaIslemleri.ViewModel
{
    public partial class VeriSilViewModel : ObservableObject
    {
        int userid = 0;
        public VeriSilViewModel(int userid) {

            client = CreateHttpClient(); 


            Items = new ObservableCollection<TeklifItem>();
            second();
            this.userid = userid;
        }


        [ObservableProperty]
        public string column1;

        [ObservableProperty]
        public string column2;

        [ObservableProperty]
        public string column3;

        [ObservableProperty]
        public string column4;

        [ObservableProperty]
        public ObservableCollection<TeklifItem> items;


        private HttpClient client;
        public static string BaseAddress =
        DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7077" : "https://localhost:7077";
        string TodoItemsUrl = $"{BaseAddress}/api/Police";
        public class Police
        {
            public string SonTarih { get; set; }
            public int KulId { get; set; }
            public string PoliceGrup { get; set; }
            public string PoliceDetay { get; set; }
            public int PoliceId { get; set; }
        }


        public async void second()
        {
            HttpResponseMessage response = await client.GetAsync(TodoItemsUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Police> personList = JsonConvert.DeserializeObject<List<Police>>(responseBody);

                var filteredPersonList = personList.Where(person => person.KulId == userid).ToList();

                Items.Clear(); 

                if (filteredPersonList.Count > 0)
                {
                    foreach (Police person in filteredPersonList)
                    {
                        Items.Add(new TeklifItem
                        {
                            Column1 = person.PoliceId.ToString(),
                            Column2 = person.SonTarih,
                            Column3 = person.PoliceGrup,
                            Column4 = person.PoliceDetay
                        });
                    }

                }

                else
                {
                   
                }
            }
        }


        public class TeklifItem
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }

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
