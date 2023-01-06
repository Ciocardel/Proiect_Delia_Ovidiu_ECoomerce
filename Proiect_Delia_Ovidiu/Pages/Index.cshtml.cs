using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Delia_Ovidiu.Data;
using Proiect_Delia_Ovidiu.Models;

namespace Proiect_Delia_Ovidiu.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AutentificareMagazinContext _context;
        public IndexModel(ILogger<IndexModel> logger, AutentificareMagazinContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IList<Produs> Produse = new List<Produs>();

        public async Task OnGetAsync()
        {
            Produse = await _context.Produse.Include(x=>x.Brand).Include(x=>x.CategorieProdus).ThenInclude(x=>x.Categorie).ToListAsync();
        }


    }
}