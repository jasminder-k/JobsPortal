using JobsPortal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsPortal.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {


        }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<EmployerCompany> EmployerCompanies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<JobDetails> JobDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplication>()
                .ToTable("JobApplication");
            modelBuilder.Entity<JobDetails>()
                .ToTable("JobDetails");
            modelBuilder.Entity<Resume>()
                .ToTable("Resume");

            // defining relationships and foreign keys
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin")
                .OwnsOne(x => x.AdminUser);
                entity.HasMany(admin => admin.JobDetails)
                .WithOne(jobDetails => jobDetails.Admin)
                .HasForeignKey(admin => admin.AdminId);

                entity.HasMany(admin => admin.Resumes)
                .WithOne(resume => resume.Admin)
                .HasForeignKey(admin => admin.AdminId);

                entity.HasMany(admin => admin.Jobs)
                .WithOne(jobs => jobs.Admin)
                .HasForeignKey(admin => admin.AdminId);
            });

            modelBuilder.Entity<JobSeeker>(entity =>
            {
                entity.ToTable("JobSeeker")
                .OwnsOne(x => x.JobSeekerUser);
                entity.HasMany(jobSeeker => jobSeeker.JobApplications)
                .WithOne(jobApp => jobApp.JobSeeker)
                .HasForeignKey(jobSeeker => jobSeeker.JobSeekerId);

                entity.HasOne(jobSeeker => jobSeeker.Resume)
                 .WithOne(resume => resume.JobSeeker)
                 .HasForeignKey<Resume>(resume => resume.Id);
             });

            modelBuilder.Entity<EmployerCompany>(entity =>
            {
                entity.ToTable("EmployerCompany")
                .OwnsOne(x => x.EmployerCompanyUser);

                entity.HasMany(company => company.JobDetails)
                .WithOne(jobDetails => jobDetails.EmployerCompany)
                .HasForeignKey(company => company.EmployerCompanyId);
            });


            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");
                entity.HasMany(job => job.JobAppications)
               .WithOne(jobApp => jobApp.Job)
               .HasForeignKey(job => job.JobId);
            });
               
        }
    }
}
