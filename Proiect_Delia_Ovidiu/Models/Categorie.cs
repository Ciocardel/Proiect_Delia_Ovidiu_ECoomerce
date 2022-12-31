namespace Proiect_Delia_Ovidiu.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Nume { get; set; }
        public virtual ICollection<CategorieProdus> CategorieProduse { get; set; } =new List<CategorieProdus>();
    
    }
}
