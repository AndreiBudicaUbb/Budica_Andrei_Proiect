using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budica_Andrei_Proiect.Data;
using Budica_Andrei_Proiect.Models;

namespace Budica_Andrei_Proiect.Pages.Terapeuti
{
    public class DeleteModel : PageModel
    {
        private readonly Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext _context;

        public DeleteModel(Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Terapeut Terapeut { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terapeut = await _context.Terapeut.FirstOrDefaultAsync(m => m.ID == id);

            if (terapeut == null)
            {
                return NotFound();
            }
            else
            {
                Terapeut = terapeut;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terapeut = await _context.Terapeut.FindAsync(id);
            if (terapeut != null)
            {
                Terapeut = terapeut;
                _context.Terapeut.Remove(Terapeut);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
