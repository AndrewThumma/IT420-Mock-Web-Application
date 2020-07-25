﻿// <auto-generated />
using System;
using IT420.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IT420.Migrations
{
    [DbContext(typeof(IT420DBContext))]
    partial class IT420DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IT420.Core.Blog", b =>
                {
                    b.Property<int>("blogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("approved")
                        .HasColumnType("bit");

                    b.Property<string>("blogImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("blogTypeId")
                        .HasColumnType("int");

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("blogId");

                    b.HasIndex("blogTypeId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("IT420.Core.BlogType", b =>
                {
                    b.Property<int>("blogTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("blogTypeId");

                    b.ToTable("BlogTypes");

                    b.HasData(
                        new
                        {
                            blogTypeId = 1,
                            type = "Breastfeeding"
                        },
                        new
                        {
                            blogTypeId = 2,
                            type = "Eduction and Learning"
                        },
                        new
                        {
                            blogTypeId = 3,
                            type = "Hobbies"
                        });
                });

            modelBuilder.Entity("IT420.Core.Expert", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte[]>("image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("userProfileId");

                    b.ToTable("Experts");
                });

            modelBuilder.Entity("IT420.Core.ExpertQuestion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("answered")
                        .HasColumnType("bit");

                    b.Property<string>("question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("typeId");

                    b.ToTable("ExpertQuestions");
                });

            modelBuilder.Entity("IT420.Core.ExpertQuestionAnswer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("expertId")
                        .HasColumnType("int");

                    b.Property<int>("questionId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("expertId");

                    b.HasIndex("questionId")
                        .IsUnique();

                    b.ToTable("ExpertAnswers");
                });

            modelBuilder.Entity("IT420.Core.ExpertQuestionType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ExpertQuestionTypes");

                    b.HasData(
                        new
                        {
                            id = 1,
                            type = "Health Corner"
                        },
                        new
                        {
                            id = 2,
                            type = "Nutrition Corner"
                        });
                });

            modelBuilder.Entity("IT420.Core.Talk", b =>
                {
                    b.Property<int>("TalkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("TalkTypeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TalkId");

                    b.HasIndex("TalkTypeTypeId");

                    b.ToTable("Talks");
                });

            modelBuilder.Entity("IT420.Core.TalkComment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TalkId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentID");

                    b.HasIndex("TalkId");

                    b.ToTable("TalkComments");
                });

            modelBuilder.Entity("IT420.Core.TalkType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("TalkTypes");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            Type = "Parenting"
                        },
                        new
                        {
                            TypeId = 2,
                            Type = "Career"
                        },
                        new
                        {
                            TypeId = 3,
                            Type = "Babycare"
                        },
                        new
                        {
                            TypeId = 4,
                            Type = "Food and Nutrition"
                        });
                });

            modelBuilder.Entity("IT420.Core.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExpert")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("userImg")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("IT420.Core.Blog", b =>
                {
                    b.HasOne("IT420.Core.BlogType", "type")
                        .WithMany()
                        .HasForeignKey("blogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IT420.Core.Expert", b =>
                {
                    b.HasOne("IT420.Core.UserProfile", "userProfile")
                        .WithMany()
                        .HasForeignKey("userProfileId");
                });

            modelBuilder.Entity("IT420.Core.ExpertQuestion", b =>
                {
                    b.HasOne("IT420.Core.ExpertQuestionType", "Type")
                        .WithMany()
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IT420.Core.ExpertQuestionAnswer", b =>
                {
                    b.HasOne("IT420.Core.Expert", "Expert")
                        .WithMany("Answers")
                        .HasForeignKey("expertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IT420.Core.ExpertQuestion", "Question")
                        .WithOne("Answer")
                        .HasForeignKey("IT420.Core.ExpertQuestionAnswer", "questionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IT420.Core.Talk", b =>
                {
                    b.HasOne("IT420.Core.TalkType", "TalkType")
                        .WithMany()
                        .HasForeignKey("TalkTypeTypeId");
                });

            modelBuilder.Entity("IT420.Core.TalkComment", b =>
                {
                    b.HasOne("IT420.Core.Talk", "Talk")
                        .WithMany("TalkComments")
                        .HasForeignKey("TalkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
