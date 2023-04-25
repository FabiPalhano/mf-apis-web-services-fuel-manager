using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace vacina_tracker_v3.Models
{
    [Table("Usuário")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Obrigatório informar o email"))]
        public string Email { get; set; }

        [Required(ErrorMessage = ("Obrigatório informar senha"))]
        [JsonIgnore]
        public string Senha { get; set; }        
    }
}
