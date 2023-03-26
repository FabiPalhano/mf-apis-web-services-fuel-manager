using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v1.Models
{
    [Table("Vacinas")]
    public class Vacina
    {
        [Key]
        public int IdVacina { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataAplicacao { get; set; }

        [Required]
        public NumeroDose NumeroDose { get; set; }

        [Required]
        public DateTime DataProximaAplicacao { get; set; }

        public ICollection<Responsavel> Responsavel { get; set; }
    }

    public enum NumeroDose
    {
        [Display(Name = "Dose Única")]
        DoseUnica,
        [Display(Name = "Primeira Dose")]
        PrimeiraDose,
        [Display(Name = "Segunda Dose")]
        SegundaDose,
        [Display(Name = "Terceira Dose")]
        TerceiraDose
    }
}