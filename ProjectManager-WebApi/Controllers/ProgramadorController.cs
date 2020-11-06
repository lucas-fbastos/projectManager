using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager_WebApi.Data;
using ProjectManager_WebApi.Dto;
using ProjectManager_WebApi.Models;

namespace ProjectManager_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramadorController : ControllerBase
    {
         private readonly IRepository _repo;

        public ProgramadorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProgramadoresAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{ProgramadorID}")]
        public async Task<IActionResult> GetByProgramadorId(int ProgramadorID)
        {
            try
            {
                var result = await _repo.GetProgramadorAsyncById(ProgramadorID);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByProjeto/{projetoID}")]
        public async Task<IActionResult> GetByProjetoId(int projetoID)
        {
            try
            {
                var result = await _repo.GetProgramadoresAsyncByProjetoId(projetoID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(ProgramadorDTO dto)
        {
            try
            {
                var projeto = await _repo.GetProjetoAsyncById(dto.ProjetoId);
                if(projeto==null) return NotFound();
                if(dto.Nome==null) return BadRequest();
                Programador programador = new Programador();
                programador.Nome = dto.Nome;
                programador.ProjetoId = projeto.Id;
                programador.Telefone = dto.Telefone;

                _repo.Add(programador);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(programador);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{programadorID}")]
        public async Task<IActionResult> put(int programadorID, Programador model)
        {
            try
            {
                var programador = await _repo.GetProgramadorAsyncById(programadorID);
                if(programador == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{programadorID}")]
        public async Task<IActionResult> delete(int programadorID)
        {
            try
            {
                var programador = await _repo.GetProgramadorAsyncById(programadorID);
                if(programador == null) return NotFound();

                _repo.Delete(programador);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok( new { message = "Deletado"});
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

    }
}