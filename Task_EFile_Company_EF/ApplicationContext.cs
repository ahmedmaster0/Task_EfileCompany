using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task_EFile_Company_Domain.Models;
using Task_EFile_Company_EF.EntityTypeConfiguration;

namespace Task_EFile_Company_EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option): base(option)
        {
        }

        DbSet<Contact> contacts { get; set; }
        DbSet<UserLogin> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ContactTypeConfiguration().Configure(modelBuilder.Entity<Contact>());
            new UserLogin_TypeConfiguration().Configure(modelBuilder.Entity<UserLogin>());

        }
    }
}
