using Faculdade.Mock;
using Faculdade.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Faculdade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        /// <summary>
        /// Retorna uma lista de alunos
        /// </summary>
        /// <returns>Retorna alunos cadastrados no banco de dados</returns>
        /// <response code = "200">Retorna uma lista de alunos</response>
        /// <response code = "404">Não encontrou lista de alunos</response>
        /// <response code = "500">Ocorreu um erro durante a execução</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var mockAlunos = MockAluno.Alunos;
                return mockAlunos.Any() ? Ok(mockAlunos) : StatusCode(404);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna o aluno especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o aluno cadastrado no banco de dados</returns>
        /// <response code="200">Retorna o aluno</response>
        /// <respone code="404">Não encontrou o aluno pesquisado</respone>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try 
            {
                var mockAlunoSelecionado = MockAluno.Alunos.FirstOrDefault(x => x.Id == id);
                return mockAlunoSelecionado != null ? Ok(mockAlunoSelecionado) : StatusCode(404);
            }
            catch 
            {
                return StatusCode(500);
            }
            
        }

        /// <summary>
        /// Inserir aluno
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Retorna aluno inserido com sucesso no banco de dados</returns>
        /// <response code="201">Aluno inserido com sucesso</response>
        /// <respone code="404">Não encontrou o aluno pesquisado</respone>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Aluno value)
        {
            try
            {
                    MockAluno.Alunos.Add(value);
                    return StatusCode(201);
                
            }
            catch
            {
                    return StatusCode(500);
            }
        }

        /// <summary>
        /// Atualizar aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>Retorna aluno atualizado com sucesso do banco de dados</returns>
        ///<response code="202">A atualização foi feita com sucesso </response>
        /// <respone code="404">Atualização não realizada</respone>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Aluno value)
        {
            try 
            {
                var mockAlunoSelecionado = MockAluno.Alunos.FirstOrDefault(x => x.Id == id);
                if(mockAlunoSelecionado != null)
                {
                    mockAlunoSelecionado.Nome = value.Nome;
                    mockAlunoSelecionado.Endereco = value.Endereco;
                    mockAlunoSelecionado.Idade = value.Idade;
                    return StatusCode(201);

                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remover Aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna aluno exlcuído com sucesso no banco de dados</returns>
        /// <response code="204">Aluno excluído com sucesso</response>
        /// <response code="404">Remoção não realizada</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            {
                var mockAlunoSelecionado = MockAluno.Alunos.FirstOrDefault(x=>x.Id == id);
                if (mockAlunoSelecionado != null)
                {
                    MockAluno.Alunos.Remove(mockAlunoSelecionado);
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(404);
                }
                
                
            }
            catch 
            {
                return StatusCode(500);
            }
        }
    }
}
