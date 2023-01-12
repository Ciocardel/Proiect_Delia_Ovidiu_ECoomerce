using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Delia_Ovidiu.Bussiness;
using Proiect_Delia_Ovidiu.Data;
using Proiect_Delia_Ovidiu.Models;
//using Microsoft.AspNetCore.Hosting;

namespace Proiect_Delia_Ovidiu.Pages.Produse
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext _context;
        private readonly ImageService _imageService;

        public CreateModel(Proiect_Delia_Ovidiu.Data.AutentificareMagazinContext context, ImageService imageService)
        {
            // _hostEnvironment = environment; , IWebHostEnvironment environment
            _context = context;
            _imageService = imageService;
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
        public int CategorieId { get; set; }

       [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var imageName = await _imageService.SaveImage(Image.OpenReadStream(),Path.GetExtension(Image.FileName));
            Produs.ImageName = imageName;


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
