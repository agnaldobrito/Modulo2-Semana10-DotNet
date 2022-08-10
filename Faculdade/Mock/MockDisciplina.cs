
using Faculdade.Models;

namespace Faculdade.Mock
{
    public class MockDisciplina
    {
        public static List<Curso> Disciplinas = new()
        {
            new Curso
            {
                Id = 1,
                Nome = "Metodologia Científica",
                CargaHoraria = 40

            },
            new Curso
            {
                Id = 2,
                Nome = "Introdução à Programação",
                CargaHoraria = 80

            },
            new Curso
            {
                Id = 3,
                Nome = "Banco de Dados",
                CargaHoraria = 80

            }
        };
    }
}
