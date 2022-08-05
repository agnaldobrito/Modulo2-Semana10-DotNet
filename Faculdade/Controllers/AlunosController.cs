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
        // GET: api/<AlunosController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Aluno>> Get()
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

        // GET api/<AlunosController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Aluno>> Get(int id)
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

        // POST api/<AlunosController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Aluno value)
        {
            try
            {
                if(value != null)
                {
                    MockAluno.Alunos.Add(value);
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(400);
                }
                
            }
            catch
            {
                    return StatusCode(500);
            }
        }

        // PUT api/<AlunosController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
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

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
