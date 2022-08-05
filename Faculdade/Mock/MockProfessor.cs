using Faculdade.Models;

namespace Faculdade.Mock
{
    public class MockProfessor
    {
        public static List<Professor> Professores = new()
        {
            new Professor
            {
                Id = 1,
                Nome = "Ana Maria Tavares",
                Graduacao = "Licenciatura em Letras"
            },
            new Professor
            {
                Id = 2,
                Nome = "Fernando Soares Araújo",
                Graduacao = "Engenharia da Computação"
            },
            new Professor
            {
                Id = 3,
                Nome = "Helena Maria Bezerra",
                Graduacao = "Sistemas da Informação"
            },
        };
    }
}
