using System.ComponentModel.DataAnnotations;

namespace Faculdade.Models
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, infome o nome da disciplina")]
        [StringLength(100)]
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
    }
}
