using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestiuneRestaurant.Models
{
    public class ProdusMeniu
    {
        [Key]
        public int ProdusMeniuId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nume Produs")]
        public string? Nume { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Descriere")]
        public string? Descriere { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Preț")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        public ICollection<ArticolComandat> ArticoleComandate { get; set; }

    }
}
