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
    public partial class PoliceDetayViewModel : ObservableObject
    {
        int userid = 0;


        [ObservableProperty]
        public string column1;

        [ObservableProperty]
        public string column2;

        [ObservableProperty]
        public string column3;

        [ObservableProperty]
        public string column4;

        [ObservableProperty]
        public string column5;

        [ObservableProperty]
        public string column6;

        [ObservableProperty]
        public ObservableCollection<TeklifItem> items;


        private HttpClient client;
        public static string BaseAddress =
        DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7077" : "https://localhost:7077";
        string TodoItemsUrl = $"{BaseAddress}/api/Police";
        public class Police
        {
            public string tanzimTarihi { get; set; }
            public string vadeBaslangic { get; set; }
            public string vadeBitis { get; set; }
            public string teminatlar { get; set; }
            public string sigortalananMulkiyet { get; set; }
            public string prim { get; set; }

            public int PoliceId { get; set; }
        }

        public PoliceDetayViewModel(int userid)
        {
            client = CreateHttpClient(); 


            Items = new ObservableCollection<TeklifItem>();
            second();
            this.userid = userid;
        }
        public async void second()
        {
            HttpResponseMessage response = await client.GetAsync(TodoItemsUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Police> personList = JsonConvert.DeserializeObject<List<Police>>(responseBody);

                var filteredPersonList = personList.Where(person => person.PoliceId == userid).ToList();

                Items.Clear(); 

                if (filteredPersonList.Count > 0)
                {
                    foreach (Police person in filteredPersonList)
                    {
                    

                            Items.Add(new TeklifItem
                            {
                                Column1 = person.tanzimTarihi,
                                Column2 = person.vadeBaslangic,
                                Column3 = person.vadeBitis,
                                Column4 = person.teminatlar,
                                Column5 = person.sigortalananMulkiyet,
                                Column6 = person.prim

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
            public string Column5 { get; set; }
            public string Column6 { get; set; }


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

