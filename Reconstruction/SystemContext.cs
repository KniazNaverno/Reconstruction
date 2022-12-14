using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Reconstruction
{
    public partial class SystemContext : DbContext
    {
        public SystemContext()
        {
        }

        public SystemContext(DbContextOptions<SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=System;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("Status");

                entity.Property(e => e.IdStatus).ValueGeneratedOnAdd().IsRequired();

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.IdTasks);

                entity.ToTable("Task");

                entity.Property(e => e.IdTasks).ValueGeneratedOnAdd().IsRequired();

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Status");

                entity.HasOne(d => d.IdUserClientNavigation)
                    .WithMany(p => p.TaskIdUserClientNavigations)
                    .HasForeignKey(d => d.IdUserClient)
                    .HasConstraintName("FK_Task_User");

                entity.HasOne(d => d.IdUserWorkerNavigation)
                    .WithMany(p => p.TaskIdUserWorkerNavigations)
                    .HasForeignKey(d => d.IdUserWorker)
                    .HasConstraintName("FK_Task_User1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUsers);

                entity.ToTable("User");

                entity.Property(e => e.IdUsers).ValueGeneratedOnAdd().IsRequired();

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
