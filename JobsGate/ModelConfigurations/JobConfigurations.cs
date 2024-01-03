using JobsGate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace JobsGate.ModelConfigurations
{
    public class JobConfigurations: IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {

            builder
                .Property(i => i.Salary)
                .HasColumnType("Money");

            builder
                .Property(i => i.Experience)
                .HasDefaultValue(1);

            builder
                .Property(i => i.Vacancies)
                .HasDefaultValue(1);

            builder
                .Property(i=>i.PostedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(i => i.Category)
                .WithMany(i=>i.Jobs)
                .HasForeignKey(i=>i.CategoryId);

            builder
                .HasOne(i => i.Employeer)
                .WithMany(i => i.Jobs)
                .HasForeignKey(i => i.EmployeerId);

            builder
                .HasOne(i => i.Industry)
                .WithMany(i => i.Jobs)
                .HasForeignKey(i => i.IndustryId);

            builder
               .HasOne(i => i.JobType)
               .WithMany(i => i.Jobs)
               .HasForeignKey(i => i.JobTypeId);

            builder
                .HasMany(j => j.Employees)
                .WithMany(e=>e.Jobs)
                .UsingEntity<JobApplication>(ja=>
                {
                    ja
                        .HasOne(jaj => jaj.Job)
                        .WithMany(js => js.JobsApplications)
                        .HasForeignKey(jai=>jai.JobId);

                    ja
                        .HasOne(jae => jae.Employee)
                        .WithMany(emp => emp.JobsApplications)
                        .HasForeignKey(jai=>jai.EmployeeId);
                });

        }
    }
}
