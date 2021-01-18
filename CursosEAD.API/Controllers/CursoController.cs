using CursosEAD.Application.Services.Interface;
using CursosEAD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CursosEAD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        readonly ICursoService _cursoService;
        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET: api/Curso
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               return Ok( _cursoService.BuscarCursos());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/Curso/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_cursoService.BuscarCurso(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST api/Curso
        [HttpPost]
        public IActionResult Post([FromBody] Curso curso)
        {
            try
            {
                return Ok(_cursoService.InserirCursos(curso));

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT api/Curso
        [HttpPut()]
        public IActionResult Put([FromBody] Curso curso)
        {
            try
            {
                return Ok(_cursoService.AtualizarCurso(curso));

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE api/Curso/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_cursoService.DeletarCurso(id));

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
