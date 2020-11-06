using Microsoft.EntityFrameworkCore;
using ProjectManager_WebApi.Models;
using System;
using System.Collections.Generic;

namespace ProjectManager_WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Programador> Programadores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<Projeto>()
                .HasData(new List<Projeto>(){
                    new Projeto(1, "Refatoração Autenticação",new DateTime(2020,12,10)),
                    new Projeto(2, "Aplicativo para restaurante",new DateTime(2020,12,17)),
                    new Projeto(3, "Painel de BI",new DateTime(2021,01,05)),
                    new Projeto(4, "ChatBot",new DateTime(2020,11,13))
                });

            builder.Entity<Programador>()
                .HasData(new List<Programador>(){
                    new Programador(1, "Lucas","61996253833",4),
                    new Programador(2, "Vivian","61999388883",4),
                    new Programador(3, "Vitor","61948546512",2),
                    new Programador(4, "Guilherme","61945123484",1),
                    new Programador(5, "Daniel","61978546218",4),
                    new Programador(6, "Marcia","61978543123",2),
                    new Programador(7, "Phelipe","61978543151",1),
                    new Programador(8, "Ana","61978541254",3),
                    new Programador(9, "Julia","61978545548",2)
                    
                });

        
        }
    }
}
