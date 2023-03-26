using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v1.Models
{
    [Table("Perfil Usuário Responsável")]
    public class Responsavel
    {
        [Key]
        public int IdResponsavel { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = ("Obrigatório informar o nome completo"))]
        public string Nome { get; set; }

        [Required(ErrorMessage = ("Obrigatório informar o CPF"))]
        public string CPF { get; set; }
              
        [Required(ErrorMessage = ("Obrigatório informar o email"))]
        public string Email { get; set; }

        [Required(ErrorMessage = ("Obrigatório informar senha"))]
        public string Senha { get; set; }

        [Required(ErrorMessage = ("Obrigatório repetir a  senha"))]
        public string Senha2 { get; set; }

        [Display(Name = "Tipo de Usuário")]
        public TipoUsuario TipoUsuario { get; set; }

        [Required]
        public int VacinaId { get; set; }

        public Vacina Vacina { get; set; }
    }


    public enum TipoUsuario
    {
        [Display(Name = "Responsável")]
        TipoResponsavel,
        [Display(Name = "Dependente")]
        TipoDependente

    }
}