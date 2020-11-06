using System.Collections.Generic;

namespace ProjectManager_WebApi.Models
{
    public class Programador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Projeto Projeto {get; set;}
        public int ProjetoId {get;set;}


        public Programador(int Id, string Nome, string Telefone, int ProjetoId)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Telefone = Telefone;
            this.ProjetoId = ProjetoId;
        }

        public Programador() { }
    }
    
}