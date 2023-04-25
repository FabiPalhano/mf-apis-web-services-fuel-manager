using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacina_tracker_v4.Models
{
    [Table("Membros")]
    public class Membro 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Obrigatório informar o Nome"))]
        [MaxLength(30)]
        public string NomeMembroFamilia { get; set; }

        [Required(ErrorMessage = ("Obrigatório informar a idade"))]
        public int Idade { get; set; }


        public ICollection<Vacina> Vacinas { get; set; } //1 membro está associado a várias vacinas

        //public ICollection<VacinaMembro> Vacinas { get; set; }
    }
}
