using Faculdade.Mock;
using Faculdade.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Faculdade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        /// <summary>
        /// Retorna uma lista de professores
        /// </summary>
        /// <returns>Retorna professores cadastrados no banco de dados</returns>
        /// <response code = "200">Retorna uma lista de professores</response>
        /// <response code = "404">Não encontrou lista de professores</response>
        /// <response code = "500">Ocorreu um erro durante a execução</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var mockProfessor = MockProfessor.Professores;
                return mockProfessor.Any() ? Ok(mockProfessor) : StatusCode(404);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna o professor especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o professor cadastrado no banco de dados</returns>
        /// <response code="200">Retorna o professor</response>
        /// <respone code="404">Não encontrou o professor pesquisado</respone>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mockProfessorSelecionado = MockProfessor.Professores.FirstOrDefault(x => x.Id == id);
                return mockProfessorSelecionado != null ? Ok(mockProfessorSelecionado) : StatusCode(404);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Cadastrar professor
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Retorna professor inserido com sucesso no banco de dados</returns>
        /// <response code="201">Professor inserido com sucesso</response>
        /// <respone code="404">Não encontrou o professor especificado</respone>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Professor value)
        {
            try
            {

                if (value != null)
                {
                    MockProfessor.Professores.Add(value);
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
        /// Atualizar professor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>Retorna professor atualizado do banco de dados</returns>
        ///<response code="202">A atualização foi feita com sucesso</response>
        /// <respone code="404">Atualização não realizada</respone>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Professor value)
        {
            try
            {
                var mockProfessorSelecionado = MockProfessor.Professores.FirstOrDefault(x => x.Id == id);
                if (mockProfessorSelecionado != null)
                {
                    mockProfessorSelecionado.Nome = value.Nome;
                    mockProfessorSelecionado.Graduacao = value.Graduacao;
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
        /// Remover professor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna professor excluído com sucesso no banco de dados</returns>
        /// <response code="204">Professor excluído com sucesso</response>
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
                var mockProfessorSelecionado = MockProfessor.Professores.FirstOrDefault(x => x.Id == id);
                if (mockProfessorSelecionado != null)
                {
                    MockProfessor.Professores.Remove(mockProfessorSelecionado);
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