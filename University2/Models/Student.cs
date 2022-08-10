using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University2.Models
{
    [Table("AlunoTesteMigration")]
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, preencher o campo Cpf")]
        [StringLength(18)]
        public string Cpf { get; set; }

        [Required(ErrorMessage ="Por favor, preencher o campo Nome")]
        [StringLength(250)]
        [Column("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor, preencher o campo Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, preencher o campo Telefone")]
        [StringLength(14)]
        [Column("Telefone")]
        public string Phone { get; set; }

        [Column("DataNascimento")]
        public DateTime? Birthday { get; set; }


    }
}
