using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using GestiuneRestaurant.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GestiuneRestaurant.Models
{
    public class Masa
    {
        [Key]
        public int MasaId { get; set; }

        [Required]
        [Display(Name = "Numărul Mesei")]
        public int Numar { get; set; }

        [Required]
        [Display(Name = "Capacitate")]
        public int Capacitate { get; set; }
        public Comanda Comanda { get; set; }

        public ICollection<Rezervare>? Rezervari { get; set; }
    }
}
