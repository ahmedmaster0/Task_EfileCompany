using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Task_EFile_Company_Domain.Models;

namespace Task_EFile_Company_EF.EntityTypeConfiguration
{
    class ContactTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {

            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Phone).IsRequired().HasMaxLength(11);
            builder.Property(m => m.Address).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Notes).HasMaxLength(250);

        }
    }
}
