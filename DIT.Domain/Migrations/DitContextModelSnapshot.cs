﻿// <auto-generated />
using System;
using DIT.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DIT.Domain.Migrations
{
    [DbContext(typeof(DitContext))]
    partial class DitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dit")
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DIT.Domain.Models.Connector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Connectors");
                });

            modelBuilder.Entity("DIT.Domain.Models.Flow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlowContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProcessId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FlowContentId");

                    b.HasIndex("ProcessId");

                    b.ToTable("Flows");
                });

            modelBuilder.Entity("DIT.Domain.Models.FlowContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("FlowContents");
                });

            modelBuilder.Entity("DIT.Domain.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("DIT.Domain.Models.Process", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProcessContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProcessContentId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("DIT.Domain.Models.ProcessContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ProcessContents");
                });

            modelBuilder.Entity("DIT.Domain.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DIT.Domain.Models.ProjectConnector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConnectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConnectorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectConnectors");
                });

            modelBuilder.Entity("DIT.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DIT.Domain.Models.Connector", b =>
                {
                    b.HasOne("DIT.Domain.Models.User", "User")
                        .WithMany("Connectors")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("DIT.Domain.Models.Flow", b =>
                {
                    b.HasOne("DIT.Domain.Models.FlowContent", "FlowContent")
                        .WithMany()
                        .HasForeignKey("FlowContentId");

                    b.HasOne("DIT.Domain.Models.Process", null)
                        .WithMany("Flows")
                        .HasForeignKey("ProcessId");
                });

            modelBuilder.Entity("DIT.Domain.Models.Process", b =>
                {
                    b.HasOne("DIT.Domain.Models.ProcessContent", "ProcessContent")
                        .WithMany()
                        .HasForeignKey("ProcessContentId");

                    b.HasOne("DIT.Domain.Models.Project", null)
                        .WithMany("Processes")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("DIT.Domain.Models.Project", b =>
                {
                    b.HasOne("DIT.Domain.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DIT.Domain.Models.ProjectConnector", b =>
                {
                    b.HasOne("DIT.Domain.Models.Connector", "Connector")
                        .WithMany("ProjectConnectors")
                        .HasForeignKey("ConnectorId");

                    b.HasOne("DIT.Domain.Models.Project", "Project")
                        .WithMany("ProjectConnectors")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("DIT.Domain.Models.User", b =>
                {
                    b.HasOne("DIT.Domain.Models.Organization", null)
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId");
                });
#pragma warning restore 612, 618
        }
    }
}
