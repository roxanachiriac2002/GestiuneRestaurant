using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace GestiuneRestaurant.Pages.Rezervari
{
    public class CreateModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.RestaurantContext _context;

        public CreateModel(GestiuneRestaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        public SelectList MeseDisponibile { get; set; }
        public SelectList NumarPersoaneOptions { get; set; }
        public Dictionary<string, bool> OreDisponibile { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            DateTime dataSelectata = DateTime.Now; // sau data implicită dorită
            var meseIndisponibileLaOraSelectata = _context.Rezervari
                .Where(r => r.DataRezervare.Date == dataSelectata.Date && r.DataRezervare.Hour == dataSelectata.Hour)
                .Select(r => r.MasaId)
                .Distinct();

            var meseDisponibileQuery = _context.Mese
                .Where(m => !meseIndisponibileLaOraSelectata.Contains(m.MasaId));

            MeseDisponibile = new SelectList(await meseDisponibileQuery.ToListAsync(), "MasaId", "Numar");

            // Populează NumarPersoaneOptions...
            NumarPersoaneOptions = new SelectList(Enumerable.Range(1, 6));

            // Inițializează dicționarul pentru orele disponibile
            OreDisponibile = new Dictionary<string, bool>();
            for (int ora = 12; ora <= 22; ora++)
            {
                OreDisponibile[$"{ora}:00"] = true; // Presupunem că toate orele sunt inițial disponibile
            }

            return Page();
        }


        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            var esteMasaDisponibila = !_context.Rezervari.Any(r =>
        r.MasaId == Rezervare.MasaId &&
        r.DataRezervare.Date == Rezervare.DataRezervare.Date &&
        r.DataRezervare.Hour == Rezervare.DataRezervare.Hour);

            if (!esteMasaDisponibila)
            {
                ModelState.AddModelError("", "Masa este deja rezervată pentru această oră. Vă rugăm să selectați o altă oră sau masă.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ajustează ora la cea mai apropiată oră completă
            Rezervare.DataRezervare = new DateTime(
                Rezervare.DataRezervare.Year,
                Rezervare.DataRezervare.Month,
                Rezervare.DataRezervare.Day,
                Rezervare.DataRezervare.Hour,
                0,  // Setează minutele la 00
                0   // Setează secundele la 00
            );

            _context.Rezervari.Add(Rezervare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
