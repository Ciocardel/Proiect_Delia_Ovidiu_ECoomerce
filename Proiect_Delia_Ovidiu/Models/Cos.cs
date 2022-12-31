using Microsoft.AspNetCore.Identity;
using System.Net.Http.Headers;

namespace Proiect_Delia_Ovidiu.Models
{
    public class Cos
    {
        public int Id { get; set; }

        public int Cantitate { get; set; }

        public string UserId { get; set; }

        public System.DateTime DateCreare { get; set; }

        public virtual ICollection<CosProdus> CosProduse { get; set; }
        public virtual ICollection<IdentityUser> User { get; set; }

    }
}
