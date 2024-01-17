using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.Comenzi
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
            ViewData["MasaId"] = new SelectList(_context.Mese, "MasaId", "MasaId");
            ViewData["ProduseMeniu"] = new SelectList(_context.ProduseMeniu, "ProdusMeniuId", "Nume");
            return Page();
        }
        [BindProperty]
        public Comanda Comanda { get; set; } = new Comanda();

        [BindProperty]
        public Dictionary<int, bool> SelectedProduse { get; set; } = new Dictionary<int, bool>();

        [BindProperty]
        public Dictionary<int, int> ProdusCantitati { get; set; } = new Dictionary<int, int>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MasaId"] = new SelectList(_context.Mese, "MasaId", "MasaId");
                ViewData["ProduseMeniu"] = new SelectList(_context.ProduseMeniu, "ProdusMeniuId", "Nume");
                return Page();
            }

            // Logică pentru a adăuga produsele selectate și cantitățile lor la comandă
            foreach (var produs in SelectedProduse)
            {
                if (produs.Value && ProdusCantitati.ContainsKey(produs.Key))
                {
                    Comanda.ArticoleComandate.Add(new ArticolComandat
                    {
                        ProdusMeniuId = produs.Key,
                        Cantitate = ProdusCantitati[produs.Key]
                    });
                }
            }

            _context.Comenzi.Add(Comanda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
