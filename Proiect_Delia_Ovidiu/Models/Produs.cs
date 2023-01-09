using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Delia_Ovidiu.Models
{
    public class Produs
    {
        public int Id { get; set; }
        
        [Display(Name = "Nume Produs")]
        public string Nume { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
       
        public string Descriere { get; set; }

       //public string ImageName { get; set; }

        public int? BrandId { get; set; }
        
        public Brand? Brand { get; set; }
        
        public virtual ICollection<CategorieProdus> CategorieProdus { get; set; } = new List<CategorieProdus>();

        public virtual ICollection<CosProdus> CosProduse { get; set; } = new List<CosProdus>();
    }

}
