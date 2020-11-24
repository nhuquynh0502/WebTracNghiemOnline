namespace WebTracNghiemOnline
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebTracNghiemOnline : DbContext
    {
        public WebTracNghiemOnline()
            : base("name=WebTracNghiemOnline")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Join_Quiz> Join_Quiz { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizs { get; set; }
        public virtual DbSet<Type_of_Question> Type_of_Question { get; set; }
        public virtual DbSet<User_Admin> User_Admin { get; set; }
        public virtual DbSet<User_Answer> User_Answer { get; set; }
        public virtual DbSet<User_Ask> User_Ask { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => new { e.ID_Quiz, e.ID_Question })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quiz>()
                .Property(e => e.Keys)
                .IsUnicode(false);

            modelBuilder.Entity<Quiz>()
                .HasMany(e => e.Join_Quiz)
                .WithRequired(e => e.Quiz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quiz>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Quiz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type_of_Question>()
                .HasMany(e => e.Questions)
                .WithOptional(e => e.Type_of_Question1)
                .HasForeignKey(e => e.Type_of_Question);

            modelBuilder.Entity<User_Admin>()
                .Property(e => e.MSGV)
                .IsUnicode(false);

            modelBuilder.Entity<User_Answer>()
                .Property(e => e.MSSV)
                .IsUnicode(false);

            modelBuilder.Entity<User_Ask>()
                .Property(e => e.MSGV)
                .IsUnicode(false);

            modelBuilder.Entity<User_Ask>()
                .HasMany(e => e.Quizs)
                .WithOptional(e => e.User_Ask)
                .HasForeignKey(e => e.Creator);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Join_Quiz)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.User_Admin)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.User_Answer)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.User_Ask)
                .WithRequired(e => e.User);
        }
    }
}
