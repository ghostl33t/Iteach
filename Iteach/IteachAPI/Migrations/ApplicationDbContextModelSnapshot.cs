﻿// <auto-generated />
using IteachAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IteachAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IteachAPI.Models.Child", b =>
                {
                    b.Property<long>("ChildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ChildId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<long?>("ParentUserId")
                        .HasColumnType("bigint");

                    b.HasKey("ChildId");

                    b.HasIndex("ParentUserId");

                    b.ToTable("ChildsTable");
                });

            modelBuilder.Entity("IteachAPI.Models.MtMTables.ChildTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("ChildId")
                        .HasColumnType("bigint");

                    b.Property<long>("TestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("TestId");

                    b.ToTable("ChildTestTable");
                });

            modelBuilder.Entity("IteachAPI.Models.MtMTables.TeachPlanUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("TeachPlanId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeacherUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TeachPlanId");

                    b.HasIndex("TeacherUserId");

                    b.ToTable("TeachPlanUserTable");
                });

            modelBuilder.Entity("IteachAPI.Models.MtMTables.TestResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("ChildId")
                        .HasColumnType("bigint");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("TestId");

                    b.ToTable("TestResponseTable");
                });

            modelBuilder.Entity("IteachAPI.Models.MtMTables.UserTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTestTable");
                });

            modelBuilder.Entity("IteachAPI.Models.TeachPlan", b =>
                {
                    b.Property<long>("TeachPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TeachPlanId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("TeachPlanId");

                    b.ToTable("TeachPlanTable");
                });

            modelBuilder.Entity("IteachAPI.Models.Test", b =>
                {
                    b.Property<long>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TestId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("TestId");

                    b.ToTable("TestTable");
                });

            modelBuilder.Entity("IteachAPI.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<short>("Roles")
                        .HasColumnType("smallint");

                    b.HasKey("UserId");

                    b.ToTable("UserTable");
                });

            modelBuilder.Entity("IteachAPI.Models.Child", b =>
                {
                    b.HasOne("IteachAPI.Models.User", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentUserId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("IteachAPI.Models.MtMTables.ChildTest", b =>
                {
                    b.HasOne("IteachAPI.Models.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IteachAPI.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("IteachAPI.Models.MtMTables.TeachPlanUser", b =>
                {
                    b.HasOne("IteachAPI.Models.TeachPlan", "TeachPlan")
                        .WithMany()
                        .HasForeignKey("TeachPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IteachAPI.Models.User", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeachPlan");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("IteachAPI.Models.MtMTables.TestResponse", b =>
                {
                    b.HasOne("IteachAPI.Models.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IteachAPI.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("IteachAPI.Models.MtMTables.UserTest", b =>
                {
                    b.HasOne("IteachAPI.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IteachAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
