﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WPF.Database
{
    public partial class Database : DbContext
    {
        public Database()
        {
        }

        public Database(DbContextOptions<Database> options)
            : base(options)
        {
        }

        public virtual DbSet<Record> Recordes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string beginPathSqlDB = ConfigurationManager.ConnectionStrings["BeginPathConnection"].ConnectionString;
                string endPathSqlDB = ConfigurationManager.ConnectionStrings["EndPathConnection"].ConnectionString;
                string pathDirectory = Directory.GetCurrentDirectory();
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer($"{beginPathSqlDB + pathDirectory + endPathSqlDB}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => e.NameUser)
                    .HasName("PK__TableRec__13F1851684C1D1B7");

                entity.Property(e => e.NameUser)
                    .HasMaxLength(50)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.NameUser)
                    .HasName("PK__Users__13F1851650D0B2C2");

                entity.Property(e => e.NameUser)
                    .HasMaxLength(50)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
