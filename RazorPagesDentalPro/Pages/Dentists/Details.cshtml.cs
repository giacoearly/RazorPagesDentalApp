using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDentalPro.Data;
using RazorPagesDentalPro.Models;

namespace RazorPagesDentalPro.Pages.Dentists
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesDentalPro.Data.RazorPagesDentalProContext _context;

        public DetailsModel(RazorPagesDentalPro.Data.RazorPagesDentalProContext context)
        {
            _context = context;
        }

        public Dentist Dentist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dentist = await _context.Dentist.FirstOrDefaultAsync(m => m.Id == id);

            if (Dentist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
