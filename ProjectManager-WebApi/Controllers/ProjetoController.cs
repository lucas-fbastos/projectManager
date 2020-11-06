using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager_WebApi.Data;
using ProjectManager_WebApi.Models;

namespace ProjectManager_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : ControllerBase
    {
         private readonly IRepository _repo;

        public ProjetoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProjetosAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{ProjetoID}")]
        public async Task<IActionResult> GetByProjetoId(int ProjetoID)
        {
            try
            {
                var result = await _repo.GetProjetoAsyncById(ProjetoID);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("byProgramador/{programadorID}")]
        public async Task<IActionResult> GetByProgramadorId(int programadorID)
        {
            try
            {
                var result = await _repo.GetProjetosAsyncByProgramadorId(programadorID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Projeto projeto)
        {
            try
            {
                if(projeto.Nome==null) return BadRequest();
                _repo.Add(projeto);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(projeto);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{ProjetoId}")]
        public async Task<IActionResult> put(int ProjetoId, Projeto model)
        {
            try
            {
                var projeto = await _repo.GetProjetoAsyncById(ProjetoId);
                if(projeto == null) return NotFound();

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

        [HttpDelete("{ProjetoId}")]
        public async Task<IActionResult> delete(int ProjetoId)
        {
            try
            {
                var projeto = await _repo.GetProjetoAsyncById(ProjetoId);
                if(projeto == null) return NotFound();

                _repo.Delete(projeto);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(new {message="Deletado"});
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