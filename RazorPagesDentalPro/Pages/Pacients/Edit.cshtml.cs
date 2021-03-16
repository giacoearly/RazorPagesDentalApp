using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesDentalPro.Data;
using RazorPagesDentalPro.Models;

namespace RazorPagesDentalPro.Pages.Pacients
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDentalPro.Data.RazorPagesDentalProContext _context;

        public EditModel(RazorPagesDentalPro.Data.RazorPagesDentalProContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pacient Pacient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pacient = await _context.Pacient.FirstOrDefaultAsync(m => m.Id == id);

            if (Pacient == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pacient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientExists(Pacient.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PacientExists(int id)
        {
            return _context.Pacient.Any(e => e.Id == id);
        }
    }
}
