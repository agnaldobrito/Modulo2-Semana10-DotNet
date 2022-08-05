using Faculdade.Models;

namespace Faculdade.Mock
{
    public class MockAluno
    {
        public static List<Aluno> Alunos = new()
        {
            new Aluno
            {
                Id = 1,
                Nome = "José Perereira da Silva",
                Endereco = "Av. Conde da Boa Vista, 100, Recife-PE",
                Idade = 25
            },
             new Aluno
            {
                Id = 2,
                Nome = "Maria Joaquina dos Anjos",
                Endereco = "Av. Norte, 250, Recife-PE",
                Idade = 23
            },
              new Aluno
            {
                Id = 3,
                Nome = "Luiz Ricardo Soares",
                Endereco = "Av. Transamazônica, 1012, Olinda-PE",
                Idade = 26
            }
        };
    }
}
