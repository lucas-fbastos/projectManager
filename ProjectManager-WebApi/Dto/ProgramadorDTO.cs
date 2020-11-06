namespace ProjectManager_WebApi.Dto
{
    public class ProgramadorDTO
    {

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int ProjetoId { get; set; }

        public ProgramadorDTO(int ProjetoId, string Nome, string Telefone)
        {
            this.ProjetoId = ProjetoId;
            this.Nome = Nome;
            this.Telefone = Telefone;
        }

        public ProgramadorDTO() { }
    }
    
}