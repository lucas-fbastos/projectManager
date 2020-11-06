using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager_WebApi.Data;
using ProjectManager_WebApi.Dto;
using ProjectManager_WebApi.Models;
using System.Collections.Generic;

namespace ProjectManager_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DadosEstatisticosController : ControllerBase
    {
         private readonly IRepository _repo;

        public DadosEstatisticosController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("projetos")]
        public async Task<IActionResult> Get()
        {
            try{
                var projetos = await _repo.GetAllProjetosAsync();
                var programadores = await  _repo.GetAllProgramadoresAsync();
                var menorProjeto = this.getMenorProjeto(projetos);
                var proximoProjeto = await _repo.GetNextProjeto();
                var projetosVencidos = await _repo.GetProjetoVencido();
                Dictionary<string,int> dados = new Dictionary<string,int>();
                dados = this.separaPorProjeto(programadores);
                DadosEstatisticosDTO dto = new DadosEstatisticosDTO();
                dto.QuantidadeProjetos = projetos.Length;
                dto.ProjetoComMenosProgramadores = menorProjeto;
                dto.QuantidadeProgramadores = programadores.Length;
                dto.Quantitativos = dados;
                dto.proximoProjeto = proximoProjeto;
                dto.projetosVencidos = projetosVencidos;
                return Ok(dto);
            }catch (Exception ex) {
               return BadRequest($"Erro: {ex.Message}");
            }
        }

        private Dictionary<string,int> separaPorProjeto(Programador[] programadores){
            Dictionary<string,int> dados = new Dictionary<string,int>();
            foreach (Programador programador in programadores)
            {
                if(!dados.ContainsKey(programador.Projeto.Nome)){
                    dados[programador.Projeto.Nome] = 1;
                }else{
                    dados[programador.Projeto.Nome] +=1;
                }
            }
            return dados;
        }

        private string getMenorProjeto(Projeto[] projetos){
            int menor = 0;
            int i = 0;
            string menorProjeto = "";
            foreach (Projeto projeto in projetos)
            {
                int size =  new List<Programador>(projeto.Programadores).Count;
                if(i==0){
                    menorProjeto = projeto.Nome;
                    menor = size;
                    i++;
                }else if(size < menor){
                    menorProjeto = projeto.Nome;
                    menor = size;
                }
            }
            return menorProjeto;
        }

    }
}