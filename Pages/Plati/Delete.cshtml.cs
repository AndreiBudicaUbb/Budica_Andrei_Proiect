using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budica_Andrei_Proiect.Data;
using Budica_Andrei_Proiect.Models;

namespace Budica_Andrei_Proiect.Pages.Plati
{
    public class DeleteModel : PageModel
    {
        private readonly Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext _context;

        public DeleteModel(Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plata Plata { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plata = await _context.Plata.FirstOrDefaultAsync(m => m.ID == id);

            if (plata == null)
            {
                return NotFound();
            }
            else
            {
                Plata = plata;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plata = await _context.Plata.FindAsync(id);
            if (plata != null)
            {
                Plata = plata;
                _context.Plata.Remove(Plata);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
