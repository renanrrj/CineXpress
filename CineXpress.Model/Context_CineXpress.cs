﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CineXpress.Model
{
    public partial class Context_CineXpress : DbContext
    {
        public Context_CineXpress()
        {
        }

        public Context_CineXpress(DbContextOptions<Context_CineXpress> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbFilme> TbFilme { get; set; }
        public virtual DbSet<TbFuncionario> TbFuncionario { get; set; }
        public virtual DbSet<TbRelacional> TbRelacional { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9UMSEK5\\SQLEXPRESS;Initial Catalog=CineXpressDB5p;User ID=sa;Password=sa123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbRelacional>(entity =>
            {
                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbRelacional)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_tb_Relacional_tb_Cliente");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbRelacional)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("FK_tb_Relacional_tb_Filme");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.TbRelacional)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_tb_Relacional_tb_Funcionario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}