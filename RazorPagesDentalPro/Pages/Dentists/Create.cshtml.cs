using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesDentalPro.Data;
using RazorPagesDentalPro.Models;

namespace RazorPagesDentalPro.Pages.Dentists
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesDentalPro.Data.RazorPagesDentalProContext _context;

        public CreateModel(RazorPagesDentalPro.Data.RazorPagesDentalProContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dentist Dentist { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dentist.Add(Dentist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
