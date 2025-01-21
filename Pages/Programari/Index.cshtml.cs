using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budica_Andrei_Proiect.Data;
using Budica_Andrei_Proiect.Models;

namespace Budica_Andrei_Proiect.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext _context;

        public IndexModel(Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Programare = await _context.Programare
                .Include(p => p.Pacient)
                .Include(p => p.Terapeut).ToListAsync();
        }
    }
}
