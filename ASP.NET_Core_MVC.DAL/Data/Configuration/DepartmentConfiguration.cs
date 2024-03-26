﻿using ASP.NET_Core_MVC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC.DAL.Data.Configration
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10,10);
            builder.Property(D => D.Code).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(D => D.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        }
    }
}
