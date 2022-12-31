namespace Proiect_Delia_Ovidiu.Models
{
    public class CategorieProdus
    {
        public int Id { get; set; }
        public int ProdusId { get; set; }
        public int CategorieId { get; set; }
        public virtual Produs Produs { get; set; }
        public virtual Categorie Categorie { get; set; }
    }
}
