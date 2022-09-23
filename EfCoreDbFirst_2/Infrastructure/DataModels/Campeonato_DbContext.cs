using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCoreDbFirst_2.Infrastructure.DataModels
{
    public partial class Campeonato_DbContext : DbContext
    {
        public Campeonato_DbContext()
        {
        }

        public Campeonato_DbContext(DbContextOptions<Campeonato_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbGenero> TbGeneros { get; set; } = null!;
        public virtual DbSet<TbInscrito> TbInscritos { get; set; } = null!;
        public virtual DbSet<TbInstituicao> TbInstituicaos { get; set; } = null!;
        public virtual DbSet<TbJogador> TbJogadors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost; Database=Campeonato; user id=postgres; password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbGenero>(entity =>
            {
                entity.ToTable("tb_genero");

                entity.HasIndex(e => e.Genero, "tb_genero_genero_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .HasColumnName("genero");
            });

            modelBuilder.Entity<TbInscrito>(entity =>
            {
                entity.ToTable("tb_inscrito");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataPub).HasColumnName("data_pub");

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.Instituicao).HasColumnName("instituicao");

                entity.Property(e => e.Jogador).HasColumnName("jogador");

                entity.HasOne(d => d.GeneroNavigation)
                    .WithMany(p => p.TbInscritos)
                    .HasForeignKey(d => d.Genero)
                    .HasConstraintName("tb_inscrito_genero_fkey");

                entity.HasOne(d => d.InstituicaoNavigation)
                    .WithMany(p => p.TbInscritos)
                    .HasForeignKey(d => d.Instituicao)
                    .HasConstraintName("tb_inscrito_instituicao_fkey");

                entity.HasOne(d => d.JogadorNavigation)
                    .WithMany(p => p.TbInscritos)
                    .HasForeignKey(d => d.Jogador)
                    .HasConstraintName("tb_inscrito_jogador_fkey");
            });

            modelBuilder.Entity<TbInstituicao>(entity =>
            {
                entity.ToTable("tb_instituicao");

                entity.HasIndex(e => e.Nome, "tb_instituicao_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(35)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TbJogador>(entity =>
            {
                entity.ToTable("tb_jogador");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DataNasc).HasColumnName("data_nasc");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(40)
                    .HasColumnName("sobrenome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
