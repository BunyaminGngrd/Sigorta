using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Saglik
    {
        [Key] public int PolId { get; set; }

        public long Tc { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? TanzimTarihi { get; set; }
        public string? VadeBaslangic { get; set; }
        public string? VadeBitis { get; set; }
        public double Prim { get; set; }
        public string? sagliksigorta { get; set; }
    }
}
