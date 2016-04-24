using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using weblog.Models.Blog;

namespace weblog.Migrations.BlogDb
{
    [DbContext(typeof(BlogDbContext))]
    partial class BlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("weblog.Models.Blog.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int?>("TopicTopicId");

                    b.HasKey("PostId");
                });

            modelBuilder.Entity("weblog.Models.Blog.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("TopicId");
                });

            modelBuilder.Entity("weblog.Models.Blog.Post", b =>
                {
                    b.HasOne("weblog.Models.Blog.Topic")
                        .WithMany()
                        .HasForeignKey("TopicTopicId");
                });
        }
    }
}
