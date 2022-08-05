
using Faculdade.Models;

namespace Faculdade.Mock
{
    public class MockDisciplina
    {
        public static List<Disciplina> Disciplinas = new()
        {
            new Disciplina
            {
                Id = 1,
                Nome = "Metodologia Científica",
                CargaHoraria = 40

            },
            new Disciplina
            {
                Id = 2,
                Nome = "Introdução à Programação",
                CargaHoraria = 80

            },
            new Disciplina
            {
                Id = 3,
                Nome = "Banco de Dados",
                CargaHoraria = 80

            }
        };
    }
}
