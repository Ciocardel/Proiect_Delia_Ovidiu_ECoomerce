using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Delia_Ovidiu.Data;
using Proiect_Delia_Ovidiu.Models;

namespace Proiect_Delia_Ovidiu.Pages.Produse
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext _context;

        public EditModel(Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; } = default!;

        [BindProperty]
        public int CategorieId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produse == null)
            {
                return NotFound();
            }

            var produs = await _context.Produse.Include(x => x.CategorieProdus).FirstOrDefaultAsync(m => m.Id == id);
            if (produs == null)
            {
                return NotFound();
            }
            Produs = produs;
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Nume");
            ViewData["Categorii"] = new SelectList(_context.Categorii, "Id", "Nume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produs).State = EntityState.Modified;

            try
            {

                Produs.CategorieProdus = await _context.CategorieProdus.Where(x => x.ProdusId == Produs.Id).ToListAsync();

                Produs.CategorieProdus.Clear();

                Produs.CategorieProdus.Add(new CategorieProdus() { CategorieId = CategorieId });

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusExists(Produs.Id))
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

        private bool ProdusExists(int id)
        {
            return _context.Produse.Any(e => e.Id == id);
        }
    }
}
