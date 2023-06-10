﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizApp;

#nullable disable

namespace QuizApp.Migrations
{
    [DbContext(typeof(QuizAppContext))]
    partial class QuizAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuizApp.Entities.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"), 1L, 1);

                    b.Property<string>("AnswerContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            AnswerId = 1,
                            AnswerContent = "Answer 1 for Question 1",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 2,
                            AnswerContent = "Answer 2 for Question 1",
                            IsCorrect = true,
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 3,
                            AnswerContent = "Answer 3 for Question 1",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 4,
                            AnswerContent = "Answer 4 for Question 1",
                            IsCorrect = false,
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 5,
                            AnswerContent = "Answer 1 for Question 2",
                            IsCorrect = true,
                            QuestionId = 2
                        },
                        new
                        {
                            AnswerId = 6,
                            AnswerContent = "Answer 2 for Question 2",
                            IsCorrect = false,
                            QuestionId = 2
                        },
                        new
                        {
                            AnswerId = 7,
                            AnswerContent = "Answer 3 for Question 2",
                            IsCorrect = false,
                            QuestionId = 2
                        },
                        new
                        {
                            AnswerId = 8,
                            AnswerContent = "Answer 4 for Question 2",
                            IsCorrect = false,
                            QuestionId = 2
                        },
                        new
                        {
                            AnswerId = 9,
                            AnswerContent = "Answer 1 for Question 3",
                            IsCorrect = false,
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 10,
                            AnswerContent = "Answer 2 for Question 3",
                            IsCorrect = false,
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 11,
                            AnswerContent = "Answer 3 for Question 3",
                            IsCorrect = false,
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 12,
                            AnswerContent = "Answer 4 for Question 3",
                            IsCorrect = true,
                            QuestionId = 3
                        });
                });

            modelBuilder.Entity("QuizApp.Entities.Attempt", b =>
                {
                    b.Property<int>("AttemptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttemptId"), 1L, 1);

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AttemptId");

                    b.HasIndex("QuizId");

                    b.ToTable("Attempts");
                });

            modelBuilder.Entity("QuizApp.Entities.AttemptAnswer", b =>
                {
                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("AttemptId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId", "AttemptId");

                    b.HasIndex("AttemptId");

                    b.ToTable("AttemptAnswers");
                });

            modelBuilder.Entity("QuizApp.Entities.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<string>("QuestionContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            QuestionContent = "Question 1",
                            QuizId = 1
                        },
                        new
                        {
                            QuestionId = 2,
                            QuestionContent = "Question 2",
                            QuizId = 1
                        },
                        new
                        {
                            QuestionId = 3,
                            QuestionContent = "Question 3",
                            QuizId = 1
                        });
                });

            modelBuilder.Entity("QuizApp.Entities.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuizId"), 1L, 1);

                    b.Property<int>("PassedThreshold")
                        .HasColumnType("int");

                    b.Property<string>("QuizName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuizId");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            QuizId = 1,
                            PassedThreshold = 2,
                            QuizName = "Quiz 1"
                        });
                });

            modelBuilder.Entity("QuizApp.Entities.Answer", b =>
                {
                    b.HasOne("QuizApp.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizApp.Entities.Attempt", b =>
                {
                    b.HasOne("QuizApp.Entities.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizApp.Entities.AttemptAnswer", b =>
                {
                    b.HasOne("QuizApp.Entities.Answer", "Answer")
                        .WithMany("AttemptAnswers")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizApp.Entities.Attempt", "Attempt")
                        .WithMany("AttemptAnswers")
                        .HasForeignKey("AttemptId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Attempt");
                });

            modelBuilder.Entity("QuizApp.Entities.Question", b =>
                {
                    b.HasOne("QuizApp.Entities.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizApp.Entities.Answer", b =>
                {
                    b.Navigation("AttemptAnswers");
                });

            modelBuilder.Entity("QuizApp.Entities.Attempt", b =>
                {
                    b.Navigation("AttemptAnswers");
                });

            modelBuilder.Entity("QuizApp.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("QuizApp.Entities.Quiz", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
