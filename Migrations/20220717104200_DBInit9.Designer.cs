﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TasteonusAPI.Data;

namespace TasteonusAPI.Migrations
{
    [DbContext(typeof(BackendDBContext))]
    [Migration("20220717104200_DBInit9")]
    partial class DBInit9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TasteonusAPI.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fb_id")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("fb_description");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(2,1)")
                        .HasColumnName("fb_rating");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int")
                        .HasColumnName("rec_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK_Feedbacks");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("FEEDBACK_T");
                });

            modelBuilder.Entity("TasteonusAPI.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("rec_id")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("rec_imageurl");

                    b.Property<string>("Ingredient")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("rec_ingredient");

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("rec_instruction");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("rec_name");

                    b.Property<string>("Uid")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("user_uid");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("VideoUrl")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("rec_videourl");

                    b.HasKey("Id")
                        .HasName("PK_Recipes");

                    b.HasIndex("UserId");

                    b.ToTable("RECIPE_T");
                });

            modelBuilder.Entity("TasteonusAPI.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("rew_id")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("rew_description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("rew_imageurl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("rew_name");

                    b.Property<int>("Point")
                        .HasColumnType("int")
                        .HasColumnName("rew_point");

                    b.HasKey("Id")
                        .HasName("PK_Rewards");

                    b.ToTable("REWARD_T");
                });

            modelBuilder.Entity("TasteonusAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biodata")
                        .HasColumnType("longtext")
                        .HasColumnName("user_biodata");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("user_email");

                    b.Property<string>("LoginMethod")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("user_loginmethod");

                    b.Property<string>("Password")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("user_password");

                    b.Property<int>("Point")
                        .HasColumnType("int")
                        .HasColumnName("user_point");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("longtext")
                        .HasColumnName("user_imageurl");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("user_uid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("PK_Users");

                    b.ToTable("USER_T");
                });

            modelBuilder.Entity("TasteonusAPI.Models.Feedback", b =>
                {
                    b.HasOne("TasteonusAPI.Models.Recipe", "Recipe")
                        .WithMany("Feedbacks")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TasteonusAPI.Models.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TasteonusAPI.Models.Recipe", b =>
                {
                    b.HasOne("TasteonusAPI.Models.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TasteonusAPI.Models.Recipe", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("TasteonusAPI.Models.User", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
