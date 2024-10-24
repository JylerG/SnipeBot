﻿// <auto-generated />
using System;
using DeltaBotFour.Persistence.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeltaBotFour.Persistence.Migrations
{
    [DbContext(typeof(DeltaBotFourDbContext))]
    partial class DeltaBotFourDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("DeltaBotFour.Models.DB4State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("IgnoreQuotedDeltaPMUserList")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("LastActivityTimeUtcKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastProcessedCommentIds")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastProcessedEditIds")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Db4States");
                });

            modelBuilder.Entity("DeltaBotFour.Models.DeltaComment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentText")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("FromUsername")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LinkId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentPostId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentPostLinkId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentPostPermalink")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentPostShortlink")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentPostTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Permalink")
                        .HasColumnType("TEXT");

                    b.Property<string>("Shortlink")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToUsername")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DeltaComments");
                });

            modelBuilder.Entity("DeltaBotFour.Models.DeltaLogPostMapping", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeltaLogPostId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeltaLogPostUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("MainSubPostUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DeltaLogPostMappings");
                });

            modelBuilder.Entity("DeltaBotFour.Models.Deltaboard", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeltaboardType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdatedUtc")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Snipeboards");
                });

            modelBuilder.Entity("DeltaBotFour.Models.DeltaboardEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeltaboardId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdatedUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeltaboardId");

                    b.ToTable("DeltaboardEntries");
                });

            modelBuilder.Entity("DeltaBotFour.Models.DeltaboardEntry", b =>
                {
                    b.HasOne("DeltaBotFour.Models.Deltaboard", "Deltaboard")
                        .WithMany("Entries")
                        .HasForeignKey("DeltaboardId");

                    b.Navigation("Deltaboard");
                });

            modelBuilder.Entity("DeltaBotFour.Models.Deltaboard", b =>
                {
                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
