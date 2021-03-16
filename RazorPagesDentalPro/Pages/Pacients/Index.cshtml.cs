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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDentalPro.Data.RazorPagesDentalProContext _context;
         
        public IndexModel(RazorPagesDentalPro.Data.RazorPagesDentalProContext context)
        {
            _context = context;
        }

        public IList<Pacient> Pacient { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ChosenDentist { get; set; } = "All";

        public SelectList DentistsToSelect { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            var pacients = from p in _context.Pacient    
                           select p;
            var dentists = from o in _context.Dentist
                           select o;
            //Restrange cautarea doar la pacientii medicului selectat
            if ((ChosenDentist != "All") && (ChosenDentist is not null))
            {
                pacients = pacients.Where(p => p.Medic == ChosenDentist);
            }
            //Filtreaza lista de pacienti dupa stringul dat                   
            if (!String.IsNullOrEmpty(searchString))
            {
                pacients = pacients
                    .Where(s => s.Nume.StartsWith(searchString) || s.Prenume.StartsWith(searchString));
            }
            
            Pacient = await pacients.ToListAsync();
            //Lista dentisti ce pot fi selectati
            DentistsToSelect = new SelectList( await (dentists.Select(p => p.FullName)).ToListAsync() );          
        }
    }
}
