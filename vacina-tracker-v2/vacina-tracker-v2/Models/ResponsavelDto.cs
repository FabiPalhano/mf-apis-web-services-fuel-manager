using System.ComponentModel.DataAnnotations;

namespace vacina_tracker_v2.Models
{
    public class ResponsavelDto
    {
        public int? Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }
                
        [Required]        
        public string Senha { get; set; }

        [Display(Name = "Tipo de Usuário")]
        public TipoUsuario TipoUsuario { get; set; }
    }
}
