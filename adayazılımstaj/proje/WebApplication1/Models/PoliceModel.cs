using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class PoliceModel
    {
        [Key] public int PoliceId { get; set; }


        public string? PoliceGrup { get; set; }

        public string? SonTarih { get; set; }

        public string? PoliceDetay { get; set; }

        public int KulId { get; set; }

        public string? TanzimTarihi { get; set; }

        public string? VadeBaslangic { get; set; }
        public string? VadeBitis { get; set; }

        public string? Teminatlar { get; set; }

        public string? SigortalananMulkiyet { get; set; }

        public int Prim { get; set; }


    }

}

