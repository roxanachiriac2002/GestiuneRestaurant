using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.Comenzi
{
    public class DetailsModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.RestaurantContext _context;

        public DetailsModel(GestiuneRestaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        public Comanda Comanda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comenzi.FirstOrDefaultAsync(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }
            else
            {
                Comanda = comanda;
            }
            return Page();
        }
    }
}
