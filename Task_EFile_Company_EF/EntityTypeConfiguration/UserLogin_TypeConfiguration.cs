using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Task_EFile_Company_Domain.Models;

namespace Task_EFile_Company_EF.EntityTypeConfiguration
{
    class UserLogin_TypeConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {

            builder.Property(m => m.UserName).HasMaxLength(20);
            builder.Property(m => m.Password).HasMaxLength(20);

            builder.HasData(
                new UserLogin {Id=1,UserName= "user1",Password= "user1" },
                new UserLogin {Id=2,UserName= "user2",Password= "user2" }
                );
                
               
        }
    }
}
