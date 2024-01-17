using System.ComponentModel.DataAnnotations;

namespace GestiuneRestaurant.Models
{
    public class Comanda
    {
        [Key]
        public int ComandaId { get; set; }

        [Required]
        public int MasaId { get; set; }
        public Masa Masa { get; set; }

        // Lista de produse comandate
        public ICollection<ArticolComandat> ArticoleComandate { get; set; }
    }
}
