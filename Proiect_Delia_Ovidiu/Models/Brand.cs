using Proiect_Delia_Ovidiu.Models;

namespace Proiect_Delia_Ovidiu.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public ICollection<Produs>? Produs { get; set; }
    }
}

