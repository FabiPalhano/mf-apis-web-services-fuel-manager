using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v2.Models
{
    [Table("Vacinas Adicionadas")]
    public class Vacina : LinksHATEOS
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeVacina { get; set; }

        [Required]
        public DateTime DataAplicacao { get; set; }

        [Required]
        public Dose Dose { get; set; }

        [Required]
        public string Local { get; set; }

        public DateTime DataProximaAplicacao { get; set; }

        
        public ICollection<VacinasUsuarios> Responsavel { get; set; }

        public ICollection<VacinasUsuarios> Dependente { get; set; }
    }

    public enum Dose
    {
        [Display(Name = "Dose Única")]
        DoseUnica,
        [Display(Name = "Primeira Dose")]
        PrimeiraDose,
        [Display(Name = "Segunda Dose")]
        SegundaDose,
        [Display(Name = "Terceira Dose")]
        TerceiraDose,
        [Display(Name = "Quarta Dose")]
        QuartaDose
    }
}
