using Microsoft.EntityFrameworkCore;
using MelikCirak.EntityLayer.Concrete;
using System;

namespace MelikCirak.DataAcessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DbKonusarakOgren.db;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //for user table
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .Property(x => x.FulllName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(x => x.Mail)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(25);




            //for quiz table
            modelBuilder.Entity<Quiz>().HasKey(x => x.Id);
            modelBuilder.Entity<Quiz>().Property(x => x.Title).HasMaxLength(250);
            modelBuilder.Entity<Quiz>()
                .HasOne(x => x.User)
                .WithMany(x => x.Quizzes)
                .HasForeignKey(x => x.UserId);



            //for question table
            modelBuilder.Entity<Question>().HasKey(x => x.Id);

            modelBuilder.Entity<Question>()
                .Property(x => x.QuestionContent)
                .HasMaxLength(250);

            modelBuilder.Entity<Question>()
                .HasOne(x => x.Quiz)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuizId);



            //for option table
            modelBuilder.Entity<Option>().HasKey(x => x.Id);
            modelBuilder.Entity<Option>()
                .Property(x => x.IsAnswer)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<Option>()
               .Property(x => x.OptionContent)
               .HasMaxLength(100);

            modelBuilder.Entity<Option>()
                .HasOne(x => x.Question)
                .WithMany(x => x.Options)
                .HasForeignKey(x => x.QuestionId);



        }
    }
}
