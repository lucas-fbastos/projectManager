using System.Collections.Generic;
using ProjectManager_WebApi.Models;

namespace ProjectManager_WebApi.Dto
{
    public class DadosEstatisticosDTO
    {

        public int QuantidadeProjetos { get; set; }
        public int QuantidadeProgramadores { get; set; }
        public string ProjetoComMenosProgramadores { get; set; }
        public Dictionary<string,int> Quantitativos = new Dictionary<string,int>();
        public Projeto proximoProjeto {get; set;}

        public Projeto[] projetosVencidos {get; set;}

        public DadosEstatisticosDTO(int QuantidadeProjetos, int QuantidadeProgramadores, string ProjetoComMenosProgramadores,  Dictionary<string,int> Quantitativos,
             Projeto proximoProjeto, Projeto[] projetosVencidos)
        {
            this.QuantidadeProjetos = QuantidadeProjetos;
            this.QuantidadeProgramadores = QuantidadeProgramadores;
            this.ProjetoComMenosProgramadores = ProjetoComMenosProgramadores;
            this.Quantitativos = Quantitativos;
            this.proximoProjeto = proximoProjeto;
            this.projetosVencidos = projetosVencidos;
        }

        public DadosEstatisticosDTO() { }
    }
    
}