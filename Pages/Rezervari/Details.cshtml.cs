using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.Rezervari
{
    public class DetailsModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.RestaurantContext _context;

        public DetailsModel(GestiuneRestaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervare = await _context.Rezervari.FirstOrDefaultAsync(m => m.RezervareId == id);
            if (rezervare == null)
            {
                return NotFound();
            }
            else
            {
                Rezervare = rezervare;
            }
            return Page();
        }
    }
}
