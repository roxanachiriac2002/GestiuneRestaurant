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
    public class DeleteModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.RestaurantContext _context;

        public DeleteModel(GestiuneRestaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervare = await _context.Rezervari.FindAsync(id);
            if (rezervare != null)
            {
                Rezervare = rezervare;
                _context.Rezervari.Remove(Rezervare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
