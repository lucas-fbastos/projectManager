using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager_WebApi.Models;

namespace ProjectManager_WebApi.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Programador[]> GetAllProgramadoresAsync()
        {
            IQueryable<Programador> query = _context.Programadores;

            query = query.Include(p => p.Projeto);
            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Projeto> GetNextProjeto()
        {
            IQueryable<Projeto> query = _context.Projetos;
              
            query = query.Include(pr => pr.Programadores);
            query = query.AsNoTracking()
                         .OrderBy(p => p.Prazo)
                         .Where(p => (DateTime.Now.CompareTo(p.Prazo)<0))
                         .Take(1);

            return await query.FirstOrDefaultAsync();
        }

          public async Task<Projeto[]> GetProjetoVencido()
        {
            IQueryable<Projeto> query = _context.Projetos;
              
            query = query.Include(pr => pr.Programadores);
            query = query.AsNoTracking()
                         .OrderBy(p => p.Prazo)
                         .Where(p => (DateTime.Now.CompareTo(p.Prazo)>0));

            return await query.ToArrayAsync();
        }
        public async Task<Programador> GetProgramadorAsyncById(int programadorId)
        {
            IQueryable<Programador> query = _context.Programadores;

            query = query.Include(p => p.Projeto);
            query = query.AsNoTracking()
                         .OrderBy(programador => programador.Id)
                         .Where(programador => programador.Id == programadorId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Programador[]> GetProgramadoresAsyncByProjetoId(int projetoID)
        {
            IQueryable<Programador> query = _context.Programadores;

            query = query.Include(p => p.Projeto);
            query = query.AsNoTracking()
                         .OrderBy(programador => programador.Id)
                         .Where(programador => programador.Projeto.Id == projetoID);

            return await query.ToArrayAsync();
        }


        public async Task<Projeto[]> GetAllProjetosAsync()
        {
            IQueryable<Projeto> query = _context.Projetos;       
            
            query = query.Include(pr => pr.Programadores);
            query = query.AsNoTracking()
                         .OrderBy(projeto => projeto.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Projeto> GetProjetoAsyncById(int projetoId)
        {
            IQueryable<Projeto> query = _context.Projetos;

            query = query.Include(pr => pr.Programadores);
            query = query.AsNoTracking()
                         .OrderBy(projeto => projeto.Id)
                         .Where(projeto => projeto.Id == projetoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Projeto[]> GetProjetosAsyncByProgramadorId(int programadorId)
        {
            IQueryable<Projeto> query = _context.Projetos;
            query = query.Include(pr => pr.Programadores);
            query = query.AsNoTracking()
                         .OrderBy(projeto => projeto.Id)
                         .Where(projeto => projeto.Programadores.Any(programador => programador.Id == programadorId));

            return await query.ToArrayAsync();
        }

    }
}