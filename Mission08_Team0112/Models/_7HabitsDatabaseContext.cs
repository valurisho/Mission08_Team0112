using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0112.Models;

public partial class _7HabitsDatabaseContext : DbContext
{
    public _7HabitsDatabaseContext()
    {
    }

    public _7HabitsDatabaseContext(DbContextOptions<_7HabitsDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ToDo> ToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=7_habits_database.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Categories_CategoryId").IsUnique();
        });

        modelBuilder.Entity<ToDo>(entity =>
        {
            entity.HasKey(e => e.TaskId);

            entity.ToTable("ToDo");

            entity.HasIndex(e => e.TaskId, "IX_ToDo_TaskId").IsUnique();

            entity.HasOne(d => d.Category).WithMany(p => p.ToDos)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
