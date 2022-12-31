using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Delia_Ovidiu.Data;
using Proiect_Delia_Ovidiu.Models;

namespace Proiect_Delia_Ovidiu.Pages.Categorii
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext _context;

        public DetailsModel(Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext context)
        {
            _context = context;
        }

      public Categorie Categorie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categorii == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorii.FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }
            else 
            {
                Categorie = categorie;
            }
            return Page();
        }
    }
}
