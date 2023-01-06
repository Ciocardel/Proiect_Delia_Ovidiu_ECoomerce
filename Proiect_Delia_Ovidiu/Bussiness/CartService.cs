using Microsoft.EntityFrameworkCore;
using Proiect_Delia_Ovidiu.Data;
using Proiect_Delia_Ovidiu.Models;

namespace Proiect_Delia_Ovidiu.Bussiness
{
    public class CartService
    {

        private readonly AutentificareMagazinContext _context;

        public CartService(AutentificareMagazinContext context)
        {
            _context = context;
        }


        public async Task<int> AddProductToCart(int produsId, string userEmail)
        {
            var userCart = await _context.Cosuri.Include(x=>x.CosProduse).FirstOrDefaultAsync(x => x.User.Email.Equals(userEmail));
            if (userCart == null)
            {
                userCart = await AddCos(userEmail);
            }

            if (userCart.CosProduse.Any(x => x.ProdusId == produsId))
            {
                var cosProduse = userCart.CosProduse.FirstOrDefault(x => x.ProdusId == produsId);
                cosProduse!.Cantitate++;
            }
            else
            {
                userCart.CosProduse.Add(new CosProdus()
                {
                    ProdusId = produsId,
                    Cantitate = 1,
                });
            }

            await _context.SaveChangesAsync();

            return userCart.CosProduse.Select(x => x.Cantitate).Sum();
        }

        public async Task RemoveFromCos(int cosProdusId, int cosId)
        {
            var cosProdus = await _context.CosProduse.FirstOrDefaultAsync(x => x.CosId == cosId && x.Id == cosProdusId);

            _context.CosProduse.Remove(cosProdus);

            await _context.SaveChangesAsync();
        }


        public async Task<Cos> AddCos(string userEmail)
        {
            var userId = (await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(userEmail)))?.Id;
            var cartToAdd = new Cos()
            {
                UserId = userId,
                DateCreare = DateTime.UtcNow,
            };

            _context.Cosuri.Add(cartToAdd);

            await _context.SaveChangesAsync();

            return cartToAdd;
        }

    }
}
