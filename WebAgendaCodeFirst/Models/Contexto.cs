using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;


namespace WebAgendaCodeFirst.Models
{
    public class Contexto : DbContext
    {

        // mapeamento da entidade para a tabela
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        // provedor e string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=WebAgendaCodeFirst;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(t =>
            {
                t.ToTable("cliente");
                t.HasKey(c => c.Id);
                t.Property(c => c.Nome).HasMaxLength(50).IsRequired();
                t.Property(c => c.Telefone).HasColumnType("VARCHAR(12)").IsRequired();
                t.Property(c => c.Nascimento).HasConversion<DateTime>().IsRequired();
                t.Property(c => c.Observacao).HasColumnType("VARCHAR(100)");
                t.Property(c => c.Ativo).HasColumnType("tinyint");
            });

            modelBuilder.Entity<Procedimento>(t =>
            {
                t.ToTable("procedimento");
                t.HasKey(c => c.Id);
                t.Property(c => c.Nome).HasMaxLength(50).IsRequired();
                t.Property(c => c.Duracao).HasConversion<DateTime>().IsRequired();
                t.Property(c => c.Valor).HasColumnType("Decimal(6,2)").IsRequired();
            });

            modelBuilder.Entity<Agendamento>(t =>
            {
                t.ToTable("agendamento");
                t.HasKey(a => a.Id);
                t.Property(a => a.Data).HasConversion<DateTime>().IsRequired();
                t.Property(a => a.Horario).HasColumnType("VARCHAR(5)").IsRequired();
                t.Property(a => a.Valor).HasColumnType("Decimal(6,2)").IsRequired();
                t.Property(a => a.Status).HasColumnType("VARCHAR(25)").IsRequired();
                t.Property(a => a.Observacao).HasColumnType("VARCHAR(100)");
                t.Property(a => a.ClienteId).HasColumnType("int").IsRequired();
                t.Property(a => a.ProcedimentoId).HasColumnType("int").IsRequired();            
            });
        }

    }
}


