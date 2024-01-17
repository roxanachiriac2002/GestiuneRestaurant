using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.ProduseMeniu
{
    public class CreateModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.RestaurantContext _context;

        public CreateModel(GestiuneRestaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProdusMeniu ProdusMeniu { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProduseMeniu.Add(ProdusMeniu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
