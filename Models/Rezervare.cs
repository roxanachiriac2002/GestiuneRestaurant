using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Models
{
    public class Rezervare
    {
        [Key]
        public int RezervareId { get; set; }
        [Required]
        public string? NumeClient { get; set; }
        public DateTime DataRezervare { get; set; }
        public int NumarPersoane { get; set; }

        [Display(Name = "Masa")]
        [ForeignKey("MasaId")]
        public int MasaId { get; set; }
        public virtual Masa? Masa { get; set; }
    }
}
