﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CineXpress.Model
{
    public partial class ContextCineXpress : DbContext
    {
        public ContextCineXpress()
        {
        }

        public ContextCineXpress(DbContextOptions<ContextCineXpress> options)
            : base(options)
        {
        }

        public virtual DbSet<CadastroCliente> CadastroCliente { get; set; }
        public virtual DbSet<CadastroFuncionario> CadastroFuncionario { get; set; }
        public virtual DbSet<Filme> Filme { get; set; }
        public virtual DbSet<Relacional> Relacional { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JDE8Q70\\SQLEXPRESS;Initial Catalog=CineXpressDB5p;User ID=sa;Password=sa123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CadastroCliente>(entity =>
            {
                entity.HasKey(e => e.IdC)
                    .HasName("PK__Cadastro__DC501A2DDB045A05");
            });

            modelBuilder.Entity<CadastroFuncionario>(entity =>
            {
                entity.HasKey(e => e.IdF)
                    .HasName("PK__Cadastro__DC501A2A48535CE0");
            });

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.HasKey(e => e.Idfl)
                    .HasName("PK__Filme__9DB7BA4499DD0EE0");
            });

            modelBuilder.Entity<Relacional>(entity =>
            {
                entity.HasKey(e => e.IdR)
                    .HasName("PK__Relacion__C496001473428B4C");

                entity.HasOne(d => d.IdCadastroNavigation)
                    .WithMany(p => p.Relacional)
                    .HasForeignKey(d => d.IdCadastro)
                    .HasConstraintName("FK_Relacional_CadastroCliente");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.Relacional)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("FK_Relacional_Filme");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Relacional)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_Relacional_CadastroFuncionario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}