using IT420.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data
{
    public class IT420DBContext : DbContext
    {
        public IT420DBContext(DbContextOptions<IT420DBContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;                        
        }

        /*
        
        public IT420DBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            if (!opt.IsConfigured)
            {
                opt.UseSqlServer(@"server=(localdb)\ProjectsV13;initial catalog=IT420;trusted_connection=true");
            }
        }
        */
        public DbSet<Talk> Talks { get; set; }

        public DbSet<TalkType> TalkTypes { get; set; }

        public DbSet<TalkComment> TalkComments { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }

        public DbSet<ExpertQuestionType> ExpertQuestionTypes { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<ExpertQuestion> ExpertQuestions { get; set; }
        public DbSet<ExpertQuestionAnswer> ExpertAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TalkType>().HasData(new TalkType { TypeId = 1, Type = "Parenting" });
            modelBuilder.Entity<TalkType>().HasData(new TalkType { TypeId = 2, Type = "Career" });
            modelBuilder.Entity<TalkType>().HasData(new TalkType { TypeId = 3, Type = "Babycare" });
            modelBuilder.Entity<TalkType>().HasData(new TalkType { TypeId = 4, Type = "Food and Nutrition" });

            modelBuilder.Entity<BlogType>().HasData(new BlogType { blogTypeId = 1, type = "Breastfeeding" });
            modelBuilder.Entity<BlogType>().HasData(new BlogType { blogTypeId = 2, type = "Eduction and Learning" });
            modelBuilder.Entity<BlogType>().HasData(new BlogType { blogTypeId = 3, type = "Hobbies" });

            modelBuilder.Entity<ExpertQuestionType>().HasData(new ExpertQuestionType { id = 1, type = "Health Corner" });
            modelBuilder.Entity<ExpertQuestionType>().HasData(new ExpertQuestionType { id = 2, type = "Nutrition Corner" });
        }

    }   
}
