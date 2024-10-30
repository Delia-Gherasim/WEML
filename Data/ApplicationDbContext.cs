using ElderyPeopleCare.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElderyPeopleCare.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Challange> Challanges { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ChallangeQuestions> ChallangeQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChallangeQuestions>()
                .HasKey(cq => new { cq.cId, cq.questionId });
            modelBuilder.Entity<ChallangeQuestions>()
                .HasOne(cq => cq.Challange)
                .WithMany(c => c.ChallangeQuestions)
                .HasForeignKey(cq => cq.cId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ChallangeQuestions>()
                .HasOne(cq => cq.Question)
                .WithMany(q => q.ChallangeQuestions)
                .HasForeignKey(cq => cq.questionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>()
                .Property(q => q.qId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Challange>()
                .Property(c => c.cId)
                .ValueGeneratedOnAdd();
        }
    }

}

