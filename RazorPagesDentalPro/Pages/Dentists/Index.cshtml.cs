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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDentalPro.Data.RazorPagesDentalProContext _context;

        public IndexModel(RazorPagesDentalPro.Data.RazorPagesDentalProContext context)
        {
            _context = context;
        }

        public IList<Dentist> Dentist { get;set; }

        public async Task OnGetAsync()
        {
            Dentist = await _context.Dentist.ToListAsync();
        }
    }
}
