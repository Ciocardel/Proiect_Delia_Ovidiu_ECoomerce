using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Proiect_Delia_Ovidiu.Data;
using Proiect_Delia_Ovidiu.Models;
//using Microsoft.AspNetCore.Hosting;

namespace Proiect_Delia_Ovidiu.Pages.Produse
{
    public class CreateModel : PageModel
    {
      
        
        private readonly Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext _context;
       // private readonly IWebHostEnvironment _hostEnvironment;
        public CreateModel(Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext context)
        {
            // _hostEnvironment = environment; , IWebHostEnvironment environment
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Nume");
            ViewData["Categorii"] = new SelectList(_context.Categorii, "Id", "Nume");


            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        [BindProperty]
        public int CategorieId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            /*  if (this.Image != null)
              {
                  var fileName = GetUniqueName(this.Image.FileName);
                  var uploads = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
                  var filePath = Path.Combine(uploads, fileName);
                  this.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                  this.Produs.ImageName = fileName; // Set the file name
              }
              _context.Produse.Add(this.Produs);
              await _context.SaveChangesAsync();
              return RedirectToPage("ProdusList");

             string GetUniqueName(string fileName)
              {
                  fileName = Path.GetFileName(fileName);
                  return Path.GetFileNameWithoutExtension(fileName)
                         + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                         + Path.GetExtension(fileName); 
              }*/

            Produs.CategorieProdus.Add(new CategorieProdus()
            {
                CategorieId = CategorieId
            });

            _context.Produse.Add(Produs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
