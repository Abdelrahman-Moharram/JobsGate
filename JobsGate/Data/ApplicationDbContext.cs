using JobsGate.ModelConfigurations;
using JobsGate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobsGate.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Tables And Schemas
            
            builder.Entity<ApplicationUser>().ToTable("Users", schema: "Identity");
            builder.Entity<IdentityRole>().ToTable("Roles", schema: "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", schema: "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", schema: "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", schema: "Identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", schema: "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", schema: "Identity");

            builder.Entity<Job>().ToTable("Jobs", schema: "job");
            builder.Entity<Category>().ToTable("Categories", schema: "job");
            builder.Entity<Employee>().ToTable("Employees", schema: "job");
            builder.Entity<Employer>().ToTable("Employeers", schema: "job");
            builder.Entity<Industry>().ToTable("Industries", schema: "job");
            builder.Entity<JobApplication>().ToTable("JobApplications", schema: "job");
            builder.Entity<JobType>().ToTable("JobTypes", schema: "job");

            // _____________________________________________________________ //

            new JobConfigurations().Configure(builder.Entity<Job>());


            // Data Seeding
            string AdminRoleId = Guid.NewGuid().ToString();
            string AdminId = Guid.NewGuid().ToString();


            // Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = AdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Employer",
                    NormalizedName = "EMPLOYER"
                }
            );

            //  create system admin

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        Id = AdminId,
                        UserName = "Admin",
                        NormalizedUserName = "Admin",
                        Email = "admin@site.com",
                        NormalizedEmail = "admin@site.com",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty,
                        Image = "img/users/user.webp"
                    });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = AdminRoleId,
                UserId = AdminId
            });

            builder.Entity<JobType>().HasData(
                new JobType
                {
                    Name = "Full Time"
                },
                new JobType
                {
                    Name = "Part Time"
                },
                new JobType
                {
                    Name = "Remote"
                }
            );

            // _____________________________________________________________ //



        }

    }
}
