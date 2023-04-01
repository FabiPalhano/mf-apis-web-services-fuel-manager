using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v2.Models
{
    [Table("Vacinas")]
    public class Vacinas
    {
        [Key]
        public int IdVacina { get; set; }

        [Required]
        public string NomeVacina { get; set; }

        [Required]
        public DateTime DataAplicacao { get; set; }

        [Required]
        public NumeroDose NumeroDose { get; set; }

        [Required]
        public string Local { get; set; }

        public DateTime DataProximaAplicacao { get; set; }

        [Required]
        public int ResponsavelId { get; set; }

        public Responsavel Responsavel { get; set; }
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
