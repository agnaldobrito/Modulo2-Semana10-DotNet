using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University2.Context;
using University2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace University2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private UniversityContext _universityContext;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(UniversityContext universityContext,
            ILogger<StudentsController> logger)
        {
            _universityContext = universityContext;
            _logger = logger;
        }



        /// <summary>
        /// Busca e retorna uma lista de alunos no banco de dados
        /// </summary>
        /// <returns>Retorna uma lista de alunos</returns>
        /// <response code="200">Retorna com sucesso a lista de alunos</response>
        /// <response code="404">Não foi encontrada a lista de alunos</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Student> students = await _universityContext.Students.ToListAsync();

                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Endpoint: {nameof(Get)}");

                return students.Any() ? Ok(students) : NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Endpoint: {nameof(Get)}");

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Busca e retorna do banco de dados o aluno especificado pelo ID
        /// </summary>
        /// <param name="id">ID do aluno</param>
        /// <returns>Retorna Aluno especificado</returns>
        /// <response code="200">Retorna com sucesso o aluno especificado</response>
        /// <response code="404">Aluno não encontrado</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Student? student = await _universityContext.Students.FirstOrDefaultAsync(x => x.Id == id);
                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Endpoint: {nameof(GetById)} ID:{id}");
                return student != null ? Ok(student) : NotFound();  
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Endpoint: {nameof(GetById)}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Adiciona o aluno ao banco de dados
        /// </summary>
        /// <param name="student">Informações do aluno</param>
        /// <returns>Retorna resposta se o aluno foi inserido com sucesso no banco de dados</returns>
        /// <response code="201">O aluno foi inserido com sucesso</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            try
            {
                _universityContext.Students.Add(student);
                await _universityContext.SaveChangesAsync();
                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Endpoint: {nameof(Post)}");
                return CreatedAtAction(nameof(GetById), new { Id = student.Id }, student);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Endpoint: {nameof(Post)}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera informações sobre o aluno especificado
        /// </summary>
        /// <param name="id">ID do aluno</param>
        /// <param name="info">Info do aluno</param>
        /// <returns>Retorna resposta se a informação do aluno foi alteada com sucesso no banco de dados</returns>
        /// <response code="202">A informação do aluno foi alteada com sucesso</response>
        /// <response code="404">Não foi encontrado o aluno especificado</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Student info)
        {
            try
            {
                bool studentExist = _universityContext.Students.Any(x => x.Id == id);

                if (!studentExist) return NotFound(); 
                

                info.Id = id;
                _universityContext.Students.Update(info);
                await _universityContext.SaveChangesAsync();

                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Endpoint: {nameof(Put)} ID:{id}");

                return StatusCode(202);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Endpoint: {nameof(Put)}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remove o aluno do banco de dados
        /// </summary>
        /// <param name="id">ID do aluno</param>
        /// <returns>Retorna aluno removido com sucesso do banco de dados</returns>
        /// <response code="204">Aluno removido com sucesso</response>
        /// <response code="404">Aluno não encontrado</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Student? student = await _universityContext.Students.FindAsync(id);
                if(student == null) return NotFound();

                _universityContext.Students.Remove(student);
                await _universityContext.SaveChangesAsync();
                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Endpoint: {nameof(Delete)} ID:{id}");


                return StatusCode(204);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Endpoint: {nameof(Delete)}");
                return StatusCode(500);

            }
        }
    }
}
