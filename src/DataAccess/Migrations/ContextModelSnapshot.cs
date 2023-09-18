﻿// <auto-generated />
using System;
using DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Entities.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Point")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("QuestionSetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.HasIndex("QuestionSetId");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("Models.Entities.QuestionSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.ToTable("QuestionSets", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("QuestionSetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("QuestionSetId");

                    b.ToTable("Session", (string)null);
                });

            modelBuilder.Entity("Models.Entities.SessionContent", b =>
                {
                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubscriberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Success")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("SessionId", "QuestionId", "SubscriberId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SubscriberId");

                    b.ToTable("SessionContent", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Subscriber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Subscriber", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Answer", b =>
                {
                    b.HasOne("Models.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Models.Entities.Question", b =>
                {
                    b.HasOne("Models.Entities.QuestionSet", "QuestionSet")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionSet");
                });

            modelBuilder.Entity("Models.Entities.Session", b =>
                {
                    b.HasOne("Models.Entities.QuestionSet", "QuestionSet")
                        .WithMany("Sessions")
                        .HasForeignKey("QuestionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionSet");
                });

            modelBuilder.Entity("Models.Entities.SessionContent", b =>
                {
                    b.HasOne("Models.Entities.Answer", "Answer")
                        .WithMany("SessionContents")
                        .HasForeignKey("AnswerId");

                    b.HasOne("Models.Entities.Question", "Question")
                        .WithMany("SessionContents")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Session", "Session")
                        .WithMany("SessionContents")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Subscriber", "Subscriber")
                        .WithMany("SessionContents")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Question");

                    b.Navigation("Session");

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("Models.Entities.Answer", b =>
                {
                    b.Navigation("SessionContents");
                });

            modelBuilder.Entity("Models.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("SessionContents");
                });

            modelBuilder.Entity("Models.Entities.QuestionSet", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Models.Entities.Session", b =>
                {
                    b.Navigation("SessionContents");
                });

            modelBuilder.Entity("Models.Entities.Subscriber", b =>
                {
                    b.Navigation("SessionContents");
                });
#pragma warning restore 612, 618
        }
    }
}
