using Microsoft.EntityFrameworkCore;
using TasteonusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasteonusAPI.Data
{
    public partial class BackendDBContext : DbContext
    {
        // Dependency Injection
        public BackendDBContext(DbContextOptions<BackendDBContext> options) : base(options)
        {

        }

        //Authors collection will allow us to manage CRUD data operations in Author table
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Reward> Rewards { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Author>().HasData(
            //    new Author { AuthorId = 1, Name = "John Davis" },
            //    new Author { AuthorId = 2, Name = "Arlan Hamilton" },
            //    new Author { AuthorId = 3, Name = "Minda Harts" },
            //    new Author { AuthorId = 4, Name = "Susanne Tedrick" },
            //    new Author { AuthorId = 5, Name = "Steve Proctor" },
            //    new Author { AuthorId = 6, Name = "Michael Chen" }
            //    );

            //modelBuilder.Entity<Book>().HasData(
            //    new Book { BookId = 1, AuthorId = 1, Title = "Data Visualizations" },
            //    new Book { BookId = 2, AuthorId = 2, Title = "The Memo" }

            //);

            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER_T");
                // Configure Primary Keys                  
                entity.HasKey(u => u.Id).HasName("PK_Users");

                entity.Property(e => e.Id)
                    .HasColumnName("user_id")
                    .HasColumnType("int")
                    .UseMySqlIdentityColumn()
                    .IsRequired();

                entity.Property(e => e.Uid)
                    .HasColumnName("user_uid")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Username)
                    .HasColumnName("user_name")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasColumnName("user_email")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Password)
                    .HasColumnName("user_password")
                    .HasColumnType("varchar(30)")
                    .HasMaxLength(30);

                entity.Property(e => e.ProfileImageUrl)
                    .HasColumnName("user_imageurl")
                    .HasColumnType("longtext");

                entity.Property(e => e.Biodata)
                    .HasColumnName("user_biodata")
                    .HasColumnType("longtext");

                entity.Property(e => e.LoginMethod)
                    .HasColumnName("user_loginmethod")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Point)
                    .HasColumnName("user_point")
                    .HasColumnType("int")
                    .IsRequired();

            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("FEEDBACK_T");
                // Configure Primary Keys                  
                entity.HasKey(u => u.Id).HasName("PK_Feedbacks");

                entity.Property(e => e.Id)
                    .HasColumnName("fb_id")
                    .HasColumnType("int")
                    .UseMySqlIdentityColumn()
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnName("fb_description")
                    .HasColumnType("varchar(400)")
                    .HasMaxLength(400)
                    .IsRequired();

                entity.Property(e => e.Rating)
                    .HasColumnName("fb_rating")
                    .HasColumnType("decimal(2,1)")
                    .IsRequired();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int");

                entity.HasOne(x => x.User).WithOne(x => x.Feedback).HasForeignKey<Feedback>(x => x.UserId);


            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("RECIPE_T");
                // Configure Primary Keys                  
                entity.HasKey(u => u.Id).HasName("PK_Recipes");

                entity.Property(e => e.Id)
                    .HasColumnName("rec_id")
                    .HasColumnType("int")
                    .UseMySqlIdentityColumn()
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("rec_name")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Ingredient)
                    .HasColumnName("rec_ingredient")
                    .HasColumnType("longtext")
                    .IsRequired();

                entity.Property(e => e.Instruction)
                    .HasColumnName("rec_instruction")
                    .HasColumnType("longtext")
                    .IsRequired();

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("rec_imageurl")
                    .HasColumnType("varchar(400)")
                    .HasMaxLength(400)
                    .IsRequired();

                entity.Property(e => e.VideoUrl)
                    .HasColumnName("rec_videourl")
                    .HasColumnType("varchar(400)")
                    .HasMaxLength(400);

                entity.Property(e => e.Rating)
                    .HasColumnName("rec_rating")
                    .HasColumnType("decimal(2,1)")
                    .IsRequired();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int");

                entity.HasOne(x => x.User).WithOne(x => x.Recipe).HasForeignKey<Recipe>(x => x.UserId);

            });

            modelBuilder.Entity<Reward>(entity =>
            {
                entity.ToTable("REWARD_T");
                // Configure Primary Keys                  
                entity.HasKey(u => u.Id).HasName("PK_Rewards");

                entity.Property(e => e.Id)
                    .HasColumnName("rew_id")
                    .HasColumnType("int")
                    .UseMySqlIdentityColumn()
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("rew_name")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnName("rew_description")
                    .HasColumnType("varchar(400)")
                    .HasMaxLength(400)
                    .IsRequired();

                entity.Property(e => e.Point)
                    .HasColumnName("rew_point")
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("rew_imageurl")
                    .HasColumnType("varchar(400)")
                    .HasMaxLength(400)
                    .IsRequired();

            });


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
