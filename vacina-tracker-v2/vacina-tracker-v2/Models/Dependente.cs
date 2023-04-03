using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v2.Models
{
    [Table("Perfil Usuário Dependente")]
    public class Dependente : LinksHATEOS
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = ("Obrigatório informar o nome"))]
        public string Nome { get; set; }
                
       public ICollection<VacinasUsuarios> Vacina { get; set; }
    }    
}
