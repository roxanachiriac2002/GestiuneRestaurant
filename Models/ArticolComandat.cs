using System.ComponentModel.DataAnnotations;

namespace GestiuneRestaurant.Models
{
    public class ArticolComandat
    {
        [Key]
        public int ArticolComandatId { get; set; }

        [Required]
        public int ComandaId { get; set; }
        public Comanda Comanda { get; set; }

        [Required]
        public int ProdusMeniuId { get; set; }
        public ProdusMeniu ProdusMeniu { get; set; }

        [Required]
        public int Cantitate { get; set; }
    }
}
