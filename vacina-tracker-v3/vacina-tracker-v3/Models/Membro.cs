using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v3.Models
{
    [Table("Membros")]
    public class Membro : LinksHATEOS
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Obrigatório informar o Nome"))]
        [MaxLength(30)]
        public string NomeMembroFamilia { get; set; }

        [Required(ErrorMessage = ("Obrigatório informar a idade"))]
        public int Idade { get; set; }

        [Required]
        public int VacinaId { get; set; }

        public Vacina Vacina { get; set; } //navegação virtual
                
        public ICollection<VacinaMembro> Vacinas { get; set; }
    }
}
