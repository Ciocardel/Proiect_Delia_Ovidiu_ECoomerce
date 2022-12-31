namespace Proiect_Delia_Ovidiu.Models
{
    public class CosProdus
    {

        public int Id { get; set; }
        public int ProdusId { get; set; }
        public int CosId { get; set; }
        public Produs Produs { get; set; }
        public virtual Cos Cos { get; set; }
    }
}
