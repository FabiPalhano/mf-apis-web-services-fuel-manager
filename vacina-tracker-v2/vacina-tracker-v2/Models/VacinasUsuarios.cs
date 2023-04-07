using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v2.Models
{
    [Table("Vacinas Usuários")]
    public class VacinasUsuarios
    {
        public int VacinaId { get; set; }
        public Vacina Vacina { get; set; }

        public int ResponsavelId { get; set; }
        public Responsavel Responsavel { get; set; }       
    }
}
