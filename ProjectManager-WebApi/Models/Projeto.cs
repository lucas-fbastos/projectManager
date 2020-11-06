using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager_WebApi.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Prazo { get; set; }

        public IEnumerable<Programador> Programadores { get; set; }

        public Projeto(int id, string nome, DateTime prazo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Prazo = prazo;
        }

        public Projeto() {  }
    }
}
