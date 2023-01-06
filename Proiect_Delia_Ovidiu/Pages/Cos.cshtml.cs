using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Delia_Ovidiu.Models;

namespace Proiect_Delia_Ovidiu.Pages
{
    public class CosModel : PageModel
    {
        private readonly Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext _context;

        public CosModel(Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext context)
        {
            _context = context;
        }


        public ICollection<CosProdus> ProduseCos { get; set; }

        public IActionResult OnGet()
        {
            var userEmail = User!.Identities!.FirstOrDefault()?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var cos  = _context.Cosuri.Include(x => x.CosProduse).ThenInclude(x => x.Produs).ThenInclude(X=>X.Brand)
                                      .Include(x => x.CosProduse).ThenInclude(x => x.Produs).ThenInclude(X => X.CategorieProdus).ThenInclude(x=>x.Categorie)
                                             .FirstOrDefault(x => x.User.Email.Equals(userEmail));
            ProduseCos = cos.CosProduse;
            return Page();
        }

        [BindProperty]
        public Cos Cos { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cosuri.Add(Cos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
