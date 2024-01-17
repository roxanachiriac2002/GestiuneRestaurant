using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.ProduseMeniu
{
    public class EditModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.RestaurantContext _context;

        public EditModel(GestiuneRestaurant.Data.RestaurantContext context)
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

            var produsmeniu =  await _context.ProduseMeniu.FirstOrDefaultAsync(m => m.ProdusMeniuId == id);
            if (produsmeniu == null)
            {
                return NotFound();
            }
            ProdusMeniu = produsmeniu;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProdusMeniu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusMeniuExists(ProdusMeniu.ProdusMeniuId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProdusMeniuExists(int id)
        {
            return _context.ProduseMeniu.Any(e => e.ProdusMeniuId == id);
        }
    }
}
