using Faculdade.Mock;
using Faculdade.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Faculdade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        /// <summary>
        /// Retorna uma lista de disciplinas
        /// </summary>
        /// <returns>Retorna disciplinas cadastradas no banco de dados</returns>
        /// <response code = "200">Retorna uma lista de disciplinas</response>
        /// <response code = "404">Não encontrou lista de disciplinas</response>
        /// <response code = "500">Ocorreu um erro durante a execução</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var mockDisciplinas = MockDisciplina.Disciplinas;
                return mockDisciplinas.Any() ? Ok(mockDisciplinas) : StatusCode(404);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna a disciplina especificada
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna a disciplina cadastrada no banco de dados</returns>
        /// <response code="200">Retorna a disciplina</response>
        /// <respone code="404">Não encontrou a disciplina pesquisada</respone>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mockDisciplinSelecionada = MockDisciplina.Disciplinas.FirstOrDefault(x => x.Id == id);
                return mockDisciplinSelecionada != null ? Ok(mockDisciplinSelecionada) : StatusCode(404);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Cadastrar disciplina
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Retorna disciplina inserida com sucesso no banco de dados</returns>
        /// <response code="201">Disciplina inserida com sucesso</response>
        /// <respone code="404">Não encontrou a disciplina selecionada</respone>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Disciplina value)
        {
            try
            {
                    MockDisciplina.Disciplinas.Add(value);
                    return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Atualizar disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>Retorna disciplina atualizada do banco de dados</returns>
        ///<response code="202">A atualização foi feita com sucesso</response>
        /// <respone code="404">Atualização não realizada</respone>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Disciplina value)
        {
            try
            {
                var mockDisciplinaSelecionada = MockDisciplina.Disciplinas.FirstOrDefault(x => x.Id == id);
                if (mockDisciplinaSelecionada != null)
                {
                    mockDisciplinaSelecionada.Nome = value.Nome;
                    mockDisciplinaSelecionada.CargaHoraria = value.CargaHoraria;
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
        /// Remover disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna disciplina excluída com sucesso no banco de dados</returns>
        /// <response code="204">Disciplina excluída com sucesso</response>
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
                var mockDisciplinaSelecionada = MockDisciplina.Disciplinas.FirstOrDefault(x => x.Id == id);
                if (mockDisciplinaSelecionada != null)
                {
                    MockDisciplina.Disciplinas.Remove(mockDisciplinaSelecionada);
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