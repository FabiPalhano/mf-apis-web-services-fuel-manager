using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v2.Models
{
    [Table("Perfil Usuário Responsável")]
    public class Responsavel
    {
        [Key]
        public int IdResponsavel { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = ("Obrigatório informar o nome completo"))]
        public string Nome { get; set; }
              
        [Required(ErrorMessage = ("Obrigatório informar o email"))]
        public string Email { get; set; }

        [Required(ErrorMessage = ("Obrigatório informar senha"))]
        public string Senha { get; set; }

        [Display(Name = "Tipo de Usuário")]
        public TipoUsuario TipoUsuario { get; set; }

        public ICollection<Vacinas> Vacinas { get; set; }
    }

    public enum TipoUsuario
    {
        [Display(Name = "Responsável")]
        TipoResponsavel,
        [Display(Name = "Dependente")]
        TipoDependente

    }
}
