using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.ProduseMeniu
{
    public class DeleteModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.RestaurantContext _context;

        public DeleteModel(GestiuneRestaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProdusMeniu ProdusMeniu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produsmeniu = await _context.ProduseMeniu.FirstOrDefaultAsync(m => m.ProdusMeniuId == id);

            if (produsmeniu == null)
            {
                return NotFound();
            }
            else
            {
                ProdusMeniu = produsmeniu;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produsmeniu = await _context.ProduseMeniu.FindAsync(id);
            if (produsmeniu != null)
            {
                ProdusMeniu = produsmeniu;
                _context.ProduseMeniu.Remove(ProdusMeniu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
