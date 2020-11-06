using System.Threading.Tasks;
using ProjectManager_WebApi.Models;

namespace ProjectManager_WebApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Programador[]> GetAllProgramadoresAsync();        
        Task<Programador> GetProgramadorAsyncById(int programadorId);
        Task<Programador[]> GetProgramadoresAsyncByProjetoId(int projetoID);
        Task<Projeto[]> GetAllProjetosAsync();
        Task<Projeto> GetProjetoAsyncById(int ProjetoId);
        Task<Projeto[]> GetProjetosAsyncByProgramadorId(int programadorID);
        Task<Projeto> GetNextProjeto();
        Task<Projeto[]> GetProjetoVencido();
    }
    
}