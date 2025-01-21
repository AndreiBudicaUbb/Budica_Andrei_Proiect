using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Budica_Andrei_Proiect.Data;
using Budica_Andrei_Proiect.Models;

namespace Budica_Andrei_Proiect.Pages.Programari
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
        ViewData["TerapeutID"] = new SelectList(_context.Terapeut, "ID", "Email");
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
