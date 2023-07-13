using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using eShield_API.Entities;

namespace eShield_API.Data.eShield;

public partial class EShieldContext : DbContext
{
    public EShieldContext()
    {
    }

    public EShieldContext(DbContextOptions<EShieldContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamCode> ExamCodes { get; set; }

    public virtual DbSet<ExamStudent> ExamStudents { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<ProxyDatum> ProxyData { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<VisitedSite> VisitedSites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3214EC078BD1E140");

            entity.ToTable("Course");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exam__3214EC07A52B7122");

            entity.ToTable("Exam");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ExamDate).HasColumnType("date");
        });

        modelBuilder.Entity<ExamCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExamCode__3214EC0767C63374");

            entity.ToTable("ExamCode");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ExamStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExamStud__3214EC078009A461");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamStudents)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamStudents_Exam");

            entity.HasOne(d => d.Student).WithMany(p => p.ExamStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamStudents_Student");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professo__3214EC079ED3A478");

            entity.ToTable("Professor");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProxyDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProxyDat__3214EC07EBBD1826");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC0720628E92");

            entity.ToTable("Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VisitedSite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VisitedS__3214EC076C01D123");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Exam).WithMany(p => p.VisitedSites)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VisitedSites_Exam");

            entity.HasOne(d => d.Student).WithMany(p => p.VisitedSites)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VisitedSites_Student");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
