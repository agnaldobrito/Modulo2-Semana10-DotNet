using System.ComponentModel.DataAnnotations;

namespace Faculdade.Models
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, infome o nome do docente")]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Graduacao { get; set; }
    }
}
