using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University2.Models
{
    [Table("Instrutor")]
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [Column("Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Telefone")]
        public string Phone { get; set; }


        [Column("ValorHora")]
        public decimal? HourlyWage { get; set; }

        [Column("Certificados")]
        [StringLength(255)]
        public string? Certificates { get; set; }

    }
}
