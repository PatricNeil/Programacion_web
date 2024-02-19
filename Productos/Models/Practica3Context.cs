using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Productos.Models;

public partial class Practica3Context : DbContext
{
    public Practica3Context()
    {
    }

    public Practica3Context(DbContextOptions<Practica3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=LAPTOP-2J3H8ERB; database=practica3; integrated security=true; Encrypt=False; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__FF341C0D48B3139F");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
