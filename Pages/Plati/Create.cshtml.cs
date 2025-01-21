using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Budica_Andrei_Proiect.Data;
using Budica_Andrei_Proiect.Models;

namespace Budica_Andrei_Proiect.Pages.Plati
{
    public class CreateModel : PageModel
    {
        private readonly Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext _context;

        public CreateModel(Budica_Andrei_Proiect.Data.Budica_Andrei_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PacientID"] = new SelectList(_context.Pacient, "ID", "CNP");
            return Page();
        }

        [BindProperty]
        public Plata Plata { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Plata.Add(Plata);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
