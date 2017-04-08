using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Login.Models;

namespace Login.Migrations
{
    [DbContext(typeof(LoginDbContext))]
    partial class LoginDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Login.Models.User", b =>
                {
                    b.Property<Guid>("UsersId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Gender");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("UserName");

                    b.Property<int?>("UserSessionId");

                    b.HasKey("UsersId");

                    b.HasIndex("UserSessionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Login.Models.UserSession", b =>
                {
                    b.Property<int>("UserSessionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("UserSessionId");

                    b.ToTable("UserSession");
                });

            modelBuilder.Entity("Login.Models.User", b =>
                {
                    b.HasOne("Login.Models.UserSession", "UserSession")
                        .WithMany()
                        .HasForeignKey("UserSessionId");
                });
        }
    }
}
