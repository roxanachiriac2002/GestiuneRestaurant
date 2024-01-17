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
    public class IndexModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.RestaurantContext _context;

        public IndexModel(GestiuneRestaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IList<ProdusMeniu> ProdusMeniu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProdusMeniu = await _context.ProduseMeniu.ToListAsync();
        }
    }
}
