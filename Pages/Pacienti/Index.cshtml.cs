using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budica_Andrei_Proiect.Data;
using Budica_Andrei_Proiect.Models;

namespace Budica_Andrei_Proiect.Pages.Pacienti
{
    public class IndexModel : PageModel
    {
        private readonly Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext _context;

        public IndexModel(Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext context)
        {
            _context = context;
        }

        public IList<Pacient> Pacient { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var pacienti = from p in _context.Pacient
                           select p;

            if (!string.IsNullOrEmpty(SearchString))
            {
                // Convertim termenul de căutare la lowercase pentru o căutare case-insensitive
                var searchTerm = SearchString.ToLower().Trim();

                // Filtrăm pacienții
                Pacient = await _context.Pacient
                    .Where(p => p.Nume.ToLower().Contains(searchTerm)
                            || p.Prenume.ToLower().Contains(searchTerm))
                    .ToListAsync();
            }
            else
            {
                Pacient = await _context.Pacient.ToListAsync();
            }
        }
    }
}
