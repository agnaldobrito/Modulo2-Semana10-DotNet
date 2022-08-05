using System.ComponentModel.DataAnnotations;

namespace Faculdade.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Por favor, informe o nome do aluno")]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        public int Idade { get; set; }
    }
}
