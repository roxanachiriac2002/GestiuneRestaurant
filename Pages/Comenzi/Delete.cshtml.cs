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
    public class DeleteModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.RestaurantContext _context;

        public DeleteModel(GestiuneRestaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comenzi.FindAsync(id);
            if (comanda != null)
            {
                Comanda = comanda;
                _context.Comenzi.Remove(Comanda);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
