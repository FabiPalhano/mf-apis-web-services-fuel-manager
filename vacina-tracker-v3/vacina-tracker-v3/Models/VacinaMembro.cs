using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v3.Models
{
    [Table("Vacinas Membros")]
    public class VacinaMembro
    {        
        public int MembroId { get; set; }    
        public Membro Membro { get; set; } //navegação virtual
        
        public int VacinaId { get; set; }
        public Vacina Vacina { get; set; } //navegação virtual
    }
}

// só é preciso ter as forenkey das tabelas