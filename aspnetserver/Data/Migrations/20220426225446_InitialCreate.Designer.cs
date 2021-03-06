// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetserver.Data;

#nullable disable

namespace aspnetserver.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220426225446_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("aspnetserver.Data.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("PostID");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostID = 1,
                            Content = "This is post 1 has some very interesting content.",
                            Title = "Post 1"
                        },
                        new
                        {
                            PostID = 2,
                            Content = "This is post 2 has some very interesting content.",
                            Title = "Post 2"
                        },
                        new
                        {
                            PostID = 3,
                            Content = "This is post 3 has some very interesting content.",
                            Title = "Post 3"
                        },
                        new
                        {
                            PostID = 4,
                            Content = "This is post 4 has some very interesting content.",
                            Title = "Post 4"
                        },
                        new
                        {
                            PostID = 5,
                            Content = "This is post 5 has some very interesting content.",
                            Title = "Post 5"
                        },
                        new
                        {
                            PostID = 6,
                            Content = "This is post 6 has some very interesting content.",
                            Title = "Post 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
